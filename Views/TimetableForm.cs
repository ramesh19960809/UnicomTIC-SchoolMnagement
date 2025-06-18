using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTIC_SchoolMnagement.Models;

namespace UnicomTICManagementSystem
{
    public partial class TimetableForm : Form
    {
        private readonly TimetableController controller = new TimetableController();

        public TimetableForm()
        {
            InitializeComponent();
            LoadTimetables();
        }

        private void LoadTimetables()
        {
            dgvTimetables.DataSource = controller.GetAllTimetables();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimeTable timetable = new TimeTable
            {
                CourseID = Convert.ToInt32(txtCourseID.Text),
                SubjectID = Convert.ToInt32(txtSubjectID.Text),
                RoomID = Convert.ToInt32(txtRoomID.Text)
            };

            if (controller.AddTimetable(timetable))
            {
                MessageBox.Show("Timetable added successfully.");
                LoadTimetables();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to add timetable.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTimetableID.Text, out int id))
            {
                TimeTable timetable = new TimeTable
                {
                    TimetableID = id,
                    CourseID = Convert.ToInt32(txtCourseID.Text),
                    SubjectID = Convert.ToInt32(txtSubjectID.Text),
                    RoomID = Convert.ToInt32(txtRoomID.Text)
                };

                if (controller.UpdateTimetable(timetable))
                {
                    MessageBox.Show("Timetable updated.");
                    LoadTimetables();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTimetableID.Text, out int id))
            {
                if (controller.DeleteTimetable(id))
                {
                    MessageBox.Show("Deleted successfully.");
                    LoadTimetables();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }

        private void dgvTimetables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTimetables.Rows[e.RowIndex];
                txtTimetableID.Text = row.Cells["TimetableID"].Value.ToString();
                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                txtSubjectID.Text = row.Cells["SubjectID"].Value.ToString();
                txtRoomID.Text = row.Cells["RoomID"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtTimetableID.Clear();
            txtCourseID.Clear();
            txtSubjectID.Clear();
            txtRoomID.Clear();
        }
    }
}
