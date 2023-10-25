namespace ProjectImagerecognition
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3_view = new System.Windows.Forms.Label();
            this.label2_edit = new System.Windows.Forms.Label();
            this.label1_file = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1_logs = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1_detect = new System.Windows.Forms.Button();
            this.panel2_file = new System.Windows.Forms.Panel();
            this.label2_liveimagemode = new System.Windows.Forms.Label();
            this.label1_staticimagemode = new System.Windows.Forms.Label();
            this.label1_neuralnetwork = new System.Windows.Forms.Label();
            this.panel2_Neuraledit = new System.Windows.Forms.Panel();
            this.label3_imagerecognition = new System.Windows.Forms.Label();
            this.label2_objectdetector = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1_loading = new System.Windows.Forms.ProgressBar();
            this.label1_loading = new System.Windows.Forms.Label();
            this.button_import = new System.Windows.Forms.Button();
            this.label1_import = new System.Windows.Forms.Label();
            this.button2_load = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1_objectfilename = new System.Windows.Forms.Label();
            this.pictureBox_loadinggif = new System.Windows.Forms.PictureBox();
            this.pictureBox_loadingback = new System.Windows.Forms.PictureBox();
            this.pictureBox2_main = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2_file.SuspendLayout();
            this.panel2_Neuraledit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3_view);
            this.panel1.Controls.Add(this.label2_edit);
            this.panel1.Controls.Add(this.label1_file);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 31);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3_view
            // 
            this.label3_view.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_view.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3_view.Location = new System.Drawing.Point(81, 0);
            this.label3_view.Name = "label3_view";
            this.label3_view.Size = new System.Drawing.Size(38, 30);
            this.label3_view.TabIndex = 7;
            this.label3_view.Text = "View";
            this.label3_view.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3_view.MouseEnter += new System.EventHandler(this.label3_view_MouseEnter);
            this.label3_view.MouseLeave += new System.EventHandler(this.label3_view_MouseLeave);
            // 
            // label2_edit
            // 
            this.label2_edit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_edit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2_edit.Location = new System.Drawing.Point(38, 0);
            this.label2_edit.Name = "label2_edit";
            this.label2_edit.Size = new System.Drawing.Size(39, 30);
            this.label2_edit.TabIndex = 6;
            this.label2_edit.Text = "Edit";
            this.label2_edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2_edit.MouseEnter += new System.EventHandler(this.label2_edit_MouseEnter);
            this.label2_edit.MouseLeave += new System.EventHandler(this.label2_edit_MouseLeave);
            // 
            // label1_file
            // 
            this.label1_file.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1_file.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_file.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1_file.Location = new System.Drawing.Point(-1, 0);
            this.label1_file.Name = "label1_file";
            this.label1_file.Size = new System.Drawing.Size(38, 30);
            this.label1_file.TabIndex = 5;
            this.label1_file.Text = "File";
            this.label1_file.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1_file.Click += new System.EventHandler(this.label1_file_Click);
            this.label1_file.MouseEnter += new System.EventHandler(this.label1_file_MouseEnter);
            this.label1_file.MouseLeave += new System.EventHandler(this.label1_file_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ProjectImagerecognition.Properties.Resources.x_transparent_white_1;
            this.pictureBox1.Location = new System.Drawing.Point(739, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1_logs
            // 
            this.textBox1_logs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox1_logs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1_logs.ForeColor = System.Drawing.Color.White;
            this.textBox1_logs.Location = new System.Drawing.Point(457, 30);
            this.textBox1_logs.Multiline = true;
            this.textBox1_logs.Name = "textBox1_logs";
            this.textBox1_logs.ReadOnly = true;
            this.textBox1_logs.Size = new System.Drawing.Size(163, 448);
            this.textBox1_logs.TabIndex = 2;
            this.textBox1_logs.Text = "Logs:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(626, 175);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(135, 303);
            this.listBox1.TabIndex = 3;
            // 
            // button1_detect
            // 
            this.button1_detect.BackColor = System.Drawing.SystemColors.GrayText;
            this.button1_detect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1_detect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1_detect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1_detect.Location = new System.Drawing.Point(2, 484);
            this.button1_detect.Name = "button1_detect";
            this.button1_detect.Size = new System.Drawing.Size(87, 34);
            this.button1_detect.TabIndex = 4;
            this.button1_detect.Text = "Detect";
            this.button1_detect.UseVisualStyleBackColor = false;
            this.button1_detect.Click += new System.EventHandler(this.button1_detect_Click);
            // 
            // panel2_file
            // 
            this.panel2_file.BackColor = System.Drawing.Color.Gray;
            this.panel2_file.Controls.Add(this.label2_liveimagemode);
            this.panel2_file.Controls.Add(this.label1_staticimagemode);
            this.panel2_file.Controls.Add(this.label1_neuralnetwork);
            this.panel2_file.Location = new System.Drawing.Point(-1, 26);
            this.panel2_file.Name = "panel2_file";
            this.panel2_file.Size = new System.Drawing.Size(100, 124);
            this.panel2_file.TabIndex = 5;
            this.panel2_file.Visible = false;
            this.panel2_file.MouseLeave += new System.EventHandler(this.panel2_file_MouseLeave);
            // 
            // label2_liveimagemode
            // 
            this.label2_liveimagemode.BackColor = System.Drawing.Color.Gray;
            this.label2_liveimagemode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2_liveimagemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_liveimagemode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2_liveimagemode.Location = new System.Drawing.Point(1, 63);
            this.label2_liveimagemode.Name = "label2_liveimagemode";
            this.label2_liveimagemode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2_liveimagemode.Size = new System.Drawing.Size(99, 32);
            this.label2_liveimagemode.TabIndex = 5;
            this.label2_liveimagemode.Text = "Live image mode";
            this.label2_liveimagemode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2_liveimagemode.Click += new System.EventHandler(this.label2_liveimagemode_Click);
            this.label2_liveimagemode.MouseEnter += new System.EventHandler(this.label2_liveimagemode_MouseEnter);
            this.label2_liveimagemode.MouseLeave += new System.EventHandler(this.label2_liveimagemode_MouseLeave);
            // 
            // label1_staticimagemode
            // 
            this.label1_staticimagemode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1_staticimagemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_staticimagemode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_staticimagemode.Location = new System.Drawing.Point(0, 33);
            this.label1_staticimagemode.Name = "label1_staticimagemode";
            this.label1_staticimagemode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1_staticimagemode.Size = new System.Drawing.Size(100, 32);
            this.label1_staticimagemode.TabIndex = 4;
            this.label1_staticimagemode.Text = "Static image mode";
            this.label1_staticimagemode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1_staticimagemode.Click += new System.EventHandler(this.label1_staticimagemode_Click);
            this.label1_staticimagemode.MouseEnter += new System.EventHandler(this.label1_staticimagemode_MouseEnter);
            this.label1_staticimagemode.MouseLeave += new System.EventHandler(this.label1_staticimagemode_MouseLeave);
            // 
            // label1_neuralnetwork
            // 
            this.label1_neuralnetwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1_neuralnetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_neuralnetwork.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_neuralnetwork.Location = new System.Drawing.Point(1, 1);
            this.label1_neuralnetwork.Name = "label1_neuralnetwork";
            this.label1_neuralnetwork.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1_neuralnetwork.Size = new System.Drawing.Size(99, 32);
            this.label1_neuralnetwork.TabIndex = 3;
            this.label1_neuralnetwork.Text = "Neural network editor";
            this.label1_neuralnetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1_neuralnetwork.MouseEnter += new System.EventHandler(this.label1_neuralnetwork_MouseEnter);
            this.label1_neuralnetwork.MouseLeave += new System.EventHandler(this.label1_neuralnetwork_MouseLeave);
            // 
            // panel2_Neuraledit
            // 
            this.panel2_Neuraledit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2_Neuraledit.Controls.Add(this.label3_imagerecognition);
            this.panel2_Neuraledit.Controls.Add(this.label2_objectdetector);
            this.panel2_Neuraledit.Location = new System.Drawing.Point(97, 28);
            this.panel2_Neuraledit.Name = "panel2_Neuraledit";
            this.panel2_Neuraledit.Size = new System.Drawing.Size(97, 61);
            this.panel2_Neuraledit.TabIndex = 6;
            this.panel2_Neuraledit.Visible = false;
            this.panel2_Neuraledit.MouseLeave += new System.EventHandler(this.panel2_Neuraledit_MouseLeave);
            // 
            // label3_imagerecognition
            // 
            this.label3_imagerecognition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3_imagerecognition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3_imagerecognition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_imagerecognition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3_imagerecognition.Location = new System.Drawing.Point(1, 31);
            this.label3_imagerecognition.Name = "label3_imagerecognition";
            this.label3_imagerecognition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3_imagerecognition.Size = new System.Drawing.Size(96, 30);
            this.label3_imagerecognition.TabIndex = 5;
            this.label3_imagerecognition.Text = "Neural network trainer";
            this.label3_imagerecognition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3_imagerecognition.Click += new System.EventHandler(this.label3_imagerecognition_Click);
            this.label3_imagerecognition.MouseEnter += new System.EventHandler(this.label3_imagerecognition_MouseEnter);
            // 
            // label2_objectdetector
            // 
            this.label2_objectdetector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2_objectdetector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_objectdetector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2_objectdetector.Location = new System.Drawing.Point(1, 0);
            this.label2_objectdetector.Name = "label2_objectdetector";
            this.label2_objectdetector.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2_objectdetector.Size = new System.Drawing.Size(96, 31);
            this.label2_objectdetector.TabIndex = 4;
            this.label2_objectdetector.Text = "Setup training data";
            this.label2_objectdetector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2_objectdetector.Click += new System.EventHandler(this.label2_objectdetector_Click);
            this.label2_objectdetector.MouseEnter += new System.EventHandler(this.label2_objectdetector_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1_loading
            // 
            this.progressBar1_loading.Location = new System.Drawing.Point(354, 266);
            this.progressBar1_loading.Name = "progressBar1_loading";
            this.progressBar1_loading.Size = new System.Drawing.Size(144, 19);
            this.progressBar1_loading.Step = 1;
            this.progressBar1_loading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1_loading.TabIndex = 7;
            this.progressBar1_loading.Visible = false;
            // 
            // label1_loading
            // 
            this.label1_loading.AutoSize = true;
            this.label1_loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1_loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_loading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_loading.Location = new System.Drawing.Point(368, 250);
            this.label1_loading.Name = "label1_loading";
            this.label1_loading.Size = new System.Drawing.Size(52, 13);
            this.label1_loading.TabIndex = 9;
            this.label1_loading.Text = "Loading";
            this.label1_loading.Visible = false;
            // 
            // button_import
            // 
            this.button_import.BackColor = System.Drawing.SystemColors.GrayText;
            this.button_import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_import.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_import.Location = new System.Drawing.Point(114, 487);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(80, 29);
            this.button_import.TabIndex = 10;
            this.button_import.Text = "Import image";
            this.button_import.UseVisualStyleBackColor = false;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // label1_import
            // 
            this.label1_import.AutoSize = true;
            this.label1_import.Location = new System.Drawing.Point(200, 495);
            this.label1_import.Name = "label1_import";
            this.label1_import.Size = new System.Drawing.Size(25, 13);
            this.label1_import.TabIndex = 11;
            this.label1_import.Text = "Null";
            // 
            // button2_load
            // 
            this.button2_load.BackColor = System.Drawing.SystemColors.GrayText;
            this.button2_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2_load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2_load.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2_load.Location = new System.Drawing.Point(662, 477);
            this.button2_load.Name = "button2_load";
            this.button2_load.Size = new System.Drawing.Size(64, 27);
            this.button2_load.TabIndex = 12;
            this.button2_load.Text = "Load";
            this.button2_load.UseVisualStyleBackColor = false;
            this.button2_load.Click += new System.EventHandler(this.button2_load_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1_objectfilename
            // 
            this.label1_objectfilename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1_objectfilename.AutoSize = true;
            this.label1_objectfilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_objectfilename.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_objectfilename.Location = new System.Drawing.Point(649, 146);
            this.label1_objectfilename.Name = "label1_objectfilename";
            this.label1_objectfilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1_objectfilename.Size = new System.Drawing.Size(0, 16);
            this.label1_objectfilename.TabIndex = 8;
            // 
            // pictureBox_loadinggif
            // 
            this.pictureBox_loadinggif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadinggif.Image = global::ProjectImagerecognition.Properties.Resources.YouTube_loading_symbol_3__transparent_;
            this.pictureBox_loadinggif.Location = new System.Drawing.Point(507, 258);
            this.pictureBox_loadinggif.Name = "pictureBox_loadinggif";
            this.pictureBox_loadinggif.Size = new System.Drawing.Size(36, 35);
            this.pictureBox_loadinggif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_loadinggif.TabIndex = 14;
            this.pictureBox_loadinggif.TabStop = false;
            this.pictureBox_loadinggif.Visible = false;
            // 
            // pictureBox_loadingback
            // 
            this.pictureBox_loadingback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox_loadingback.Location = new System.Drawing.Point(284, 230);
            this.pictureBox_loadingback.Name = "pictureBox_loadingback";
            this.pictureBox_loadingback.Size = new System.Drawing.Size(277, 85);
            this.pictureBox_loadingback.TabIndex = 13;
            this.pictureBox_loadingback.TabStop = false;
            this.pictureBox_loadingback.Visible = false;
            // 
            // pictureBox2_main
            // 
            this.pictureBox2_main.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2_main.Location = new System.Drawing.Point(3, 30);
            this.pictureBox2_main.Name = "pictureBox2_main";
            this.pictureBox2_main.Size = new System.Drawing.Size(448, 448);
            this.pictureBox2_main.TabIndex = 1;
            this.pictureBox2_main.TabStop = false;
            this.pictureBox2_main.Click += new System.EventHandler(this.pictureBox2_main_Click);
            this.pictureBox2_main.MouseEnter += new System.EventHandler(this.pictureBox2_main_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(770, 541);
            this.Controls.Add(this.pictureBox_loadinggif);
            this.Controls.Add(this.label1_objectfilename);
            this.Controls.Add(this.label1_loading);
            this.Controls.Add(this.progressBar1_loading);
            this.Controls.Add(this.pictureBox_loadingback);
            this.Controls.Add(this.button2_load);
            this.Controls.Add(this.label1_import);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.panel2_Neuraledit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2_file);
            this.Controls.Add(this.button1_detect);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1_logs);
            this.Controls.Add(this.pictureBox2_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2_file.ResumeLayout(false);
            this.panel2_Neuraledit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadinggif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_loadingback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2_main;
        private System.Windows.Forms.TextBox textBox1_logs;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1_detect;
        private System.Windows.Forms.Label label1_file;
        private System.Windows.Forms.Panel panel2_file;
        private System.Windows.Forms.Panel panel2_Neuraledit;
        private System.Windows.Forms.Label label3_view;
        private System.Windows.Forms.Label label2_edit;
        private System.Windows.Forms.Label label1_neuralnetwork;
        private System.Windows.Forms.Label label3_imagerecognition;
        private System.Windows.Forms.Label label2_objectdetector;
        private System.Windows.Forms.Label label2_liveimagemode;
        private System.Windows.Forms.Label label1_staticimagemode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1_loading;
        private System.Windows.Forms.Label label1_loading;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.Label label1_import;
        private System.Windows.Forms.Button button2_load;
        private System.Windows.Forms.PictureBox pictureBox_loadingback;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1_objectfilename;
        private System.Windows.Forms.PictureBox pictureBox_loadinggif;
    }
}

