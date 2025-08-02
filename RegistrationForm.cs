using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopPsychologist_WF
{
    public partial class RegistrationForm : Form
    {
        private string selectedGender = "М";

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                selectedGender = rb.Text;
            }
        }

        public string GetGender()
        {
            return selectedGender;
        }

    }
}
