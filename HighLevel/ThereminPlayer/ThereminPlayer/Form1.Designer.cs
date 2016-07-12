namespace ThereminPlayer
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioHalfPitch = new System.Windows.Forms.RadioButton();
            this.radioFullPitch = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(31, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "DROP THE MOTHERFUCKING BASE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Snow;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(31, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(335, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "STOP THE MOTHERFUCKING BASE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioHalfPitch
            // 
            this.radioHalfPitch.AutoSize = true;
            this.radioHalfPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioHalfPitch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioHalfPitch.Location = new System.Drawing.Point(97, 21);
            this.radioHalfPitch.Name = "radioHalfPitch";
            this.radioHalfPitch.Size = new System.Drawing.Size(86, 17);
            this.radioHalfPitch.TabIndex = 2;
            this.radioHalfPitch.Text = "HALF PITCH";
            this.radioHalfPitch.UseVisualStyleBackColor = true;
            this.radioHalfPitch.CheckedChanged += new System.EventHandler(this.radioHalfPitch_CheckedChanged);
            // 
            // radioFullPitch
            // 
            this.radioFullPitch.AutoSize = true;
            this.radioFullPitch.Checked = true;
            this.radioFullPitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioFullPitch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioFullPitch.Location = new System.Drawing.Point(9, 21);
            this.radioFullPitch.Name = "radioFullPitch";
            this.radioFullPitch.Size = new System.Drawing.Size(85, 17);
            this.radioFullPitch.TabIndex = 3;
            this.radioFullPitch.TabStop = true;
            this.radioFullPitch.Text = "FULL PITCH";
            this.radioFullPitch.UseVisualStyleBackColor = true;
            this.radioFullPitch.CheckedChanged += new System.EventHandler(this.radioFullPitch_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(246, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.radioFullPitch);
            this.groupBox1.Controls.Add(this.radioHalfPitch);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(31, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PITCH";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox2.Location = new System.Drawing.Point(246, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "SOUND";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(395, 201);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioHalfPitch;
        private System.Windows.Forms.RadioButton radioFullPitch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

