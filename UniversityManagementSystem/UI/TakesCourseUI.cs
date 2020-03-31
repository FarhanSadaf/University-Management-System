using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem.UI
{
    public partial class TakesCourseUI : Form
    {
        private StudentManager studentManager = new StudentManager();
        private CourseManager courseManager = new CourseManager();
        private TakesManager takesManager = new TakesManager();

        public TakesCourseUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Takes takes = new Takes();
            takes.StudentId = Convert.ToInt32(rollComboBox.SelectedValue);
            takes.CourseId = courseComboBox.SelectedValue.ToString();
            takes.EnrollDate = enrollDateTimePicker.Value;

            string message = takesManager.SaveTakes(takes);
            MessageBox.Show(message);

            PopulateTakesCourseListView(takesManager.GetFromTakes());
        }

        private void TakesCourseUI_Load(object sender, EventArgs e)
        {
            List<StudentWithDept> students = studentManager.GetAllStudents();
            StudentWithDept defaultStudentWithDept = new StudentWithDept();
            defaultStudentWithDept.SId = -1;
            defaultStudentWithDept.SName = "--select--";
            students.Insert(0, defaultStudentWithDept);
            rollComboBox.DataSource = students;
            rollComboBox.DisplayMember = "SName";
            rollComboBox.ValueMember = "SId";

            List<Course> courses = courseManager.GetAllCourses();
            Course defaultCourse = new Course();
            defaultCourse.Id = "-1";
            defaultCourse.Name = "--select--";
            courses.Insert(0, defaultCourse);
            courseComboBox.DataSource = courses;
            courseComboBox.DisplayMember = "Name";
            courseComboBox.ValueMember = "Id";

            PopulateTakesCourseListView(takesManager.GetFromTakes());
        }

        private void PopulateTakesCourseListView(List<StudentTakesCourse> sTakes)
        {
            takesCourseListView.Items.Clear();

            int index = 1;
            foreach (StudentTakesCourse takes in sTakes)
            {
                ListViewItem item = new ListViewItem();
                item.Text = index.ToString();
                item.SubItems.Add(takes.SName);
                item.SubItems.Add(takes.SRoll);
                item.SubItems.Add(takes.CId);
                item.SubItems.Add(takes.CName);
                item.SubItems.Add(takes.CCredit.ToString());
                item.SubItems.Add(takes.EnrollDate.ToString("dd/MM/yyyy"));
                item.Tag = takes;

                takesCourseListView.Items.Add(item);
                index++;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            rollComboBox.SelectedIndex = 0;
            courseComboBox.SelectedIndex = 0;
            enrollDateTimePicker.Value = DateTime.Now;
        }
    }
}
