using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAIN1
{
    public partial class RecordingForm : Form
    {
        private Recording recording;
        private List<Recording> recordings;

        public string RecordingName
        {
            get { return textBoxName.Text; }
        }

        public string RecordingArtist
        {
            get { return textBoxArtist.Text; }
        }

        public DateTime RecordingReleaseDate
        {
            get { return dateTimePicker1.Value; }
        }

        public string RecordingGenre
        {
            get { return "rap"; }
        }

        public RecordingForm(Recording recording, List<Recording> recordings)
        {
            InitializeComponent();
            this.recording = recording;
            this.recordings = recordings;
        }

        private void RecordingForm_Load(object sender, EventArgs e)
        {
            if (recording != null)
            {
                textBoxName.Text = recording.Name;
                textBoxArtist.Text = recording.Artist;
                dateTimePicker1.Value = recording.ReleaseDate;

            }
            else
            {
                dateTimePicker1.Value = new DateTime(1980, 1, 1);
            }
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

     
    }
}
