using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAIN1
{
    public partial class UserControl1 : UserControl
    {
        public enum PictureType { Rock, Pop, Rap }
        PictureType state;

        public PictureType Picture_
        {
            get
            { 
                return state; 
            }
            set
            { 
                state = value;
            }

        }

        public UserControl1()
        {
            state = Picture_;
            InitializeComponent();
            setImage(state);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int next = ((int)state + 1) % 3;
            state = (PictureType)next;
            setImage(state);
        }

        public void setImage(PictureType state)
        {
            if (state == PictureType.Rock)
            {
                pictureBox1.Image = global::PAIN1.Properties.Resources.rock;
            }
            else if (state == PictureType.Pop)
            {
                pictureBox1.Image = global::PAIN1.Properties.Resources.pop;
            }
            else if (state == PictureType.Rap)
            {
                pictureBox1.Image = global::PAIN1.Properties.Resources.rap;
            }
        }

        public PictureType getEnumFromString(string genre)
        {
            if (genre == "rock")
            {
                return PictureType.Rock;
            }
            else if (genre == "pop")
            {
                return PictureType.Pop;
            }
            else if (genre == "rap")
            {
                return PictureType.Rap;
            }

            return PictureType.Rock;
        }
    }
}
