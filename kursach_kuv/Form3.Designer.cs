namespace kursach_kuv
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.zed = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zed
            // 
            this.zed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zed.IsShowPointValues = false;
            this.zed.Location = new System.Drawing.Point(0, 0);
            this.zed.Name = "zed";
            this.zed.PointValueFormat = "G";
            this.zed.Size = new System.Drawing.Size(694, 542);
            this.zed.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 542);
            this.Controls.Add(this.zed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "График";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zed;
    }
}