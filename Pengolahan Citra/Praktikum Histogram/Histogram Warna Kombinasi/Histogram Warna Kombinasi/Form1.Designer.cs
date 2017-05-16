namespace Histogram_Warna_Kombinasi
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea27 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonLoad1 = new System.Windows.Forms.Button();
            this.buttonHistogram1 = new System.Windows.Forms.Button();
            this.buttonHistogram2 = new System.Windows.Forms.Button();
            this.buttonLoad2 = new System.Windows.Forms.Button();
            this.buttonHistogram3 = new System.Windows.Forms.Button();
            this.buttonLoad3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(12, 186);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 158);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(12, 363);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(184, 158);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // chart1
            // 
            chartArea25.CursorX.LineWidth = 0;
            chartArea25.CursorY.LineWidth = 0;
            chartArea25.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea25);
            this.chart1.Location = new System.Drawing.Point(220, 12);
            this.chart1.Name = "chart1";
            series25.ChartArea = "ChartArea1";
            series25.Name = "Series1";
            this.chart1.Series.Add(series25);
            this.chart1.Size = new System.Drawing.Size(835, 158);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea26.CursorX.LineWidth = 0;
            chartArea26.CursorY.LineWidth = 0;
            chartArea26.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea26);
            this.chart2.Location = new System.Drawing.Point(220, 186);
            this.chart2.Name = "chart2";
            series26.ChartArea = "ChartArea1";
            series26.Name = "Series1";
            this.chart2.Series.Add(series26);
            this.chart2.Size = new System.Drawing.Size(835, 158);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea27.CursorX.LineWidth = 0;
            chartArea27.CursorY.LineWidth = 0;
            chartArea27.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea27);
            this.chart3.Location = new System.Drawing.Point(220, 363);
            this.chart3.Name = "chart3";
            series27.ChartArea = "ChartArea1";
            series27.Name = "Series1";
            this.chart3.Series.Add(series27);
            this.chart3.Size = new System.Drawing.Size(835, 158);
            this.chart3.TabIndex = 5;
            this.chart3.Text = "chart3";
            // 
            // buttonLoad1
            // 
            this.buttonLoad1.Location = new System.Drawing.Point(1086, 60);
            this.buttonLoad1.Name = "buttonLoad1";
            this.buttonLoad1.Size = new System.Drawing.Size(108, 30);
            this.buttonLoad1.TabIndex = 6;
            this.buttonLoad1.Text = "Load Gambar";
            this.buttonLoad1.UseVisualStyleBackColor = true;
            this.buttonLoad1.Click += new System.EventHandler(this.buttonLoad1_Click);
            // 
            // buttonHistogram1
            // 
            this.buttonHistogram1.Location = new System.Drawing.Point(1086, 96);
            this.buttonHistogram1.Name = "buttonHistogram1";
            this.buttonHistogram1.Size = new System.Drawing.Size(108, 30);
            this.buttonHistogram1.TabIndex = 7;
            this.buttonHistogram1.Text = "Histogram";
            this.buttonHistogram1.UseVisualStyleBackColor = true;
            this.buttonHistogram1.Click += new System.EventHandler(this.buttonHistogram1_Click);
            // 
            // buttonHistogram2
            // 
            this.buttonHistogram2.Location = new System.Drawing.Point(1086, 267);
            this.buttonHistogram2.Name = "buttonHistogram2";
            this.buttonHistogram2.Size = new System.Drawing.Size(108, 30);
            this.buttonHistogram2.TabIndex = 9;
            this.buttonHistogram2.Text = "Histogram";
            this.buttonHistogram2.UseVisualStyleBackColor = true;
            this.buttonHistogram2.Click += new System.EventHandler(this.buttonHistogram2_Click);
            // 
            // buttonLoad2
            // 
            this.buttonLoad2.Location = new System.Drawing.Point(1086, 231);
            this.buttonLoad2.Name = "buttonLoad2";
            this.buttonLoad2.Size = new System.Drawing.Size(108, 30);
            this.buttonLoad2.TabIndex = 8;
            this.buttonLoad2.Text = "Load Gambar";
            this.buttonLoad2.UseVisualStyleBackColor = true;
            this.buttonLoad2.Click += new System.EventHandler(this.buttonLoad2_Click);
            // 
            // buttonHistogram3
            // 
            this.buttonHistogram3.Location = new System.Drawing.Point(1086, 448);
            this.buttonHistogram3.Name = "buttonHistogram3";
            this.buttonHistogram3.Size = new System.Drawing.Size(108, 30);
            this.buttonHistogram3.TabIndex = 11;
            this.buttonHistogram3.Text = "Histogram";
            this.buttonHistogram3.UseVisualStyleBackColor = true;
            this.buttonHistogram3.Click += new System.EventHandler(this.buttonHistogram3_Click);
            // 
            // buttonLoad3
            // 
            this.buttonLoad3.Location = new System.Drawing.Point(1086, 412);
            this.buttonLoad3.Name = "buttonLoad3";
            this.buttonLoad3.Size = new System.Drawing.Size(108, 30);
            this.buttonLoad3.TabIndex = 10;
            this.buttonLoad3.Text = "Load Gambar";
            this.buttonLoad3.UseVisualStyleBackColor = true;
            this.buttonLoad3.Click += new System.EventHandler(this.buttonLoad3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 533);
            this.Controls.Add(this.buttonHistogram3);
            this.Controls.Add(this.buttonLoad3);
            this.Controls.Add(this.buttonHistogram2);
            this.Controls.Add(this.buttonLoad2);
            this.Controls.Add(this.buttonHistogram1);
            this.Controls.Add(this.buttonLoad1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button buttonLoad1;
        private System.Windows.Forms.Button buttonHistogram1;
        private System.Windows.Forms.Button buttonHistogram2;
        private System.Windows.Forms.Button buttonLoad2;
        private System.Windows.Forms.Button buttonHistogram3;
        private System.Windows.Forms.Button buttonLoad3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

