namespace revcom_bot
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
        	this.BtnRun = new System.Windows.Forms.Button();
        	this.button1 = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.button2 = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// BtnRun
        	// 
        	this.BtnRun.Location = new System.Drawing.Point(12, 110);
        	this.BtnRun.Name = "BtnRun";
        	this.BtnRun.Size = new System.Drawing.Size(395, 77);
        	this.BtnRun.TabIndex = 1;
        	this.BtnRun.Text = "Поехали";
        	this.BtnRun.UseVisualStyleBackColor = true;
        	this.BtnRun.Click += new System.EventHandler(this.BtnRunClick);
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(12, 193);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(395, 44);
        	this.button1.TabIndex = 2;
        	this.button1.Text = "ОСТАНОВИТЬ";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1Click);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.textBox2);
        	this.panel1.Controls.Add(this.button2);
        	this.panel1.Controls.Add(this.label1);
        	this.panel1.Controls.Add(this.textBox1);
        	this.panel1.Location = new System.Drawing.Point(12, 4);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(395, 100);
        	this.panel1.TabIndex = 3;
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(3, 45);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(100, 25);
        	this.button2.TabIndex = 2;
        	this.button2.Text = "ОБНОВИТЬ";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2Click);
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(3, 31);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(106, 23);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Стартовый бонус";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(3, 8);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(100, 20);
        	this.textBox1.TabIndex = 0;
        	// 
        	// textBox2
        	// 
        	this.textBox2.Location = new System.Drawing.Point(290, 8);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(100, 20);
        	this.textBox2.TabIndex = 3;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(414, 249);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.BtnRun);
        	this.Controls.Add(this.button1);
        	this.Name = "Form1";
        	this.Text = "ЗАПУСК";
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
}
}

