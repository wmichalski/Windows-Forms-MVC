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


        public void AddRecording(Recording recording)
        {
            recordings.Add(recording);

            //if (AddStudentEvent != null)
            //    AddStudentEvent(student);

            //if ( AddStudentEvent != null)
            //    AddStudentEvent.Invoke(student);

            AddRecordingEvent?.Invoke(recording);
        }

        public void DeleteRecording(Recording delrecording)
        {
            recordings.Remove(delrecording);
            /*foreach (Recording recording in recordings)
            {
                if (recording == delrecording)
                {

                }
            }
            */
        }
    }

}
