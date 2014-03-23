﻿namespace CPECentral.Controls
{
    partial class SettingsPathsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.drawingFileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectDrawingDirButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sharedAppDirDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectSharedAppDirButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.turningCamTemplateTextBox = new System.Windows.Forms.TextBox();
            this.millingCamTemplateTextBox = new System.Windows.Forms.TextBox();
            this.selectTurningTemplateButton = new System.Windows.Forms.Button();
            this.selectMillingTemplateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drawing file directory";
            // 
            // drawingFileDirectoryTextBox
            // 
            this.drawingFileDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingFileDirectoryTextBox.Location = new System.Drawing.Point(13, 89);
            this.drawingFileDirectoryTextBox.Name = "drawingFileDirectoryTextBox";
            this.drawingFileDirectoryTextBox.ReadOnly = true;
            this.drawingFileDirectoryTextBox.Size = new System.Drawing.Size(482, 25);
            this.drawingFileDirectoryTextBox.TabIndex = 1;
            // 
            // selectDrawingDirButton
            // 
            this.selectDrawingDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDrawingDirButton.Location = new System.Drawing.Point(501, 89);
            this.selectDrawingDirButton.Name = "selectDrawingDirButton";
            this.selectDrawingDirButton.Size = new System.Drawing.Size(30, 25);
            this.selectDrawingDirButton.TabIndex = 2;
            this.selectDrawingDirButton.Text = "..";
            this.selectDrawingDirButton.UseVisualStyleBackColor = true;
            this.selectDrawingDirButton.Click += new System.EventHandler(this.dataDirectoriesButton_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shared app directory";
            // 
            // sharedAppDirDirectoryTextBox
            // 
            this.sharedAppDirDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sharedAppDirDirectoryTextBox.Location = new System.Drawing.Point(13, 41);
            this.sharedAppDirDirectoryTextBox.Name = "sharedAppDirDirectoryTextBox";
            this.sharedAppDirDirectoryTextBox.ReadOnly = true;
            this.sharedAppDirDirectoryTextBox.Size = new System.Drawing.Size(482, 25);
            this.sharedAppDirDirectoryTextBox.TabIndex = 1;
            // 
            // selectSharedAppDirButton
            // 
            this.selectSharedAppDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectSharedAppDirButton.Location = new System.Drawing.Point(501, 41);
            this.selectSharedAppDirButton.Name = "selectSharedAppDirButton";
            this.selectSharedAppDirButton.Size = new System.Drawing.Size(30, 25);
            this.selectSharedAppDirButton.TabIndex = 2;
            this.selectSharedAppDirButton.Text = "..";
            this.selectSharedAppDirButton.UseVisualStyleBackColor = true;
            this.selectSharedAppDirButton.Click += new System.EventHandler(this.dataDirectoriesButton_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Turning CAM file template";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Milling CAM file template";
            // 
            // turningCamTemplateTextBox
            // 
            this.turningCamTemplateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turningCamTemplateTextBox.Location = new System.Drawing.Point(9, 89);
            this.turningCamTemplateTextBox.Name = "turningCamTemplateTextBox";
            this.turningCamTemplateTextBox.ReadOnly = true;
            this.turningCamTemplateTextBox.Size = new System.Drawing.Size(482, 25);
            this.turningCamTemplateTextBox.TabIndex = 1;
            // 
            // millingCamTemplateTextBox
            // 
            this.millingCamTemplateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.millingCamTemplateTextBox.Location = new System.Drawing.Point(9, 41);
            this.millingCamTemplateTextBox.Name = "millingCamTemplateTextBox";
            this.millingCamTemplateTextBox.ReadOnly = true;
            this.millingCamTemplateTextBox.Size = new System.Drawing.Size(482, 25);
            this.millingCamTemplateTextBox.TabIndex = 1;
            // 
            // selectTurningTemplateButton
            // 
            this.selectTurningTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectTurningTemplateButton.Location = new System.Drawing.Point(497, 89);
            this.selectTurningTemplateButton.Name = "selectTurningTemplateButton";
            this.selectTurningTemplateButton.Size = new System.Drawing.Size(30, 25);
            this.selectTurningTemplateButton.TabIndex = 2;
            this.selectTurningTemplateButton.Text = "..";
            this.selectTurningTemplateButton.UseVisualStyleBackColor = true;
            this.selectTurningTemplateButton.Click += new System.EventHandler(this.templatesButton_Clicked);
            // 
            // selectMillingTemplateButton
            // 
            this.selectMillingTemplateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectMillingTemplateButton.Location = new System.Drawing.Point(497, 41);
            this.selectMillingTemplateButton.Name = "selectMillingTemplateButton";
            this.selectMillingTemplateButton.Size = new System.Drawing.Size(30, 25);
            this.selectMillingTemplateButton.TabIndex = 2;
            this.selectMillingTemplateButton.Text = "..";
            this.selectMillingTemplateButton.UseVisualStyleBackColor = true;
            this.selectMillingTemplateButton.Click += new System.EventHandler(this.templatesButton_Clicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.selectMillingTemplateButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.turningCamTemplateTextBox);
            this.groupBox1.Controls.Add(this.selectTurningTemplateButton);
            this.groupBox1.Controls.Add(this.millingCamTemplateTextBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 169);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Templates";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.selectSharedAppDirButton);
            this.groupBox2.Controls.Add(this.drawingFileDirectoryTextBox);
            this.groupBox2.Controls.Add(this.selectDrawingDirButton);
            this.groupBox2.Controls.Add(this.sharedAppDirDirectoryTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 154);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Directories";
            // 
            // SettingsPathsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsPathsUserControl";
            this.Size = new System.Drawing.Size(547, 388);
            this.Load += new System.EventHandler(this.PathSettingsUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox drawingFileDirectoryTextBox;
        private System.Windows.Forms.Button selectDrawingDirButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sharedAppDirDirectoryTextBox;
        private System.Windows.Forms.Button selectSharedAppDirButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox turningCamTemplateTextBox;
        private System.Windows.Forms.TextBox millingCamTemplateTextBox;
        private System.Windows.Forms.Button selectTurningTemplateButton;
        private System.Windows.Forms.Button selectMillingTemplateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
