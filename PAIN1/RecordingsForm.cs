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
            Document.EditRecordingEvent += Document_EditRecordingEvent;
            updateCounter();

        }

        private void DropdownFilters_DropDownClosed(object sender, EventArgs e)
        {
            string selectedText = DropdownFilters.Text;

            filter = selectedText;
            UpdateItems(filter);
            updateCounter();
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
            if (main != null)
                this.toolStripStatusCount.Text = this.recordingsListView.Items.Count.ToString();
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
            if (recording.ReleaseDate <= new DateTime(1999, 12, 31) && filter == "this century")
                {; }
            else if (recording.ReleaseDate > new DateTime(1999, 12, 31) && filter == "prev century")
                {; }
            else
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

        private void Document_EditRecordingEvent(Recording recording)
        {
            bool found = false;
            foreach (ListViewItem item in this.recordingsListView.Items)
            {
                if (item.Tag == recording)
                {
                    found = true;
                    if (recording.ReleaseDate <= new DateTime(1999, 12, 31) && this.filter == "this century")
                        this.recordingsListView.Items.Remove(item);
                    else if (recording.ReleaseDate > new DateTime(1999, 12, 31) && this.filter == "prev century")
                        this.recordingsListView.Items.Remove(item);
                    else
                    {
                        UpdateItem(item);
                        break;
                    }
                }
            }
            if (!found)
            {
                if (recording.ReleaseDate > new DateTime(1999, 12, 31) && this.filter == "this century")
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = recording;
                    UpdateItem(item);
                    this.recordingsListView.Items.Add(item);
                }
                if (recording.ReleaseDate <= new DateTime(1999, 12, 31) && this.filter == "prev century")
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = recording;
                    UpdateItem(item);
                    this.recordingsListView.Items.Add(item);
                }
            }
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            addNewElement();
        }

        private void dropdownAdd_Click(object sender, EventArgs e)
        {
            addNewElement();
        }

        private void addNewElement()
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
            editElement();
        }

        private void dropdownEdit_Click(object sender, EventArgs e)
        {
            editElement();
        }

        private void editElement()
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
                Document.EditRecording(recording);
                updateCounter();

            }
        }

        private void dropdownDelete_Click(object sender, EventArgs e)
        {
            deleteElement();
        }


        private void ToolStripButtonDelete_Click(object sender, EventArgs e)
        {
            deleteElement();
        }

        private void deleteElement()
        {
            if (recordingsListView.SelectedItems.Count == 1)
            {
                Recording recording = (Recording)recordingsListView.SelectedItems[0].Tag;
                Document.DeleteRecording(recording);
            }
        }


        private void UpdateItem(ListViewItem item)
        {
            Recording recording = (Recording)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = recording.Name;
            item.SubItems[1].Text = recording.Artist;
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
                if (recording.ReleaseDate <= new DateTime(1999, 12, 31) && filter == "this century")
                {; }
                else if (recording.ReleaseDate > new DateTime(1999, 12, 31) && filter == "prev century")
                {; }
                else
                {
                    recordingsListView.Items.Add(item);
                }
            }
        }

        private void RecordingsForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
            ToolStripManager.Merge(statusStrip1, ((MainForm)MdiParent).statusStrip1);
        }

        private void RecordingsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
            ToolStripManager.RevertMerge(((MainForm)MdiParent).statusStrip1, statusStrip1);
        }

    }
}

