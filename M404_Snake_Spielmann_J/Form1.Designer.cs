namespace M404_Snake_Spielmann_J
{
    partial class frmSnake
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
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlSpielfeld = new System.Windows.Forms.Panel();
            this.lblPunkte = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblPunkteliste = new System.Windows.Forms.Label();
            this.txtPunkte = new System.Windows.Forms.TextBox();
            this.txtCountdown = new System.Windows.Forms.TextBox();
            this.btnEintragen = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tmrCountdown = new System.Windows.Forms.Timer(this.components);
            this.tmrSpiel = new System.Windows.Forms.Timer(this.components);
            this.lblListMitPunkte = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(10, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(43, 20);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Text";
            // 
            // pnlSpielfeld
            // 
            this.pnlSpielfeld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlSpielfeld.Location = new System.Drawing.Point(10, 60);
            this.pnlSpielfeld.Name = "pnlSpielfeld";
            this.pnlSpielfeld.Size = new System.Drawing.Size(610, 500);
            this.pnlSpielfeld.TabIndex = 1;
            // 
            // lblPunkte
            // 
            this.lblPunkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunkte.Location = new System.Drawing.Point(620, 80);
            this.lblPunkte.Name = "lblPunkte";
            this.lblPunkte.Size = new System.Drawing.Size(100, 25);
            this.lblPunkte.TabIndex = 2;
            this.lblPunkte.Text = "Punkte:";
            this.lblPunkte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountdown
            // 
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(620, 150);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(110, 25);
            this.lblCountdown.TabIndex = 3;
            this.lblCountdown.Text = "Countdown:";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPunkteliste
            // 
            this.lblPunkteliste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunkteliste.Location = new System.Drawing.Point(620, 220);
            this.lblPunkteliste.Name = "lblPunkteliste";
            this.lblPunkteliste.Size = new System.Drawing.Size(110, 25);
            this.lblPunkteliste.TabIndex = 4;
            this.lblPunkteliste.Text = "Punkteliste:";
            this.lblPunkteliste.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPunkte
            // 
            this.txtPunkte.Enabled = false;
            this.txtPunkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPunkte.Location = new System.Drawing.Point(730, 80);
            this.txtPunkte.Name = "txtPunkte";
            this.txtPunkte.Size = new System.Drawing.Size(50, 26);
            this.txtPunkte.TabIndex = 5;
            // 
            // txtCountdown
            // 
            this.txtCountdown.Enabled = false;
            this.txtCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountdown.Location = new System.Drawing.Point(730, 150);
            this.txtCountdown.Name = "txtCountdown";
            this.txtCountdown.Size = new System.Drawing.Size(50, 26);
            this.txtCountdown.TabIndex = 6;
            // 
            // btnEintragen
            // 
            this.btnEintragen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEintragen.Location = new System.Drawing.Point(630, 470);
            this.btnEintragen.Name = "btnEintragen";
            this.btnEintragen.Size = new System.Drawing.Size(140, 25);
            this.btnEintragen.TabIndex = 8;
            this.btnEintragen.Text = "Punkte in Liste eintragen";
            this.btnEintragen.UseVisualStyleBackColor = true;
            this.btnEintragen.Click += new System.EventHandler(this.btnEintragen_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(10, 580);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(100, 580);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tmrCountdown
            // 
            this.tmrCountdown.Interval = 1000;
            this.tmrCountdown.Tick += new System.EventHandler(this.tmrCountdown_Tick);
            // 
            // tmrSpiel
            // 
            this.tmrSpiel.Tick += new System.EventHandler(this.tmrSpiel_Tick);
            // 
            // lblListMitPunkte
            // 
            this.lblListMitPunkte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListMitPunkte.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblListMitPunkte.Location = new System.Drawing.Point(630, 250);
            this.lblListMitPunkte.Name = "lblListMitPunkte";
            this.lblListMitPunkte.Size = new System.Drawing.Size(130, 200);
            this.lblListMitPunkte.TabIndex = 11;
            // 
            // frmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.lblListMitPunkte);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnEintragen);
            this.Controls.Add(this.txtCountdown);
            this.Controls.Add(this.txtPunkte);
            this.Controls.Add(this.lblPunkteliste);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.lblPunkte);
            this.Controls.Add(this.pnlSpielfeld);
            this.Controls.Add(this.lblInfo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSnake";
            this.Text = "Snake - friss en Apfel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlSpielfeld;
        private System.Windows.Forms.Label lblPunkte;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblPunkteliste;
        private System.Windows.Forms.TextBox txtPunkte;
        private System.Windows.Forms.TextBox txtCountdown;
        private System.Windows.Forms.Button btnEintragen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer tmrCountdown;
        private System.Windows.Forms.Timer tmrSpiel;
        private System.Windows.Forms.Label lblListMitPunkte;
    }
}

