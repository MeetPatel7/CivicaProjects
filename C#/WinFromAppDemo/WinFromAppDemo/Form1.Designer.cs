namespace WinFromAppDemo
{
    partial class textvalu1
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.TextBox();
            this.text2 = new System.Windows.Forms.TextBox();
            this.textanswer = new System.Windows.Forms.TextBox();
            this.badd = new System.Windows.Forms.Button();
            this.bsub = new System.Windows.Forms.Button();
            this.bmul = new System.Windows.Forms.Button();
            this.bdiv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "First Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Second Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Answer";
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(238, 64);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(100, 20);
            this.text1.TabIndex = 3;
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(238, 98);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(100, 20);
            this.text2.TabIndex = 4;
            // 
            // textanswer
            // 
            this.textanswer.Location = new System.Drawing.Point(238, 132);
            this.textanswer.Name = "textanswer";
            this.textanswer.Size = new System.Drawing.Size(100, 20);
            this.textanswer.TabIndex = 5;
            // 
            // badd
            // 
            this.badd.Location = new System.Drawing.Point(113, 178);
            this.badd.Name = "badd";
            this.badd.Size = new System.Drawing.Size(75, 23);
            this.badd.TabIndex = 6;
            this.badd.Text = "Add";
            this.badd.UseVisualStyleBackColor = true;
            this.badd.Click += new System.EventHandler(this.badd_Click_1);
            // 
            // bsub
            // 
            this.bsub.Location = new System.Drawing.Point(206, 178);
            this.bsub.Name = "bsub";
            this.bsub.Size = new System.Drawing.Size(75, 23);
            this.bsub.TabIndex = 7;
            this.bsub.Text = "Sub";
            this.bsub.UseVisualStyleBackColor = true;
            this.bsub.Click += new System.EventHandler(this.bsub_Click_1);
            // 
            // bmul
            // 
            this.bmul.Location = new System.Drawing.Point(297, 178);
            this.bmul.Name = "bmul";
            this.bmul.Size = new System.Drawing.Size(75, 23);
            this.bmul.TabIndex = 8;
            this.bmul.Text = "Mul";
            this.bmul.UseVisualStyleBackColor = true;
            this.bmul.Click += new System.EventHandler(this.bmul_Click_1);
            // 
            // bdiv
            // 
            this.bdiv.Location = new System.Drawing.Point(389, 178);
            this.bdiv.Name = "bdiv";
            this.bdiv.Size = new System.Drawing.Size(75, 23);
            this.bdiv.TabIndex = 9;
            this.bdiv.Text = "Div";
            this.bdiv.UseVisualStyleBackColor = true;
            this.bdiv.Click += new System.EventHandler(this.bdiv_Click_1);
            // 
            // textvalu1
            // 
            this.ClientSize = new System.Drawing.Size(521, 261);
            this.Controls.Add(this.bdiv);
            this.Controls.Add(this.bmul);
            this.Controls.Add(this.bsub);
            this.Controls.Add(this.badd);
            this.Controls.Add(this.textanswer);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "textvalu1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textvalue1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textvalue2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textans;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnmul;
        private System.Windows.Forms.Button btndiv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.TextBox textanswer;
        private System.Windows.Forms.Button badd;
        private System.Windows.Forms.Button bsub;
        private System.Windows.Forms.Button bmul;
        private System.Windows.Forms.Button bdiv;
    }
}

