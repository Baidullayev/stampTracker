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
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.docBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.scannedDocBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.viewScanImgButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.viewDocButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recentDocGroup = new System.Windows.Forms.GroupBox();
            this.recentDocList = new System.Windows.Forms.ListBox();
            this.openDocButton = new System.Windows.Forms.Button();
            this.cloneButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.recentDocGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование документа";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(238, 31);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(422, 20);
            this.nameBox.TabIndex = 0;
            // 
            // docBox
            // 
            this.docBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docBox.Location = new System.Drawing.Point(238, 70);
            this.docBox.Name = "docBox";
            this.docBox.ReadOnly = true;
            this.docBox.Size = new System.Drawing.Size(512, 20);
            this.docBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Прикрепить документ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // scannedDocBox
            // 
            this.scannedDocBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scannedDocBox.Location = new System.Drawing.Point(238, 103);
            this.scannedDocBox.Name = "scannedDocBox";
            this.scannedDocBox.ReadOnly = true;
            this.scannedDocBox.Size = new System.Drawing.Size(512, 20);
            this.scannedDocBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(26, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Прикрепить отсканированный вариант";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(756, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "обзор";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(756, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "обзор";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(756, 140);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "очистить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // viewScanImgButton
            // 
            this.viewScanImgButton.Enabled = false;
            this.viewScanImgButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewScanImgButton.Location = new System.Drawing.Point(842, 101);
            this.viewScanImgButton.Name = "viewScanImgButton";
            this.viewScanImgButton.Size = new System.Drawing.Size(97, 23);
            this.viewScanImgButton.TabIndex = 4;
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
            this.viewDocButton.Enabled = false;
            this.viewDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewDocButton.Location = new System.Drawing.Point(843, 68);
            this.viewDocButton.Name = "viewDocButton";
            this.viewDocButton.Size = new System.Drawing.Size(97, 23);
            this.viewDocButton.TabIndex = 2;
            this.viewDocButton.Text = "просмотр";
            this.viewDocButton.UseVisualStyleBackColor = true;
            this.viewDocButton.Click += new System.EventHandler(this.viewDocButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(843, 140);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 31);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.viewDocButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.viewScanImgButton);
            this.groupBox1.Controls.Add(this.docBox);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.scannedDocBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 214);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новый документ";
            // 
            // recentDocGroup
            // 
            this.recentDocGroup.Controls.Add(this.recentDocList);
            this.recentDocGroup.Controls.Add(this.openDocButton);
            this.recentDocGroup.Controls.Add(this.cloneButton);
            this.recentDocGroup.Location = new System.Drawing.Point(981, 16);
            this.recentDocGroup.Name = "recentDocGroup";
            this.recentDocGroup.Size = new System.Drawing.Size(372, 210);
            this.recentDocGroup.TabIndex = 8;
            this.recentDocGroup.TabStop = false;
            this.recentDocGroup.Text = "Последние созданные документы";
            // 
            // recentDocList
            // 
            this.recentDocList.FormattingEnabled = true;
            this.recentDocList.Location = new System.Drawing.Point(18, 24);
            this.recentDocList.Name = "recentDocList";
            this.recentDocList.Size = new System.Drawing.Size(338, 134);
            this.recentDocList.TabIndex = 9;
            // 
            // openDocButton
            // 
            this.openDocButton.Location = new System.Drawing.Point(247, 164);
            this.openDocButton.Name = "openDocButton";
            this.openDocButton.Size = new System.Drawing.Size(109, 27);
            this.openDocButton.TabIndex = 11;
            this.openDocButton.Text = "Открыть";
            this.openDocButton.UseVisualStyleBackColor = true;
            this.openDocButton.Click += new System.EventHandler(this.openDocButton_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.Location = new System.Drawing.Point(132, 164);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(109, 27);
            this.cloneButton.TabIndex = 10;
            this.cloneButton.Text = "Клонировать";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // NewDocForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.recentDocGroup);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Новый документ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewDocForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.recentDocGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox docBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scannedDocBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button viewScanImgButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button viewDocButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox recentDocGroup;
        private System.Windows.Forms.Button openDocButton;
        private System.Windows.Forms.Button cloneButton;
        private System.Windows.Forms.ListBox recentDocList;
    }
}