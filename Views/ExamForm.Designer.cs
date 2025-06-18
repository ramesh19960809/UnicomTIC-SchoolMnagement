namespace StudentManagementSystem
{
    partial class ExamForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblExamID = new System.Windows.Forms.Label();
            this.txtExamID = new System.Windows.Forms.TextBox();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.lblExamDate = new System.Windows.Forms.Label();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.lblExamType = new System.Windows.Forms.Label();
            this.txtExamType = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvExams = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.SuspendLayout();

            // lblExamID
            this.lblExamID.AutoSize = true;
            this.lblExamID.Location = new System.Drawing.Point(30, 30);
            this.lblExamID.Name = "lblExamID";
            this.lblExamID.Size = new System.Drawing.Size(52, 15);
            this.lblExamID.Text = "Exam ID";

            // txtExamID
            this.txtExamID.Location = new System.Drawing.Point(120, 27);
            this.txtExamID.Name = "txtExamID";
            this.txtExamID.Size = new System.Drawing.Size(200, 23);

            // lblCourseID
            this.lblCourseID.AutoSize = true;
            this.lblCourseID.Location = new System.Drawing.Point(30, 70);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(61, 15);
            this.lblCourseID.Text = "Course ID";

            // txtCourseID
            this.txtCourseID.Location = new System.Drawing.Point(120, 67);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(200, 23);

            // lblExamDate
            this.lblExamDate.AutoSize = true;
            this.lblExamDate.Location = new System.Drawing.Point(30, 110);
            this.lblExamDate.Name = "lblExamDate";
            this.lblExamDate.Size = new System.Drawing.Size(65, 15);
            this.lblExamDate.Text = "Exam Date";

            // dtpExamDate
            this.dtpExamDate.Location = new System.Drawing.Point(120, 107);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(200, 23);

            // lblExamType
            this.lblExamType.AutoSize = true;
            this.lblExamType.Location = new System.Drawing.Point(30, 150);
            this.lblExamType.Name = "lblExamType";
            this.lblExamType.Size = new System.Drawing.Size(67, 15);
            this.lblExamType.Text = "Exam Type";

            // txtExamType
            this.txtExamType.Location = new System.Drawing.Point(120, 147);
            this.txtExamType.Name = "txtExamType";
            this.txtExamType.Size = new System.Drawing.Size(200, 23);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(30, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(130, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(230, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // dgvExams
            this.dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExams.Location = new System.Drawing.Point(30, 240);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.RowTemplate.Height = 25;
            this.dgvExams.Size = new System.Drawing.Size(500, 200);
            this.dgvExams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExams_CellClick);

            // ExamForm
            this.ClientSize = new System.Drawing.Size(580, 470);
            this.Controls.Add(this.lblExamID);
            this.Controls.Add(this.txtExamID);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.lblExamDate);
            this.Controls.Add(this.dtpExamDate);
            this.Controls.Add(this.lblExamType);
            this.Controls.Add(this.txtExamType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvExams);
            this.Name = "ExamForm";
            this.Text = "Exam Management";

            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblExamID;
        private System.Windows.Forms.TextBox txtExamID;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.Label lblExamDate;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.Label lblExamType;
        private System.Windows.Forms.TextBox txtExamType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvExams;
    }
}
