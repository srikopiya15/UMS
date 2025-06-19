namespace UnicomTICManagementSystem.View
{
    partial class CourseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_btn = new System.Windows.Forms.Button();
            this.course_combo = new System.Windows.Forms.ComboBox();
            this.dvg_course = new System.Windows.Forms.DataGridView();
            this.update_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.startdate_pick = new System.Windows.Forms.DateTimePicker();
            this.enddate_pick = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_course)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(147, 173);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(101, 27);
            this.add_btn.TabIndex = 3;
            this.add_btn.Text = "Add";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // course_combo
            // 
            this.course_combo.FormattingEnabled = true;
            this.course_combo.Items.AddRange(new object[] {
            "Diploma in IT",
            "Diploma in English",
            "Diploma in Singala"});
            this.course_combo.Location = new System.Drawing.Point(213, 54);
            this.course_combo.Name = "course_combo";
            this.course_combo.Size = new System.Drawing.Size(225, 21);
            this.course_combo.TabIndex = 7;
            this.course_combo.SelectedIndexChanged += new System.EventHandler(this.course_combo_SelectedIndexChanged);
            // 
            // dvg_course
            // 
            this.dvg_course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_course.Location = new System.Drawing.Point(96, 205);
            this.dvg_course.Name = "dvg_course";
            this.dvg_course.Size = new System.Drawing.Size(445, 177);
            this.dvg_course.TabIndex = 8;
            this.dvg_course.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvg_course_CellContentClick);
            // 
            // update_btn
            // 
            this.update_btn.Location = new System.Drawing.Point(254, 173);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(101, 27);
            this.update_btn.TabIndex = 9;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(372, 174);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(92, 26);
            this.delete_btn.TabIndex = 10;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // startdate_pick
            // 
            this.startdate_pick.Location = new System.Drawing.Point(213, 92);
            this.startdate_pick.Name = "startdate_pick";
            this.startdate_pick.Size = new System.Drawing.Size(225, 20);
            this.startdate_pick.TabIndex = 11;
            // 
            // enddate_pick
            // 
            this.enddate_pick.Location = new System.Drawing.Point(213, 129);
            this.enddate_pick.Name = "enddate_pick";
            this.enddate_pick.Size = new System.Drawing.Size(225, 20);
            this.enddate_pick.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Manage Course";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 385);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enddate_pick);
            this.Controls.Add(this.startdate_pick);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.dvg_course);
            this.Controls.Add(this.course_combo);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_course)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.ComboBox course_combo;
        private System.Windows.Forms.DataGridView dvg_course;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.DateTimePicker startdate_pick;
        private System.Windows.Forms.DateTimePicker enddate_pick;
        private System.Windows.Forms.Label label4;
    }
}