namespace EkspertniSistem
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
            this.gbUnosPod = new System.Windows.Forms.GroupBox();
            this.mtbDatumRodjenja = new System.Windows.Forms.MaskedTextBox();
            this.tbTezina = new System.Windows.Forms.TextBox();
            this.tbVisina = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.snimi = new System.Windows.Forms.Button();
            this.gbUnosPod.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUnosPod
            // 
            this.gbUnosPod.Controls.Add(this.mtbDatumRodjenja);
            this.gbUnosPod.Controls.Add(this.tbTezina);
            this.gbUnosPod.Controls.Add(this.tbVisina);
            this.gbUnosPod.Controls.Add(this.tbPrezime);
            this.gbUnosPod.Controls.Add(this.tbIme);
            this.gbUnosPod.Controls.Add(this.label5);
            this.gbUnosPod.Controls.Add(this.label4);
            this.gbUnosPod.Controls.Add(this.label3);
            this.gbUnosPod.Controls.Add(this.label2);
            this.gbUnosPod.Controls.Add(this.label1);
            this.gbUnosPod.Location = new System.Drawing.Point(12, 12);
            this.gbUnosPod.Name = "gbUnosPod";
            this.gbUnosPod.Size = new System.Drawing.Size(597, 559);
            this.gbUnosPod.TabIndex = 0;
            this.gbUnosPod.TabStop = false;
            this.gbUnosPod.Text = "Unesite podatke sportiste";
            // 
            // mtbDatumRodjenja
            // 
            this.mtbDatumRodjenja.Location = new System.Drawing.Point(141, 115);
            this.mtbDatumRodjenja.Mask = "00.00.0000";
            this.mtbDatumRodjenja.Name = "mtbDatumRodjenja";
            this.mtbDatumRodjenja.Size = new System.Drawing.Size(177, 20);
            this.mtbDatumRodjenja.TabIndex = 11;
            this.mtbDatumRodjenja.ValidatingType = typeof(System.DateTime);
            // 
            // tbTezina
            // 
            this.tbTezina.Location = new System.Drawing.Point(141, 205);
            this.tbTezina.Name = "tbTezina";
            this.tbTezina.Size = new System.Drawing.Size(177, 20);
            this.tbTezina.TabIndex = 9;
            this.tbTezina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTezina_KeyPress);
            // 
            // tbVisina
            // 
            this.tbVisina.Location = new System.Drawing.Point(141, 163);
            this.tbVisina.Name = "tbVisina";
            this.tbVisina.Size = new System.Drawing.Size(177, 20);
            this.tbVisina.TabIndex = 8;
            this.tbVisina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVisina_KeyPress);
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(141, 75);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(177, 20);
            this.tbPrezime.TabIndex = 6;
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(141, 37);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(177, 20);
            this.tbIme.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Težina(kg)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Visina(cm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum Rođenja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // snimi
            // 
            this.snimi.Location = new System.Drawing.Point(491, 577);
            this.snimi.Name = "snimi";
            this.snimi.Size = new System.Drawing.Size(118, 23);
            this.snimi.TabIndex = 3;
            this.snimi.Text = "Snimi podatke";
            this.snimi.UseVisualStyleBackColor = true;
            this.snimi.Click += new System.EventHandler(this.snimi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 615);
            this.Controls.Add(this.snimi);
            this.Controls.Add(this.gbUnosPod);
            this.Name = "Form1";
            this.Text = "Motorika Tela - Identifikacija rizika od povredjivanja";
            this.gbUnosPod.ResumeLayout(false);
            this.gbUnosPod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUnosPod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTezina;
        private System.Windows.Forms.TextBox tbVisina;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Button snimi;
        private System.Windows.Forms.MaskedTextBox mtbDatumRodjenja;
    }
}

