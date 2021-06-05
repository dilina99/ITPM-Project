
namespace Project
{
    partial class Sprint1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sprint1));
            this.label1 = new System.Windows.Forms.Label();
            this.butClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butStat = new System.Windows.Forms.Button();
            this.butLoca = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(431, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprint 1";
            // 
            // butClose
            // 
            this.butClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.butClose.Location = new System.Drawing.Point(904, 507);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(90, 40);
            this.butClose.TabIndex = 36;
            this.butClose.Text = "Back";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 95);
            this.panel1.TabIndex = 35;
            // 
            // butStat
            // 
            this.butStat.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.butStat.Location = new System.Drawing.Point(404, 369);
            this.butStat.Name = "butStat";
            this.butStat.Size = new System.Drawing.Size(189, 87);
            this.butStat.TabIndex = 34;
            this.butStat.Text = "Statistics";
            this.butStat.UseVisualStyleBackColor = true;
            this.butStat.Click += new System.EventHandler(this.butStat_Click);
            // 
            // butLoca
            // 
            this.butLoca.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.butLoca.Location = new System.Drawing.Point(404, 201);
            this.butLoca.Name = "butLoca";
            this.butLoca.Size = new System.Drawing.Size(189, 87);
            this.butLoca.TabIndex = 33;
            this.butLoca.Text = "Location";
            this.butLoca.UseVisualStyleBackColor = true;
            this.butLoca.Click += new System.EventHandler(this.butLoca_Click);
            // 
            // Sprint1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butStat);
            this.Controls.Add(this.butLoca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sprint1";
            this.Text = "Sprint 1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butStat;
        private System.Windows.Forms.Button butLoca;
    }
}