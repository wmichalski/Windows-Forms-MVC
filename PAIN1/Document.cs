using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN1
{
    public class Document
    {
        public List<Recording> recordings = new List<Recording>();

        public event Action<Recording> AddRecordingEvent;
        public event Action<Recording> DeleteRecordingEvent;
        public event Action<Recording> EditRecordingEvent;

        public void AddRecording(Recording recording)
        {
            recordings.Add(recording);

            AddRecordingEvent?.Invoke(recording);
        }

        public void DeleteRecording(Recording delRecording)
        {
            recordings.Remove(delRecording);

            DeleteRecordingEvent?.Invoke(delRecording);
        }

        public void EditRecording(Recording edRecording)
        {
            EditRecordingEvent?.Invoke(edRecording);
        }
    }

}
