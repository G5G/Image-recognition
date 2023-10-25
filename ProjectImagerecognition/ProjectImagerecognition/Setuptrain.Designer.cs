namespace ProjectImagerecognition
{
    partial class Setuptrain
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
            this.buttonImport_detect = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_Open = new System.Windows.Forms.Button();
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.buttonabstract = new System.Windows.Forms.Button();
            this.pictureBox_loadinggif = new System.Windows.Forms.PictureBox();
            this.label1_loading = new System.Windows.Forms.Label();
            this.progressBar1_loading = new System.Windows.Forms.ProgressBar();
            this.pictureBox_loadingback = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImport_detect
            // 
            this.buttonImport_detect.BackColor = System.Drawing.Color.Gray;
            this.buttonImport_detect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonImport_detect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImport_detect.ForeColor = System.Drawing.Color.White;
            this.buttonImport_detect.Location = new System.Drawing.Point(2, 455);
            this.buttonImport_detect.Name = "buttonImport_detect";
            this.buttonImport_detect.Size = new System.Drawing.Size(87, 34);
            this.buttonImport_detect.TabIndex = 5;
            this.buttonImport_detect.Text = "Import";
            this.buttonImport_detect.UseVisualStyleBackColor = false;
            this.buttonImport_detect.Click += new System.EventHandler(this.buttonImport_detect_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Gray;
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(456, 448);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(51, 35);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Gray;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(515, 448);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(51, 34);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(456, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(170, 444);
            this.listBox1.TabIndex = 9;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // button_Open
            // 
            this.button_Open.BackColor = System.Drawing.Color.Gray;
            this.button_Open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Open.ForeColor = System.Drawing.Color.White;
            this.button_Open.Location = new System.Drawing.Point(572, 448);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(54, 34);
            this.button_Open.TabIndex = 10;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = false;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // pictureBoxImg
            // 
            this.pictureBoxImg.BackColor = System.Drawing.Color.White;
            this.pictureBoxImg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxImg.Location = new System.Drawing.Point(2, 1);
            this.pictureBoxImg.Name = "pictureBoxImg";
            this.pictureBoxImg.Size = new System.Drawing.Size(448, 448);
            this.pictureBoxImg.TabIndex = 0;
            this.pictureBoxImg.TabStop = false;
            this.pictureBoxImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImg_MouseClick);
            this.pictureBoxImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImg_MouseMove);
            // 
            // buttonabstract
            // 
            this.buttonabstract.BackColor = System.Drawing.Color.Gray;
            this.buttonabstract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonabstract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonabstract.ForeColor = System.Drawing.Color.White;
            this.buttonabstract.Location = new System.Drawing.Point(107, 455);
            this.buttonabstract.Name = "buttonabstract";
            this.buttonabstract.Size = new System.Drawing.Size(87, 34);
            this.buttonabstract.TabIndex = 11;
            this.buttonabstract.Text = "Abstract image";
            this.buttonabstract.UseVisualStyleBackColor = false;
            this.buttonabstract.Click += new System.EventHandler(this.buttonabstract_Click);
            // 
            // pictureBox_loadinggif
            // 
            this.pictureBox_loadinggif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadinggif.Image = global::ProjectImagerecognition.Properties.Resources.YouTube_loading_symbol_3__transparent_;
            this.pictureBox_loadinggif.Location = new System.Drawing.Point(396, 219);
            this.pictureBox_loadinggif.Name = "pictureBox_loadinggif";
            this.pictureBox_loadinggif.Size = new System.Drawing.Size(36, 35);
            this.pictureBox_loadinggif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_loadinggif.TabIndex = 22;
            this.pictureBox_loadinggif.TabStop = false;
            // 
            // label1_loading
            // 
            this.label1_loading.AutoSize = true;
            this.label1_loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1_loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_loading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_loading.Location = new System.Drawing.Point(257, 211);
            this.label1_loading.Name = "label1_loading";
            this.label1_loading.Size = new System.Drawing.Size(52, 13);
            this.label1_loading.TabIndex = 20;
            this.label1_loading.Text = "Loading";
            this.label1_loading.Visible = false;
            // 
            // progressBar1_loading
            // 
            this.progressBar1_loading.Location = new System.Drawing.Point(243, 227);
            this.progressBar1_loading.Name = "progressBar1_loading";
            this.progressBar1_loading.Size = new System.Drawing.Size(144, 19);
            this.progressBar1_loading.Step = 1;
            this.progressBar1_loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1_loading.TabIndex = 19;
            this.progressBar1_loading.Visible = false;
            // 
            // pictureBox_loadingback
            // 
            this.pictureBox_loadingback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadingback.Location = new System.Drawing.Point(173, 191);
            this.pictureBox_loadingback.Name = "pictureBox_loadingback";
            this.pictureBox_loadingback.Size = new System.Drawing.Size(277, 85);
            this.pictureBox_loadingback.TabIndex = 21;
            this.pictureBox_loadingback.TabStop = false;
            this.pictureBox_loadingback.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_abstract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(626, 494);
            this.Controls.Add(this.pictureBox_loadinggif);
            this.Controls.Add(this.label1_loading);
            this.Controls.Add(this.progressBar1_loading);
            this.Controls.Add(this.pictureBox_loadingback);
            this.Controls.Add(this.buttonabstract);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonImport_detect);
            this.Controls.Add(this.pictureBoxImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "button_abstract";
            this.Text = "Setuptrain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImg;
        private System.Windows.Forms.Button buttonImport_detect;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Button buttonabstract;
        private System.Windows.Forms.PictureBox pictureBox_loadinggif;
        private System.Windows.Forms.Label label1_loading;
        private System.Windows.Forms.ProgressBar progressBar1_loading;
        private System.Windows.Forms.PictureBox pictureBox_loadingback;
        private System.Windows.Forms.Timer timer1;
    }
}