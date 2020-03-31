using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Model;

namespace UniversityManagementSystem
{
    public partial class StudentUI : Form
    {
        private StudentManager studentManager = new StudentManager();
        private DepartmentManager departmentManager = new DepartmentManager();

        public StudentUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(departmentComboBox.SelectedValue) == -1)
            {
                MessageBox.Show("Please select your department");
                return;
            }
            Student student = new Student();
            student.Name = nameTextBox.Text;
            student.RollNo = rollNoTextBox.Text;
            student.DepartmentId = Convert.ToInt32(departmentComboBox.SelectedValue);
            student.Age = Convert.ToInt32(ageTextBox.Text);
            student.PhoneNo = phoneNoTextBox.Text;
            student.Email = emailTextBox.Text;

            if(saveButton.Text == "Save")
            {
                string message = studentManager.SaveStudent(student);
                MessageBox.Show(message);
            }
            else if(saveButton.Text == "Update")
            {
                string message = studentManager.UpdateStudent(student, Convert.ToInt32(hiddenIdLabel.Text));
                MessageBox.Show(message);
            }
          
            PopulateStudentListView(studentManager.GetAllStudents());
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            rollNoTextBox.Clear();
            departmentComboBox.SelectedIndex = 0;
            ageTextBox.Clear();
            phoneNoTextBox.Clear();
            emailTextBox.Clear();

            saveButton.Text = "Save";
            deleteButton.Enabled = false;
        }

        private void StudentUI_Load(object sender, EventArgs e)
        {
            Department defaultDepartment = new Department();
            defaultDepartment.Id = -1;
            defaultDepartment.Name = "--select--";

            List<Department> departments = departmentManager.GetAllDepartments();
            departments.Insert(0, defaultDepartment);

            departmentComboBox.DataSource = departments;
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";

            PopulateStudentListView(studentManager.GetAllStudents());
        }

        private void PopulateStudentListView(List<StudentWithDept> students)
        {
            studentListView.Items.Clear();

            int index = 1;
            foreach (StudentWithDept student in students)
            {
                ListViewItem item = new ListViewItem();
                item.Text = index.ToString();
                item.SubItems.Add(student.SName);
                item.SubItems.Add(student.SRollNo);
                item.SubItems.Add(student.SAge.ToString());
                item.SubItems.Add(student.DCode.ToString());
                item.SubItems.Add(student.SPhoneNo);
                item.SubItems.Add(student.SEmail);
                item.Tag = student;

                studentListView.Items.Add(item);
                index++;
            }
        }

        private void studentListView_DoubleClick(object sender, EventArgs e)
        {
            StudentWithDept student = (StudentWithDept)studentListView.SelectedItems[0].Tag;        //As doubleclick so one item will be there

            if(student != null)
            {
                nameTextBox.Text = student.SName;
                rollNoTextBox.Text = student.SRollNo;
                departmentComboBox.SelectedValue = student.DId;
                ageTextBox.Text = student.SAge.ToString();
                phoneNoTextBox.Text = student.SPhoneNo;
                emailTextBox.Text = student.SEmail;
                hiddenIdLabel.Text = student.SId.ToString();

                saveButton.Text = "Update";
                deleteButton.Enabled = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string message = "Are you sure?";
            string caption = "Delete Row";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                message = studentManager.DeleteStudent(Convert.ToInt32(hiddenIdLabel.Text));
                MessageBox.Show(message);

                PopulateStudentListView(studentManager.GetAllStudents());
                clearButton_Click(sender, e);
            }
            
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            PopulateStudentListView(studentManager.GetStudentsByName(searchTextBox.Text));
        }

    }
}
