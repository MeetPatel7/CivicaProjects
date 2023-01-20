namespace ReadWriteFileDemo
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
            this.btninsert = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.readtext = new System.Windows.Forms.TextBox();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnmul = new System.Windows.Forms.Button();
            this.btndiv = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnwrite = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.forfilebtntext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btninsert
            // 
            this.btninsert.Location = new System.Drawing.Point(213, 468);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(75, 39);
            this.btninsert.TabIndex = 0;
            this.btninsert.Text = "Add";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(330, 200);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 32);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "first value";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(330, 249);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(385, 26);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "second value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Read Text";
            // 
            // readtext
            // 
            this.readtext.Location = new System.Drawing.Point(330, 287);
            this.readtext.Multiline = true;
            this.readtext.Name = "readtext";
            this.readtext.Size = new System.Drawing.Size(385, 159);
            this.readtext.TabIndex = 6;
            this.readtext.TextChanged += new System.EventHandler(this.readtext_TextChanged);
            // 
            // btnsub
            // 
            this.btnsub.Location = new System.Drawing.Point(342, 468);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(75, 39);
            this.btnsub.TabIndex = 7;
            this.btnsub.Text = "Sub";
            this.btnsub.UseVisualStyleBackColor = true;
            this.btnsub.Click += new System.EventHandler(this.btnsub_Click);
            // 
            // btnmul
            // 
            this.btnmul.Location = new System.Drawing.Point(468, 468);
            this.btnmul.Name = "btnmul";
            this.btnmul.Size = new System.Drawing.Size(75, 39);
            this.btnmul.TabIndex = 8;
            this.btnmul.Text = "Mul";
            this.btnmul.UseVisualStyleBackColor = true;
            this.btnmul.Click += new System.EventHandler(this.btnmul_Click);
            // 
            // btndiv
            // 
            this.btndiv.Location = new System.Drawing.Point(592, 468);
            this.btndiv.Name = "btndiv";
            this.btndiv.Size = new System.Drawing.Size(75, 39);
            this.btndiv.TabIndex = 9;
            this.btndiv.Text = "Div";
            this.btndiv.UseVisualStyleBackColor = true;
            this.btndiv.Click += new System.EventHandler(this.btndiv_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnwrite
            // 
            this.btnwrite.Location = new System.Drawing.Point(330, 123);
            this.btnwrite.Name = "btnwrite";
            this.btnwrite.Size = new System.Drawing.Size(103, 34);
            this.btnwrite.TabIndex = 11;
            this.btnwrite.Text = "Write File";
            this.btnwrite.UseVisualStyleBackColor = true;
            this.btnwrite.Click += new System.EventHandler(this.btnwrite_Click);
            // 
            // btnread
            // 
            this.btnread.Location = new System.Drawing.Point(468, 123);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(101, 34);
            this.btnread.TabIndex = 12;
            this.btnread.Text = "Read File";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(610, 123);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(105, 34);
            this.btndelete.TabIndex = 13;
            this.btndelete.Text = "Delete File";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // forfilebtntext
            // 
            this.forfilebtntext.Location = new System.Drawing.Point(333, 27);
            this.forfilebtntext.Multiline = true;
            this.forfilebtntext.Name = "forfilebtntext";
            this.forfilebtntext.Size = new System.Drawing.Size(382, 75);
            this.forfilebtntext.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "For File Buttons";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 519);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.forfilebtntext);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnread);
            this.Controls.Add(this.btnwrite);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btndiv);
            this.Controls.Add(this.btnmul);
            this.Controls.Add(this.btnsub);
            this.Controls.Add(this.readtext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btninsert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox readtext;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnmul;
        private System.Windows.Forms.Button btndiv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnwrite;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox forfilebtntext;
        private System.Windows.Forms.Label label4;
    }
}

