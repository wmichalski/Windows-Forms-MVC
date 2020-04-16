using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;



namespace PAIN1
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class UserControlEditor : System.Drawing.Design.UITypeEditor
    {
        public UserControlEditor()
        {
        }

        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                UserControl1 userControl = new UserControl1();
                edSvc.DropDownControl(userControl);

                return userControl.Picture_;
            }
            return null;
        }

    }

    public partial class UserControl1 : UserControl
    {
        public enum PictureType { Rock, Pop, Rap }
        PictureType state;


        [EditorAttribute(typeof(UserControlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Own options")]
        [BrowsableAttribute(true)]
        public PictureType Picture_
        {
            get
            {
                return state;
            }
            set
            {
                state = value; setImage(state);
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
            RecordingForm form = (RecordingForm)this.ParentForm;
            form.setGenre();
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
