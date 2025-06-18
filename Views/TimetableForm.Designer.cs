namespace UnicomTICManagementSystem
{
    partial class TimetableForm
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

        private void InitializeComponent()
        {
            this.lblTimetableID = new System.Windows.Forms.Label();
            this.txtTimetableID = new System.Windows.Forms.TextBox();
            this.lblCourseID = new System.Windows.Forms.Label();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.lblSubjectID = new System.Windows.Forms.Label();
            this.txtSubjectID = new System.Windows.Forms.TextBox();
            this.lblRoomID = new System.Windows.Forms.Label();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvTimetables = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetables)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimetableID
            // 
            this.lblTimetableID.AutoSize = true;
            this.lblTimetableID.Location = new System.Drawing.Point(30, 25);
            this.lblTimetableID.Name = "lblTimetableID";
            this.lblTimetableID.Size = new System.Drawing.Size(74, 13);
            this.lblTimetableID.TabIndex = 0;
            this.lblTimetableID.Text = "Timetable ID:";
            // 
            // txtTimetableID
            // 
            this.txtTimetableID.Location = new System.Drawing.Point(130, 22);
            this.txtTimetableID.Name = "txtTimetableID";
            this.txtTimetableID.Size = new System.Drawing.Size(150, 20);
            this.txtTimetableID.TabIndex = 1;
            // 
            // lblCourseID
            // 
            this.lblCourseID.AutoSize = true;
            this.lblCourseID.Location = new System.Drawing.Point(30, 65);
            this.lblCourseID.Name = "lblCourseID";
            this.lblCourseID.Size = new System.Drawing.Size(58, 13);
            this.lblCourseID.TabIndex = 2;
            this.lblCourseID.Text = "Course ID:";
            // 
            // txtCourseID
            // 
            this.txtCourseID.Location = new System.Drawing.Point(130, 62);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(150, 20);
            this.txtCourseID.TabIndex = 3;
            // 
            // lblSubjectID
            // 
            this.lblSubjectID.AutoSize = true;
            this.lblSubjectID.Location = new System.Drawing.Point(30, 105);
            this.lblSubjectID.Name = "lblSubjectID";
            this.lblSubjectID.Size = new System.Drawing.Size(60, 13);
            this.lblSubjectID.TabIndex = 4;
            this.lblSubjectID.Text = "Subject ID:";
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.Location = new System.Drawing.Point(130, 102);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(150, 20);
            this.txtSubjectID.TabIndex = 5;
            // 
            // lblRoomID
            // 
            this.lblRoomID.AutoSize = true;
            this.lblRoomID.Location = new System.Drawing.Point(30, 145);
            this.lblRoomID.Name = "lblRoomID";
            this.lblRoomID.Size = new System.Drawing.Size(53, 13);
            this.lblRoomID.TabIndex = 6;
            this.lblRoomID.Text = "Room ID:";
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(130, 142);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(150, 20);
            this.txtRoomID.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(130, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(230, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvTimetables
            // 
            this.dgvTimetables.AllowUserToAddRows = false;
            this.dgvTimetables.AllowUserToDeleteRows = false;
            this.dgvTimetables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimetables.Location = new System.Drawing.Point(30, 240);
            this.dgvTimetables.MultiSelect = false;
            this.dgvTimetables.Name = "dgvTimetables";
            this.dgvTimetables.ReadOnly = true;
            this.dgvTimetables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimetables.Size = new System.Drawing.Size(500, 200);
            this.dgvTimetables.TabIndex = 11;
            this.dgvTimetables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimetables_CellClick);
            // 
            // TimetableForm
            // 
            this.ClientSize = new System.Drawing.Size(580, 460);
            this.Controls.Add(this.dgvTimetables);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtRoomID);
            this.Controls.Add(this.lblRoomID);
            this.Controls.Add(this.txtSubjectID);
            this.Controls.Add(this.lblSubjectID);
            this.Controls.Add(this.txtCourseID);
            this.Controls.Add(this.lblCourseID);
            this.Controls.Add(this.txtTimetableID);
            this.Controls.Add(this.lblTimetableID);
            this.Name = "TimetableForm";
            this.Text = "Timetable Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimetables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimetableID;
        private System.Windows.Forms.TextBox txtTimetableID;
        private System.Windows.Forms.Label lblCourseID;
        private System.Windows.Forms.TextBox txtCourseID;
        private System.Windows.Forms.Label lblSubjectID;
        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvTimetables;
    }
}
