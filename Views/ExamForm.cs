using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.Models;
using StudentManagementSystem.Controllers;

namespace StudentManagementSystem
{
    public partial class ExamForm : Form
    {
        private readonly ExamController controller = new ExamController();

        public ExamForm()
        {
            InitializeComponent();
            LoadExamsAsync();
        }

        private async void LoadExamsAsync()
        {
            List<Exam> exams = await controller.GetAllExamsAsync();
            dgvExams.DataSource = exams;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Exam exam = new Exam
            {
                CourseID = int.Parse(txtCourseID.Text),
                ExamDate = dtpExamDate.Value,
                ExamType = txtExamType.Text
            };

            if (await controller.AddExamAsync(exam))
            {
                MessageBox.Show("Exam added.");
                LoadExamsAsync();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Add failed.");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Exam exam = new Exam
            {
                ExamID = int.Parse(txtExamID.Text),
                CourseID = int.Parse(txtCourseID.Text),
                ExamDate = dtpExamDate.Value,
                ExamType = txtExamType.Text
            };

            if (await controller.UpdateExamAsync(exam))
            {
                MessageBox.Show("Updated successfully.");
                LoadExamsAsync();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtExamID.Text);
            if (await controller.DeleteExamAsync(id))
            {
                MessageBox.Show("Deleted successfully.");
                LoadExamsAsync();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Delete failed.");
            }
        }

        private void dgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvExams.Rows[e.RowIndex];
                txtExamID.Text = row.Cells["ExamID"].Value.ToString();
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                dtpExamDate.Value = Convert.ToDateTime(row.Cells["ExamDate"].Value);
                txtExamType.Text = row.Cells["ExamType"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtExamID.Clear();
            txtCourseID.Clear();
            txtExamType.Clear();
            dtpExamDate.Value = DateTime.Today;
        }
    }
}
