namespace CitraHistogramRGB
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.histogramRed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.histogramGreen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.histogramBlue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHR = new System.Windows.Forms.Button();
            this.btnHG = new System.Windows.Forms.Button();
            this.btnHB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(254, 271);
            this.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInput.TabIndex = 0;
            this.pictureBoxInput.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 289);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Gambar";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // histogramRed
            // 
            chartArea16.Name = "ChartArea1";
            this.histogramRed.ChartAreas.Add(chartArea16);
            this.histogramRed.Location = new System.Drawing.Point(340, 12);
            this.histogramRed.Name = "histogramRed";
            series16.ChartArea = "ChartArea1";
            series16.Name = "Series1";
            this.histogramRed.Series.Add(series16);
            this.histogramRed.Size = new System.Drawing.Size(608, 119);
            this.histogramRed.TabIndex = 2;
            this.histogramRed.Text = "chart1";
            // 
            // histogramGreen
            // 
            chartArea17.Name = "ChartArea1";
            this.histogramGreen.ChartAreas.Add(chartArea17);
            this.histogramGreen.Location = new System.Drawing.Point(340, 137);
            this.histogramGreen.Name = "histogramGreen";
            series17.ChartArea = "ChartArea1";
            series17.Name = "Series1";
            this.histogramGreen.Series.Add(series17);
            this.histogramGreen.Size = new System.Drawing.Size(608, 119);
            this.histogramGreen.TabIndex = 3;
            this.histogramGreen.Text = "chart2";
            // 
            // histogramBlue
            // 
            chartArea18.Name = "ChartArea1";
            this.histogramBlue.ChartAreas.Add(chartArea18);
            this.histogramBlue.Location = new System.Drawing.Point(340, 262);
            this.histogramBlue.Name = "histogramBlue";
            series18.ChartArea = "ChartArea1";
            series18.Name = "Series1";
            this.histogramBlue.Series.Add(series18);
            this.histogramBlue.Size = new System.Drawing.Size(608, 119);
            this.histogramBlue.TabIndex = 4;
            this.histogramBlue.Text = "chart3";
            // 
            // btnHR
            // 
            this.btnHR.Location = new System.Drawing.Point(288, 61);
            this.btnHR.Name = "btnHR";
            this.btnHR.Size = new System.Drawing.Size(46, 23);
            this.btnHR.TabIndex = 5;
            this.btnHR.Text = "HR";
            this.btnHR.UseVisualStyleBackColor = true;
            this.btnHR.Click += new System.EventHandler(this.btnHR_Click);
            // 
            // btnHG
            // 
            this.btnHG.Location = new System.Drawing.Point(288, 194);
            this.btnHG.Name = "btnHG";
            this.btnHG.Size = new System.Drawing.Size(46, 23);
            this.btnHG.TabIndex = 6;
            this.btnHG.Text = "HG";
            this.btnHG.UseVisualStyleBackColor = true;
            this.btnHG.Click += new System.EventHandler(this.btnHG_Click);
            // 
            // btnHB
            // 
            this.btnHB.Location = new System.Drawing.Point(288, 317);
            this.btnHB.Name = "btnHB";
            this.btnHB.Size = new System.Drawing.Size(46, 23);
            this.btnHB.TabIndex = 7;
            this.btnHB.Text = "HB";
            this.btnHB.UseVisualStyleBackColor = true;
            this.btnHB.Click += new System.EventHandler(this.btnHB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 396);
            this.Controls.Add(this.btnHB);
            this.Controls.Add(this.btnHG);
            this.Controls.Add(this.btnHR);
            this.Controls.Add(this.histogramBlue);
            this.Controls.Add(this.histogramGreen);
            this.Controls.Add(this.histogramRed);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pictureBoxInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxInput;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramRed;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramGreen;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramBlue;
        private System.Windows.Forms.Button btnHR;
        private System.Windows.Forms.Button btnHG;
        private System.Windows.Forms.Button btnHB;
    }
}

