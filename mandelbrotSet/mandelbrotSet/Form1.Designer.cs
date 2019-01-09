namespace mandelbrotSet
{
    partial class mandelbrot
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
            this.mandelbrotBox = new System.Windows.Forms.PictureBox();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.zoomButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.zoomBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mandelbrotBox
            // 
            this.mandelbrotBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mandelbrotBox.Location = new System.Drawing.Point(56, 90);
            this.mandelbrotBox.Name = "mandelbrotBox";
            this.mandelbrotBox.Size = new System.Drawing.Size(600, 600);
            this.mandelbrotBox.TabIndex = 0;
            this.mandelbrotBox.TabStop = false;
            this.mandelbrotBox.Click += new System.EventHandler(this.mandelbrotBox_Click);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomLabel.Location = new System.Drawing.Point(98, 46);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(55, 20);
            this.zoomLabel.TabIndex = 1;
            this.zoomLabel.Text = "Zoom:";
            this.zoomLabel.Click += new System.EventHandler(this.zoomLabel_Click);
            // 
            // zoomButton
            // 
            this.zoomButton.BackColor = System.Drawing.Color.LightGreen;
            this.zoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zoomButton.Location = new System.Drawing.Point(347, 39);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(79, 36);
            this.zoomButton.TabIndex = 2;
            this.zoomButton.Text = "Zoom!";
            this.zoomButton.UseVisualStyleBackColor = false;
            this.zoomButton.Click += new System.EventHandler(this.zoomButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Coral;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetButton.Location = new System.Drawing.Point(519, 39);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(88, 36);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // zoomBox1
            // 
            this.zoomBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zoomBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zoomBox1.FormattingEnabled = true;
            this.zoomBox1.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "10"});
            this.zoomBox1.Location = new System.Drawing.Point(179, 46);
            this.zoomBox1.Name = "zoomBox1";
            this.zoomBox1.Size = new System.Drawing.Size(77, 24);
            this.zoomBox1.TabIndex = 5;
            this.zoomBox1.SelectedIndexChanged += new System.EventHandler(this.zoomBox1_SelectedIndexChanged);
            // 
            // mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(715, 737);
            this.Controls.Add(this.zoomBox1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.zoomButton);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.mandelbrotBox);
            this.Name = "mandelbrot";
            this.Text = "mandelbrot";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mandelbrotBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mandelbrotBox;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Button zoomButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ComboBox zoomBox1;
    }
}

