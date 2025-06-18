using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private CourseController _controller;

        public CourseForm()
        {
            InitializeComponent();
            _controller = new CourseController();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCoursesToGrid();
            ClearFields();
        }

        private void LoadCoursesToGrid()
        {
            List<Course> courses = _controller.GetAllCourses();
            dgvCourses.DataSource = null;
            dgvCourses.DataSource = courses;
        }

        private void ClearFields()
        {
            txtCourseID.Text = "";
            txtCourseName.Text = "";
            txtDescription.Text = "";
            txtDuration.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter course name");
                return;
            }

            Course course = new Course
            {
                CourseName = txtCourseName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DurationMonths = int.TryParse(txtDuration.Text, out int dur) ? dur : 0
            };

            bool result = _controller.AddCourse(course);
            if (result)
            {
                MessageBox.Show("Course added successfully!");
                LoadCoursesToGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add course.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter course name");
                return;
            }

            Course course = new Course
            {
                CourseId = int.Parse(txtCourseID.Text),
                CourseName = txtCourseName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                DurationMonths = int.TryParse(txtDuration.Text, out int dur) ? dur : 0
            };

            bool result = _controller.UpdateCourse(course);
            if (result)
            {
                MessageBox.Show("Course updated successfully!");
                LoadCoursesToGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to update course.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            int courseId = int.Parse(txtCourseID.Text);
            var confirm = MessageBox.Show("Are you sure to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool result = _controller.DeleteCourse(courseId);
                if (result)
                {
                    MessageBox.Show("Course deleted successfully!");
                    LoadCoursesToGrid();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete course.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                txtCourseID.Text = row.Cells["CourseId"].Value.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                txtDuration.Text = row.Cells["DurationMonths"].Value.ToString();
            }
        }
    }
}
