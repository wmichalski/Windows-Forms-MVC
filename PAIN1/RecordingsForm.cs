using System;
using System.Windows.Forms;

namespace PAIN1
{
    public partial class RecordingsForm : Form
    {

        private Document Document { get; set; }

        string filter = null;

        public RecordingsForm(Document document)
        {
            InitializeComponent();
            Document = document;
        }

        private void RecordingsForm_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddRecordingEvent += Document_AddRecordingEvent;
            Document.DeleteRecordingEvent += Document_DeleteRecordingEvent;

        }

        private void DropdownFilters_DropDownClosed(object sender, EventArgs e)
        {
            string selectedText = DropdownFilters.Text;

            filter = selectedText;
            UpdateItems(filter);
        }

        private void RecordingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ParentForm.MdiChildren.Length == 1)
            {
                e.Cancel = true;
            }
        }

        private void updateCounter()
        {
            MainForm main = (MainForm)this.ParentForm;
            main.setCounter(this.recordingsListView.Items.Count.ToString());
        }

        private void RecordingsForm_GotFocus(object sender, EventArgs e)
        {
            this.updateCounter();
        }

        private void Document_AddRecordingEvent(Recording recording)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = recording;
            UpdateItem(item);
            recordingsListView.Items.Add(item);
            this.updateCounter();
        }

        private void Document_DeleteRecordingEvent(Recording recording)
        {
            foreach (ListViewItem item in recordingsListView.Items)
                if (item.Tag == recording)
                {
                    recordingsListView.Items.Remove(item);
                }
            this.updateCounter();
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
                Recording recording = (Recording)recordingsListView.SelectedItems[0].Tag;
                RecordingForm recordingForm = new RecordingForm(recording, Document.recordings);
                if (recordingForm.ShowDialog() == DialogResult.OK)
                {
                    recording.Name = recordingForm.RecordingName;
                    recording.Artist = recordingForm.RecordingArtist;
                    recording.ReleaseDate = recordingForm.RecordingReleaseDate;
                    recording.Genre = recordingForm.RecordingGenre;
                }

                UpdateAllWindows(recording);

            }
        }
       
            private void ToolStripButtonDelete_Click(object sender, EventArgs e)
            {
                if (recordingsListView.SelectedItems.Count == 1)
                {
                    Recording recording = (Recording)recordingsListView.SelectedItems[0].Tag;
                    Document.DeleteRecording(recording);
                }
            }

            private void UpdateAllWindows(Recording recording)
            {
               foreach (RecordingsForm form in this.ParentForm.MdiChildren)
                {
                    foreach (ListViewItem item in form.recordingsListView.Items)
                    {
                        if (item.Tag == recording)
                        {
                            UpdateItem(item);
                            break;
                        }
                    }
                    if (recording.ReleaseDate > new DateTime(1999, 12, 31) && form.filter == "this century")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = recording;
                        UpdateItem(item);
                        form.recordingsListView.Items.Add(item);
                    }
                    if (recording.ReleaseDate < new DateTime(1999, 12, 31) && form.filter == "prev century")
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = recording;
                        UpdateItem(item);
                        form.recordingsListView.Items.Add(item);
                    }
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
                this.updateCounter();
            }
        }
    }

