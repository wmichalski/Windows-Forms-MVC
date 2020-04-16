using System;
using System.Windows.Forms;

namespace PAIN1
{
    public partial class RecordingsForm : Form
    {

        private Document Document { get; set; }
        public RecordingsForm(Document document)
        {
            InitializeComponent();
            Document = document;
        }

        private void RecordingsForm_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddRecordingEvent += Document_AddRecordingEvent;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DropdownFilters_DropDownClosed(object sender, EventArgs e)
        {
            string selectedText = DropdownFilters.Text;

            UpdateItems(selectedText);
        }

        private void RecordingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ParentForm.MdiChildren.Length == 1)
            {
                e.Cancel = true;
            }
        }

        private void Document_AddRecordingEvent(Recording recording)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = recording;
            UpdateItem(item);
            recordingsListView.Items.Add(item);
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            RecordingForm recordingForm = new RecordingForm(null, Document.recordings);
            if (recordingForm.ShowDialog() == DialogResult.OK)
            {
                Recording newRecording = new Recording(recordingForm.RecordingName, recordingForm.RecordingArtist, recordingForm.RecordingReleaseDate, recordingForm.RecordingGenre);

                Document.AddRecording(newRecording);

            }
        }
        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (recordingsListView.SelectedItems.Count == 1)
            {
                /*Recording recording = (Recording)recordingsListView.SelectedItems[0].Tag;
                RecordingForm recordingForm = new RecordingForm(recording, Document.recordings);
                if (recordingForm.ShowDialog() == DialogResult.OK)
                {
                    recording.Name = recordingForm.RecordingName;
                    recording.Artist = recordingForm.RecordingArtist;
                    recording.ReleaseDate = recordingForm.RecordingReleaseDate;
                    recording.Genre = recordingForm.RecordingGenre;

                    //Document.UpdateRecording(recording);
                    */
                    UpdateAllWindows(recordingsListView.SelectedItems[0]);
                }
            }

        private void ToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (recordingsListView.SelectedItems.Count == 1)
            {
                Recording recording = (Recording)recordingsListView.SelectedItems[0].Tag;
                Document.DeleteRecording(recording);

                UpdateAllWindows(recordingsListView.SelectedItems[0]);
            }
        }

        private void UpdateAllWindows(ListViewItem item)
        {
            foreach (RecordingsForm form in this.ParentForm.MdiChildren)
            {
                /*int selectedItem = form.recordingsListView.FocusedItem.Index;
                foreach (ListViewItem item in form.recordingsListView.Items)
                {
                
                }
                form.UpdateItems();
                if (selectedItem < form.recordingsListView.Items.Count)
                {
                    form.recordingsListView.Items[selectedItem].Focused = true;
                    form.recordingsListView.Items[selectedItem].Selected = true;
                }*/
                form.UpdateItem(item);
            }
        }


        private void UpdateItem(ListViewItem item)
        {
            Recording recording = (Recording)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = recording.Artist;
            item.SubItems[1].Text = recording.Name;
            item.SubItems[2].Text = recording.ReleaseDate.ToShortDateString();
            item.SubItems[3].Text = recording.Genre;
        }

        private void UpdateItems(string filter = null)
        {
            recordingsListView.Items.Clear();
            foreach (Recording recording in Document.recordings)
            {
                    ListViewItem item = new ListViewItem();
                    item.Tag = recording;
                    UpdateItem(item);
                    if (recording.ReleaseDate < new DateTime(1999, 12, 31) && filter == "this century")
                    {; }
                    else if (recording.ReleaseDate > new DateTime(1999, 12, 31) && filter == "prev century")
                    {; }
                    else
                    {
                        recordingsListView.Items.Add(item);
                    }
            }
        }
    }
}
