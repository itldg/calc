namespace Calc
{
    partial class FrmCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalc));
            this.lblModeHex = new System.Windows.Forms.Label();
            this.lblModeDec = new System.Windows.Forms.Label();
            this.lblModeBin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHex = new System.Windows.Forms.Label();
            this.lblDec = new System.Windows.Forms.Label();
            this.lblBin = new System.Windows.Forms.Label();
            this.pHighHex = new System.Windows.Forms.Panel();
            this.pHighDec = new System.Windows.Forms.Panel();
            this.pHighBin = new System.Windows.Forms.Panel();
            this.lblCalc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblModeHex
            // 
            this.lblModeHex.AutoSize = true;
            this.lblModeHex.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblModeHex.Location = new System.Drawing.Point(5, 5);
            this.lblModeHex.Name = "lblModeHex";
            this.lblModeHex.Size = new System.Drawing.Size(28, 14);
            this.lblModeHex.TabIndex = 0;
            this.lblModeHex.Text = "HEX";
            this.lblModeHex.Click += new System.EventHandler(this.lblModeHex_Click);
            this.lblModeHex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // lblModeDec
            // 
            this.lblModeDec.AutoSize = true;
            this.lblModeDec.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblModeDec.Location = new System.Drawing.Point(5, 25);
            this.lblModeDec.Name = "lblModeDec";
            this.lblModeDec.Size = new System.Drawing.Size(28, 14);
            this.lblModeDec.TabIndex = 1;
            this.lblModeDec.Text = "DEC";
            this.lblModeDec.Click += new System.EventHandler(this.lblModeDec_Click);
            this.lblModeDec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // lblModeBin
            // 
            this.lblModeBin.AutoSize = true;
            this.lblModeBin.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblModeBin.Location = new System.Drawing.Point(5, 46);
            this.lblModeBin.Name = "lblModeBin";
            this.lblModeBin.Size = new System.Drawing.Size(28, 14);
            this.lblModeBin.TabIndex = 2;
            this.lblModeBin.Text = "BIN";
            this.lblModeBin.Click += new System.EventHandler(this.lblModeBin_Click);
            this.lblModeBin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(29, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(29, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "：";
            // 
            // lblHex
            // 
            this.lblHex.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblHex.Location = new System.Drawing.Point(41, 5);
            this.lblHex.Name = "lblHex";
            this.lblHex.Size = new System.Drawing.Size(123, 12);
            this.lblHex.TabIndex = 0;
            this.lblHex.Text = "0";
            this.lblHex.Click += new System.EventHandler(this.lblModeHex_Click);
            this.lblHex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // lblDec
            // 
            this.lblDec.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblDec.Location = new System.Drawing.Point(41, 26);
            this.lblDec.Name = "lblDec";
            this.lblDec.Size = new System.Drawing.Size(281, 14);
            this.lblDec.TabIndex = 1;
            this.lblDec.Text = "0";
            this.lblDec.Click += new System.EventHandler(this.lblModeDec_Click);
            this.lblDec.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // lblBin
            // 
            this.lblBin.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblBin.Location = new System.Drawing.Point(41, 47);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(281, 12);
            this.lblBin.TabIndex = 2;
            this.lblBin.Text = "0";
            this.lblBin.Click += new System.EventHandler(this.lblModeBin_Click);
            this.lblBin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // pHighHex
            // 
            this.pHighHex.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pHighHex.Location = new System.Drawing.Point(3, 7);
            this.pHighHex.Name = "pHighHex";
            this.pHighHex.Size = new System.Drawing.Size(2, 10);
            this.pHighHex.TabIndex = 3;
            this.pHighHex.Visible = false;
            // 
            // pHighDec
            // 
            this.pHighDec.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pHighDec.Location = new System.Drawing.Point(3, 27);
            this.pHighDec.Name = "pHighDec";
            this.pHighDec.Size = new System.Drawing.Size(2, 10);
            this.pHighDec.TabIndex = 4;
            this.pHighDec.Visible = false;
            // 
            // pHighBin
            // 
            this.pHighBin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pHighBin.Location = new System.Drawing.Point(3, 48);
            this.pHighBin.Name = "pHighBin";
            this.pHighBin.Size = new System.Drawing.Size(2, 10);
            this.pHighBin.TabIndex = 4;
            this.pHighBin.Visible = false;
            // 
            // lblCalc
            // 
            this.lblCalc.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblCalc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCalc.Location = new System.Drawing.Point(202, 3);
            this.lblCalc.Name = "lblCalc";
            this.lblCalc.Size = new System.Drawing.Size(120, 14);
            this.lblCalc.TabIndex = 0;
            this.lblCalc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCalc.Click += new System.EventHandler(this.lblModeHex_Click);
            this.lblCalc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblModeHex_MouseMove);
            // 
            // FrmCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 66);
            this.Controls.Add(this.pHighBin);
            this.Controls.Add(this.pHighDec);
            this.Controls.Add(this.pHighHex);
            this.Controls.Add(this.lblBin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDec);
            this.Controls.Add(this.lblHex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblModeBin);
            this.Controls.Add(this.lblModeDec);
            this.Controls.Add(this.lblCalc);
            this.Controls.Add(this.lblModeHex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "老大哥计算器";
            this.Activated += new System.EventHandler(this.FrmCalc_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCalc_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCalc_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModeHex;
        private System.Windows.Forms.Label lblModeDec;
        private System.Windows.Forms.Label lblModeBin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHex;
        private System.Windows.Forms.Label lblDec;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.Panel pHighHex;
        private System.Windows.Forms.Panel pHighDec;
        private System.Windows.Forms.Panel pHighBin;
        private System.Windows.Forms.Label lblCalc;
    }
}