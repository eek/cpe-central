﻿using CPECentral.Controls;

namespace CPECentral.Views
{
    partial class PartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.operationsView = new CPECentral.Views.OperationsView();
            this.operationsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.partTabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modifiedByLabel = new System.Windows.Forms.Label();
            this.createdByLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.documentPreviewPanel = new FilePreviewPanel();
            this.partInformationView = new CPECentral.Views.PartInformationView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.operationsTabControl.SuspendLayout();
            this.partTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.operationsView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.operationsTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(374, 363);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 7;
            // 
            // operationsView
            // 
            this.operationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsView.Location = new System.Drawing.Point(0, 0);
            this.operationsView.Name = "operationsView";
            this.operationsView.Size = new System.Drawing.Size(374, 186);
            this.operationsView.TabIndex = 3;
            this.operationsView.OperationSelected += new System.EventHandler<CPECentral.CustomEventArgs.OperationEventArgs>(this.operationsView1_OperationSelected);
            // 
            // operationsTabControl
            // 
            this.operationsTabControl.Controls.Add(this.tabPage2);
            this.operationsTabControl.Controls.Add(this.tabPage1);
            this.operationsTabControl.Controls.Add(this.tabPage5);
            this.operationsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsTabControl.Enabled = false;
            this.operationsTabControl.ItemSize = new System.Drawing.Size(140, 22);
            this.operationsTabControl.Location = new System.Drawing.Point(0, 0);
            this.operationsTabControl.Name = "operationsTabControl";
            this.operationsTabControl.SelectedIndex = 0;
            this.operationsTabControl.Size = new System.Drawing.Size(374, 173);
            this.operationsTabControl.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 143);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operation documents";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(367, 143);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tool list";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(367, 143);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Notes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // partTabControl
            // 
            this.partTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partTabControl.Controls.Add(this.tabPage3);
            this.partTabControl.Controls.Add(this.tabPage4);
            this.partTabControl.ItemSize = new System.Drawing.Size(140, 22);
            this.partTabControl.Location = new System.Drawing.Point(333, 53);
            this.partTabControl.Name = "partTabControl";
            this.partTabControl.SelectedIndex = 0;
            this.partTabControl.Size = new System.Drawing.Size(502, 239);
            this.partTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.partTabControl.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(494, 209);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Version documents";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(496, 209);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Part documents";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(838, 2);
            this.label3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.modifiedByLabel);
            this.panel1.Controls.Add(this.createdByLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 47);
            this.panel1.TabIndex = 1;
            // 
            // modifiedByLabel
            // 
            this.modifiedByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifiedByLabel.AutoSize = true;
            this.modifiedByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifiedByLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.modifiedByLabel.Location = new System.Drawing.Point(748, 26);
            this.modifiedByLabel.Margin = new System.Windows.Forms.Padding(3);
            this.modifiedByLabel.Name = "modifiedByLabel";
            this.modifiedByLabel.Size = new System.Drawing.Size(87, 17);
            this.modifiedByLabel.TabIndex = 1;
            this.modifiedByLabel.Text = "Modified by:";
            // 
            // createdByLabel
            // 
            this.createdByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdByLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.createdByLabel.Location = new System.Drawing.Point(757, 3);
            this.createdByLabel.Margin = new System.Windows.Forms.Padding(3);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(78, 17);
            this.createdByLabel.TabIndex = 1;
            this.createdByLabel.Text = "Created by:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.CompanyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(7, 298);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.documentPreviewPanel);
            this.splitContainer2.Size = new System.Drawing.Size(828, 363);
            this.splitContainer2.SplitterDistance = 374;
            this.splitContainer2.TabIndex = 8;
            // 
            // documentPreviewPanel
            // 
            this.documentPreviewPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("documentPreviewPanel.BackgroundImage")));
            this.documentPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.documentPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentPreviewPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentPreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.documentPreviewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentPreviewPanel.Name = "documentPreviewPanel";
            this.documentPreviewPanel.Size = new System.Drawing.Size(450, 363);
            this.documentPreviewPanel.TabIndex = 7;
            // 
            // partInformationView
            // 
            this.partInformationView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInformationView.Location = new System.Drawing.Point(7, 53);
            this.partInformationView.Name = "partInformationView";
            this.partInformationView.Size = new System.Drawing.Size(320, 239);
            this.partInformationView.TabIndex = 0;
            this.partInformationView.VersionSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartVersionEventArgs>(this.partInformationView_VersionSelected);
            // 
            // PartView
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.partTabControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.partInformationView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartView";
            this.Size = new System.Drawing.Size(838, 664);
            this.Load += new System.EventHandler(this.PartView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.operationsTabControl.ResumeLayout(false);
            this.partTabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PartInformationView partInformationView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label modifiedByLabel;
        private System.Windows.Forms.Label createdByLabel;
        private OperationsView operationsView;
        private System.Windows.Forms.TabControl operationsTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl partTabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FilePreviewPanel documentPreviewPanel;


    }
}
