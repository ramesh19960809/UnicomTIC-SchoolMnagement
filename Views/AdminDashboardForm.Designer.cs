namespace UnicomTIC_SchoolMnagement.Views
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnStudents = new Button();
            btnCourses = new Button();
            btnExams = new Button();
            btnMarks = new Button();
            btnTimetables = new Button();
            btnUsers = new Button();
            btnLogout = new Button();
            pictureBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(316, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Dashboard";
            // 
            // btnStudents
            // 
            btnStudents.Location = new Point(176, 134);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(75, 23);
            btnStudents.TabIndex = 1;
            btnStudents.Text = "Manage Students";
            btnStudents.UseVisualStyleBackColor = true;
            // 
            // btnCourses
            // 
            btnCourses.Location = new Point(316, 134);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(75, 23);
            btnCourses.TabIndex = 2;
            btnCourses.Text = "Manage Courses";
            btnCourses.UseVisualStyleBackColor = true;
            // 
            // btnExams
            // 
            btnExams.Location = new Point(437, 134);
            btnExams.Name = "btnExams";
            btnExams.Size = new Size(75, 23);
            btnExams.TabIndex = 3;
            btnExams.Text = "Manage Exams";
            btnExams.UseVisualStyleBackColor = true;
            // 
            // btnMarks
            // 
            btnMarks.Location = new Point(176, 193);
            btnMarks.Name = "btnMarks";
            btnMarks.Size = new Size(75, 23);
            btnMarks.TabIndex = 4;
            btnMarks.Text = "Manage Marks";
            btnMarks.UseVisualStyleBackColor = true;
            // 
            // btnTimetables
            // 
            btnTimetables.Location = new Point(316, 193);
            btnTimetables.Name = "btnTimetables";
            btnTimetables.Size = new Size(75, 23);
            btnTimetables.TabIndex = 5;
            btnTimetables.Text = "Manage Timetables";
            btnTimetables.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(437, 193);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(75, 23);
            btnUsers.TabIndex = 6;
            btnUsers.Text = "\tManage Users";
            btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(316, 272);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(419, 370);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(100, 50);
            pictureBoxLogo.TabIndex = 8;
            pictureBoxLogo.TabStop = false;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxLogo);
            Controls.Add(btnLogout);
            Controls.Add(btnUsers);
            Controls.Add(btnTimetables);
            Controls.Add(btnMarks);
            Controls.Add(btnExams);
            Controls.Add(btnCourses);
            Controls.Add(btnStudents);
            Controls.Add(lblTitle);
            Name = "AdminDashboardForm";
            Text = "AdminDashboardForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnStudents;
        private Button btnCourses;
        private Button btnExams;
        private Button btnMarks;
        private Button btnTimetables;
        private Button btnUsers;
        private Button btnLogout;
        private PictureBox pictureBoxLogo;
    }
}