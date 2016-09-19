namespace StampTracker
{
    partial class NewDocForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.docBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.scannedDocBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.viewScanImgButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.viewDocButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Новый документ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование документа";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(287, 42);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(512, 26);
            this.nameBox.TabIndex = 2;
            // 
            // docBox
            // 
            this.docBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docBox.Location = new System.Drawing.Point(287, 74);
            this.docBox.Name = "docBox";
            this.docBox.ReadOnly = true;
            this.docBox.Size = new System.Drawing.Size(512, 26);
            this.docBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Прикрепить документ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // scannedDocBox
            // 
            this.scannedDocBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scannedDocBox.Location = new System.Drawing.Point(287, 106);
            this.scannedDocBox.Name = "scannedDocBox";
            this.scannedDocBox.ReadOnly = true;
            this.scannedDocBox.Size = new System.Drawing.Size(512, 26);
            this.scannedDocBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(14, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Приврепить отсканированный вариант";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(805, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "обзор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(805, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "обзор";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(770, 156);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(114, 32);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(671, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 32);
            this.button4.TabIndex = 10;
            this.button4.Text = "очистить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(869, 498);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // viewScanImgButton
            // 
            this.viewScanImgButton.Enabled = false;
            this.viewScanImgButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewScanImgButton.Location = new System.Drawing.Point(892, 105);
            this.viewScanImgButton.Name = "viewScanImgButton";
            this.viewScanImgButton.Size = new System.Drawing.Size(97, 28);
            this.viewScanImgButton.TabIndex = 12;
            this.viewScanImgButton.Text = "просмотр";
            this.viewScanImgButton.UseVisualStyleBackColor = true;
            this.viewScanImgButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // viewDocButton
            // 
            this.viewDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewDocButton.Location = new System.Drawing.Point(892, 74);
            this.viewDocButton.Name = "viewDocButton";
            this.viewDocButton.Size = new System.Drawing.Size(97, 27);
            this.viewDocButton.TabIndex = 13;
            this.viewDocButton.Text = "просмотр";
            this.viewDocButton.UseVisualStyleBackColor = true;
            this.viewDocButton.Click += new System.EventHandler(this.viewDocButton_Click);
            // 
            // NewDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1018, 715);
            this.Controls.Add(this.viewDocButton);
            this.Controls.Add(this.viewScanImgButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scannedDocBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.docBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NewDocForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewDocForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox docBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scannedDocBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button viewScanImgButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button viewDocButton;
    }
}