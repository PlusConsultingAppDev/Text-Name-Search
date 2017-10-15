namespace TextNameSearchApp
{
    partial class Form1
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
            this.lstBxEmployees = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.txtBxLastName = new System.Windows.Forms.TextBox();
            this.txtBxMiddleName = new System.Windows.Forms.TextBox();
            this.txtBxFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxArticleText = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();
            this.btnSearchArticle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Article Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search Results";
            // 
            // lstBxEmployees
            // 
            this.lstBxEmployees.FormattingEnabled = true;
            this.lstBxEmployees.Location = new System.Drawing.Point(13, 30);
            this.lstBxEmployees.Name = "lstBxEmployees";
            this.lstBxEmployees.Size = new System.Drawing.Size(265, 381);
            this.lstBxEmployees.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddEmployee);
            this.groupBox1.Controls.Add(this.txtBxLastName);
            this.groupBox1.Controls.Add(this.txtBxMiddleName);
            this.groupBox1.Controls.Add(this.txtBxFirstName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 236);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(156, 194);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(102, 23);
            this.btnAddEmployee.TabIndex = 6;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // txtBxLastName
            // 
            this.txtBxLastName.Location = new System.Drawing.Point(10, 152);
            this.txtBxLastName.Name = "txtBxLastName";
            this.txtBxLastName.Size = new System.Drawing.Size(249, 20);
            this.txtBxLastName.TabIndex = 5;
            // 
            // txtBxMiddleName
            // 
            this.txtBxMiddleName.Location = new System.Drawing.Point(10, 94);
            this.txtBxMiddleName.Name = "txtBxMiddleName";
            this.txtBxMiddleName.Size = new System.Drawing.Size(248, 20);
            this.txtBxMiddleName.TabIndex = 4;
            // 
            // txtBxFirstName
            // 
            this.txtBxFirstName.Location = new System.Drawing.Point(10, 37);
            this.txtBxFirstName.Name = "txtBxFirstName";
            this.txtBxFirstName.Size = new System.Drawing.Size(248, 20);
            this.txtBxFirstName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Middle Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "First Name";
            // 
            // txtBxArticleText
            // 
            this.txtBxArticleText.Location = new System.Drawing.Point(296, 30);
            this.txtBxArticleText.Multiline = true;
            this.txtBxArticleText.Name = "txtBxArticleText";
            this.txtBxArticleText.Size = new System.Drawing.Size(323, 624);
            this.txtBxArticleText.TabIndex = 5;
            // 
            // lblSearchResults
            // 
            this.lblSearchResults.AutoSize = true;
            this.lblSearchResults.Location = new System.Drawing.Point(632, 137);
            this.lblSearchResults.Name = "lblSearchResults";
            this.lblSearchResults.Size = new System.Drawing.Size(13, 13);
            this.lblSearchResults.TabIndex = 6;
            this.lblSearchResults.Text = "--";
            // 
            // btnSearchArticle
            // 
            this.btnSearchArticle.Location = new System.Drawing.Point(635, 30);
            this.btnSearchArticle.Name = "btnSearchArticle";
            this.btnSearchArticle.Size = new System.Drawing.Size(315, 44);
            this.btnSearchArticle.TabIndex = 7;
            this.btnSearchArticle.Text = "Search Article";
            this.btnSearchArticle.UseVisualStyleBackColor = true;
            this.btnSearchArticle.Click += new System.EventHandler(this.btnSearchArticle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 667);
            this.Controls.Add(this.btnSearchArticle);
            this.Controls.Add(this.lblSearchResults);
            this.Controls.Add(this.txtBxArticleText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstBxEmployees);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Employee Article Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBxEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.TextBox txtBxLastName;
        private System.Windows.Forms.TextBox txtBxMiddleName;
        private System.Windows.Forms.TextBox txtBxFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxArticleText;
        private System.Windows.Forms.Label lblSearchResults;
        private System.Windows.Forms.Button btnSearchArticle;
    }
}

