namespace UserStorySimilarityAddIn
{
    partial class SimilarityForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TrackBar thresholdSlider;
        private System.Windows.Forms.Label lblThreshold;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.thresholdSlider = new System.Windows.Forms.TrackBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).BeginInit();
            this.SuspendLayout();

            // File 1
            this.txtFile1.Location = new System.Drawing.Point(30, 30);
            this.txtFile1.Size = new System.Drawing.Size(300, 20);
            this.btnBrowse1.Location = new System.Drawing.Point(340, 30);
            this.btnBrowse1.Text = "Browse...";
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);

            // File 2
            this.txtFile2.Location = new System.Drawing.Point(30, 70);
            this.txtFile2.Size = new System.Drawing.Size(300, 20);
            this.btnBrowse2.Location = new System.Drawing.Point(340, 70);
            this.btnBrowse2.Text = "Browse...";
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);

            // Threshold
            this.thresholdSlider.Location = new System.Drawing.Point(30, 110);
            this.thresholdSlider.Minimum = 0;
            this.thresholdSlider.Maximum = 100;
            this.thresholdSlider.Value = 75;
            this.thresholdSlider.TickFrequency = 10;
            this.lblThreshold.Location = new System.Drawing.Point(30, 140);
            this.lblThreshold.Text = "Similarity Threshold: 0.75";

            this.thresholdSlider.Scroll += (s, e) =>
            {
                float value = (float)thresholdSlider.Value / 100;
                lblThreshold.Text = $"Similarity Threshold: {value:F2}";
            };

            // Compare
            this.btnCompare.Location = new System.Drawing.Point(30, 180);
            this.btnCompare.Size = new System.Drawing.Size(150, 30);
            this.btnCompare.Text = "Compare User Stories";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.txtFile1);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.thresholdSlider);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.btnCompare);
            this.Text = "User Story Similarity";
            ((System.ComponentModel.ISupportInitialize)(this.thresholdSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
