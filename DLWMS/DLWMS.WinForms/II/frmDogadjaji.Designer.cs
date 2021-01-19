
namespace DLWMS.WinForms.II
{
    partial class frmDogadjaji
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
            this.txtPoruka = new System.Windows.Forms.TextBox();
            this.cbBHTelecom = new System.Windows.Forms.CheckBox();
            this.cbHTEronet = new System.Windows.Forms.CheckBox();
            this.cbMTel = new System.Windows.Forms.CheckBox();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYield = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPoruka
            // 
            this.txtPoruka.Location = new System.Drawing.Point(12, 12);
            this.txtPoruka.Multiline = true;
            this.txtPoruka.Name = "txtPoruka";
            this.txtPoruka.Size = new System.Drawing.Size(256, 120);
            this.txtPoruka.TabIndex = 0;
            // 
            // cbBHTelecom
            // 
            this.cbBHTelecom.AutoSize = true;
            this.cbBHTelecom.Location = new System.Drawing.Point(274, 12);
            this.cbBHTelecom.Name = "cbBHTelecom";
            this.cbBHTelecom.Size = new System.Drawing.Size(103, 21);
            this.cbBHTelecom.TabIndex = 1;
            this.cbBHTelecom.Text = "BHTelecom";
            this.cbBHTelecom.UseVisualStyleBackColor = true;
            this.cbBHTelecom.CheckedChanged += new System.EventHandler(this.cbBHTelecom_CheckedChanged);
            // 
            // cbHTEronet
            // 
            this.cbHTEronet.AutoSize = true;
            this.cbHTEronet.Location = new System.Drawing.Point(274, 39);
            this.cbHTEronet.Name = "cbHTEronet";
            this.cbHTEronet.Size = new System.Drawing.Size(91, 21);
            this.cbHTEronet.TabIndex = 2;
            this.cbHTEronet.Text = "HTEronet";
            this.cbHTEronet.UseVisualStyleBackColor = true;
            this.cbHTEronet.CheckedChanged += new System.EventHandler(this.cbHTEronet_CheckedChanged);
            // 
            // cbMTel
            // 
            this.cbMTel.AutoSize = true;
            this.cbMTel.Location = new System.Drawing.Point(274, 66);
            this.cbMTel.Name = "cbMTel";
            this.cbMTel.Size = new System.Drawing.Size(61, 21);
            this.cbMTel.TabIndex = 3;
            this.cbMTel.Text = "MTel";
            this.cbMTel.UseVisualStyleBackColor = true;
            this.cbMTel.CheckedChanged += new System.EventHandler(this.cbMTel_CheckedChanged);
            // 
            // btnPosalji
            // 
            this.btnPosalji.Location = new System.Drawing.Point(274, 93);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(103, 39);
            this.btnPosalji.TabIndex = 4;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(392, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 120);
            this.label1.TabIndex = 5;
            // 
            // btnYield
            // 
            this.btnYield.Location = new System.Drawing.Point(405, 38);
            this.btnYield.Name = "btnYield";
            this.btnYield.Size = new System.Drawing.Size(75, 75);
            this.btnYield.TabIndex = 6;
            this.btnYield.Text = "Yield";
            this.btnYield.UseVisualStyleBackColor = true;
            this.btnYield.Click += new System.EventHandler(this.btnYield_Click);
            // 
            // frmDogadjaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 144);
            this.Controls.Add(this.btnYield);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.cbMTel);
            this.Controls.Add(this.cbHTEronet);
            this.Controls.Add(this.cbBHTelecom);
            this.Controls.Add(this.txtPoruka);
            this.Name = "frmDogadjaji";
            this.Text = "frmDogadjaji";
            this.Load += new System.EventHandler(this.frmDogadjaji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPoruka;
        private System.Windows.Forms.CheckBox cbBHTelecom;
        private System.Windows.Forms.CheckBox cbHTEronet;
        private System.Windows.Forms.CheckBox cbMTel;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYield;
    }
}