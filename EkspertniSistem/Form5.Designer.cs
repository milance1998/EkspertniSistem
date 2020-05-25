namespace EkspertniSistem
{
    partial class Form5
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnDalje = new System.Windows.Forms.Button();
            this.rbPovredjen = new System.Windows.Forms.RadioButton();
            this.rbNePovredjen = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnDalje);
            this.groupBox10.Controls.Add(this.rbPovredjen);
            this.groupBox10.Controls.Add(this.rbNePovredjen);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(5, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(585, 135);
            this.groupBox10.TabIndex = 35;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Stanje sportiste";
            // 
            // btnDalje
            // 
            this.btnDalje.Location = new System.Drawing.Point(503, 112);
            this.btnDalje.Name = "btnDalje";
            this.btnDalje.Size = new System.Drawing.Size(75, 23);
            this.btnDalje.TabIndex = 14;
            this.btnDalje.Text = "Dalje";
            this.btnDalje.UseVisualStyleBackColor = true;
            this.btnDalje.Click += new System.EventHandler(this.btnDalje_Click);
            // 
            // rbPovredjen
            // 
            this.rbPovredjen.AutoSize = true;
            this.rbPovredjen.BackColor = System.Drawing.SystemColors.Control;
            this.rbPovredjen.Location = new System.Drawing.Point(42, 43);
            this.rbPovredjen.Name = "rbPovredjen";
            this.rbPovredjen.Size = new System.Drawing.Size(80, 17);
            this.rbPovredjen.TabIndex = 12;
            this.rbPovredjen.TabStop = true;
            this.rbPovredjen.Text = "Povređen";
            this.rbPovredjen.UseVisualStyleBackColor = false;
            // 
            // rbNePovredjen
            // 
            this.rbNePovredjen.AutoSize = true;
            this.rbNePovredjen.BackColor = System.Drawing.SystemColors.Control;
            this.rbNePovredjen.Location = new System.Drawing.Point(128, 43);
            this.rbNePovredjen.Name = "rbNePovredjen";
            this.rbNePovredjen.Size = new System.Drawing.Size(99, 17);
            this.rbNePovredjen.TabIndex = 13;
            this.rbNePovredjen.TabStop = true;
            this.rbNePovredjen.Text = "Ne povređen";
            this.rbNePovredjen.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Trenutno stanje sportiste:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 155);
            this.Controls.Add(this.groupBox10);
            this.Name = "Form5";
            this.Text = "Motorika Tela";
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnDalje;
        private System.Windows.Forms.RadioButton rbPovredjen;
        private System.Windows.Forms.RadioButton rbNePovredjen;
        private System.Windows.Forms.Label label1;
    }
}