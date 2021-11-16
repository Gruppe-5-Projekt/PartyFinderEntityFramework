﻿namespace PartyFinderClient.GuiLayer
{
    partial class PFClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.buttonGetEvents = new System.Windows.Forms.Button();
            this.labelProcessText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxEvents);
            this.groupBox1.Controls.Add(this.buttonGetEvents);
            this.groupBox1.Location = new System.Drawing.Point(403, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Events";
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(6, 101);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(373, 304);
            this.listBoxEvents.TabIndex = 1;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // buttonGetEvents
            // 
            this.buttonGetEvents.Location = new System.Drawing.Point(224, 26);
            this.buttonGetEvents.Name = "buttonGetEvents";
            this.buttonGetEvents.Size = new System.Drawing.Size(155, 48);
            this.buttonGetEvents.TabIndex = 0;
            this.buttonGetEvents.Text = "Get All Events";
            this.buttonGetEvents.UseVisualStyleBackColor = true;
            this.buttonGetEvents.Click += new System.EventHandler(this.ButtonGetEvents_Click);
            // 
            // labelProcessText
            // 
            this.labelProcessText.AutoSize = true;
            this.labelProcessText.Location = new System.Drawing.Point(12, 391);
            this.labelProcessText.Name = "labelProcessText";
            this.labelProcessText.Size = new System.Drawing.Size(27, 20);
            this.labelProcessText.TabIndex = 1;
            this.labelProcessText.Text = "---";
            // 
            // PFClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelProcessText);
            this.Controls.Add(this.groupBox1);
            this.Name = "PFClient";
            this.Text = "PartyFinderClient";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listBoxEvents;
        private Button buttonGetEvents;
        private Label labelProcessText;
    }
}