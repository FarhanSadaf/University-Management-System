using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagementSystem.UI
{
    public partial class LauncherUI : Form
    {
        public LauncherUI()
        {
            InitializeComponent();
        }

        private void studentUIButton_Click(object sender, EventArgs e)
        {
            //new StudentUI().Show();
            new StudentUI().ShowDialog();
        }

        private void takesCorseUIButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            new TakesCourseUI().ShowDialog();
        }
    }
}
