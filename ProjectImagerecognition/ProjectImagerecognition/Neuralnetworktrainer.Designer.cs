namespace ProjectImagerecognition
{
    partial class Neuralnetworktrainer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonAuto_detect = new System.Windows.Forms.Button();
            this.chart_cost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox_outp = new System.Windows.Forms.PictureBox();
            this.button_Open = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_manualtrain = new System.Windows.Forms.Button();
            this.pictureBox_loadinggif = new System.Windows.Forms.PictureBox();
            this.label1_loading = new System.Windows.Forms.Label();
            this.progressBar1_loading = new System.Windows.Forms.ProgressBar();
            this.pictureBox_loadingback = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_outp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAuto_detect
            // 
            this.buttonAuto_detect.BackColor = System.Drawing.Color.Gray;
            this.buttonAuto_detect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAuto_detect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAuto_detect.ForeColor = System.Drawing.Color.White;
            this.buttonAuto_detect.Location = new System.Drawing.Point(200, 276);
            this.buttonAuto_detect.Name = "buttonAuto_detect";
            this.buttonAuto_detect.Size = new System.Drawing.Size(87, 34);
            this.buttonAuto_detect.TabIndex = 6;
            this.buttonAuto_detect.Text = "Auto Mode";
            this.buttonAuto_detect.UseVisualStyleBackColor = false;
            this.buttonAuto_detect.Click += new System.EventHandler(this.buttonAuto_detect_Click);
            // 
            // chart_cost
            // 
            this.chart_cost.BackColor = System.Drawing.SystemColors.Control;
            this.chart_cost.BorderSkin.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart_cost.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_cost.Legends.Add(legend1);
            this.chart_cost.Location = new System.Drawing.Point(259, -24);
            this.chart_cost.Name = "chart_cost";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Cost";
            series1.YValuesPerPoint = 2;
            this.chart_cost.Series.Add(series1);
            this.chart_cost.Size = new System.Drawing.Size(333, 300);
            this.chart_cost.TabIndex = 7;
            this.chart_cost.Text = "chart_cost";
            title1.Name = "Title1";
            this.chart_cost.Titles.Add(title1);
            // 
            // pictureBox_outp
            // 
            this.pictureBox_outp.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_outp.Name = "pictureBox_outp";
            this.pictureBox_outp.Size = new System.Drawing.Size(270, 270);
            this.pictureBox_outp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_outp.TabIndex = 0;
            this.pictureBox_outp.TabStop = false;
            this.pictureBox_outp.Click += new System.EventHandler(this.pictureBox_outp_Click);
            // 
            // button_Open
            // 
            this.button_Open.BackColor = System.Drawing.Color.Gray;
            this.button_Open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Open.ForeColor = System.Drawing.Color.White;
            this.button_Open.Location = new System.Drawing.Point(0, 276);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(93, 34);
            this.button_Open.TabIndex = 8;
            this.button_Open.Text = "Open NeuralNet";
            this.button_Open.UseVisualStyleBackColor = false;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.Color.Gray;
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Save.ForeColor = System.Drawing.Color.White;
            this.button_Save.Location = new System.Drawing.Point(99, 276);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(93, 34);
            this.button_Save.TabIndex = 9;
            this.button_Save.Text = "Save NeuralNet";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_stop
            // 
            this.button_stop.BackColor = System.Drawing.Color.Red;
            this.button_stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_stop.ForeColor = System.Drawing.Color.White;
            this.button_stop.Location = new System.Drawing.Point(198, 276);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(87, 34);
            this.button_stop.TabIndex = 10;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = false;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_manualtrain
            // 
            this.button_manualtrain.BackColor = System.Drawing.Color.Gray;
            this.button_manualtrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_manualtrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_manualtrain.ForeColor = System.Drawing.Color.White;
            this.button_manualtrain.Location = new System.Drawing.Point(460, 276);
            this.button_manualtrain.Name = "button_manualtrain";
            this.button_manualtrain.Size = new System.Drawing.Size(100, 34);
            this.button_manualtrain.TabIndex = 12;
            this.button_manualtrain.Text = "New NeuralNet";
            this.button_manualtrain.UseVisualStyleBackColor = false;
            this.button_manualtrain.Click += new System.EventHandler(this.button_manualtrain_Click);
            // 
            // pictureBox_loadinggif
            // 
            this.pictureBox_loadinggif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadinggif.Image = global::ProjectImagerecognition.Properties.Resources.YouTube_loading_symbol_3__transparent_;
            this.pictureBox_loadinggif.Location = new System.Drawing.Point(374, 128);
            this.pictureBox_loadinggif.Name = "pictureBox_loadinggif";
            this.pictureBox_loadinggif.Size = new System.Drawing.Size(36, 35);
            this.pictureBox_loadinggif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_loadinggif.TabIndex = 18;
            this.pictureBox_loadinggif.TabStop = false;
            // 
            // label1_loading
            // 
            this.label1_loading.AutoSize = true;
            this.label1_loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1_loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_loading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_loading.Location = new System.Drawing.Point(235, 120);
            this.label1_loading.Name = "label1_loading";
            this.label1_loading.Size = new System.Drawing.Size(52, 13);
            this.label1_loading.TabIndex = 16;
            this.label1_loading.Text = "Loading";
            this.label1_loading.Visible = false;
            // 
            // progressBar1_loading
            // 
            this.progressBar1_loading.Location = new System.Drawing.Point(221, 136);
            this.progressBar1_loading.Name = "progressBar1_loading";
            this.progressBar1_loading.Size = new System.Drawing.Size(144, 19);
            this.progressBar1_loading.Step = 1;
            this.progressBar1_loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1_loading.TabIndex = 15;
            this.progressBar1_loading.Visible = false;
            // 
            // pictureBox_loadingback
            // 
            this.pictureBox_loadingback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadingback.Location = new System.Drawing.Point(151, 100);
            this.pictureBox_loadingback.Name = "pictureBox_loadingback";
            this.pictureBox_loadingback.Size = new System.Drawing.Size(277, 85);
            this.pictureBox_loadingback.TabIndex = 17;
            this.pictureBox_loadingback.TabStop = false;
            this.pictureBox_loadingback.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Neuralnetworktrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(572, 318);
            this.Controls.Add(this.pictureBox_loadinggif);
            this.Controls.Add(this.label1_loading);
            this.Controls.Add(this.progressBar1_loading);
            this.Controls.Add(this.pictureBox_loadingback);
            this.Controls.Add(this.pictureBox_outp);
            this.Controls.Add(this.button_manualtrain);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.chart_cost);
            this.Controls.Add(this.buttonAuto_detect);
            this.Controls.Add(this.button_stop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Neuralnetworktrainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neuralnetworktrainer";
            this.Load += new System.EventHandler(this.Neuralnetworktrainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_outp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_outp;
        private System.Windows.Forms.Button buttonAuto_detect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_cost;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_manualtrain;
        private System.Windows.Forms.PictureBox pictureBox_loadinggif;
        private System.Windows.Forms.Label label1_loading;
        private System.Windows.Forms.ProgressBar progressBar1_loading;
        private System.Windows.Forms.PictureBox pictureBox_loadingback;
        private System.Windows.Forms.Timer timer1;
    }
}