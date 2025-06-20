namespace UnicomTICManagementSystem.View
{
    partial class SubjectForm
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
            this.subject_txt = new System.Windows.Forms.TextBox();
            this.course_combo = new System.Windows.Forms.ComboBox();
            this.dgv_subject = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_subject)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // subject_txt
            // 
            this.subject_txt.Location = new System.Drawing.Point(286, 79);
            this.subject_txt.Name = "subject_txt";
            this.subject_txt.Size = new System.Drawing.Size(176, 20);
            this.subject_txt.TabIndex = 2;
            this.subject_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // course_combo
            // 
            this.course_combo.FormattingEnabled = true;
            this.course_combo.Items.AddRange(new object[] {
            "Diploma in IT",
            "Diploma in English",
            "Diploma in Singala"});
            this.course_combo.Location = new System.Drawing.Point(286, 127);
            this.course_combo.Name = "course_combo";
            this.course_combo.Size = new System.Drawing.Size(176, 21);
            this.course_combo.TabIndex = 3;
            this.course_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgv_subject
            // 
            this.dgv_subject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_subject.Location = new System.Drawing.Point(132, 221);
            this.dgv_subject.Name = "dgv_subject";
            this.dgv_subject.Size = new System.Drawing.Size(422, 186);
            this.dgv_subject.TabIndex = 4;
            this.dgv_subject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(197, 175);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(63, 28);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(313, 175);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(62, 28);
            this.btn_update.TabIndex = 6;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(416, 175);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(61, 28);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Manage Subject";
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgv_subject);
            this.Controls.Add(this.course_combo);
            this.Controls.Add(this.subject_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SubjectForm";
            this.Text = "SubjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_subject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subject_txt;
        private System.Windows.Forms.ComboBox course_combo;
        private System.Windows.Forms.DataGridView dgv_subject;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label3;
    }
}