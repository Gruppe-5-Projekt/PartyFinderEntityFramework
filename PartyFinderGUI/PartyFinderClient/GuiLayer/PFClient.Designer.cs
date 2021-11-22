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
            this.labelProcessText = new System.Windows.Forms.Label();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.buttonGetEvents = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelHolder = new System.Windows.Forms.Label();
            this.labelEventId = new System.Windows.Forms.Label();
            this.labelEventName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.labelProcessText);
            this.groupBox1.Controls.Add(this.buttonDeleteEvent);
            this.groupBox1.Controls.Add(this.listBoxEvents);
            this.groupBox1.Controls.Add(this.buttonGetEvents);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 432);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Events";
            // 
            // labelProcessText
            // 
            this.labelProcessText.AutoSize = true;
            this.labelProcessText.Location = new System.Drawing.Point(358, 406);
            this.labelProcessText.Name = "labelProcessText";
            this.labelProcessText.Size = new System.Drawing.Size(27, 20);
            this.labelProcessText.TabIndex = 1;
            this.labelProcessText.Text = "---";
            this.labelProcessText.Click += new System.EventHandler(this.labelProcessText_Click);
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.Location = new System.Drawing.Point(83, 26);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(145, 33);
            this.buttonDeleteEvent.TabIndex = 2;
            this.buttonDeleteEvent.Text = "Delete Event";
            this.buttonDeleteEvent.UseVisualStyleBackColor = true;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.HorizontalScrollbar = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(12, 62);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(373, 364);
            this.listBoxEvents.TabIndex = 1;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // buttonGetEvents
            // 
            this.buttonGetEvents.Location = new System.Drawing.Point(234, 26);
            this.buttonGetEvents.Name = "buttonGetEvents";
            this.buttonGetEvents.Size = new System.Drawing.Size(145, 33);
            this.buttonGetEvents.TabIndex = 0;
            this.buttonGetEvents.Text = "Get All Events";
            this.buttonGetEvents.UseVisualStyleBackColor = true;
            this.buttonGetEvents.Click += new System.EventHandler(this.ButtonGetEvents_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxDescription);
            this.groupBox2.Controls.Add(this.labelDescription);
            this.groupBox2.Controls.Add(this.labelEndTime);
            this.groupBox2.Controls.Add(this.labelStartTime);
            this.groupBox2.Controls.Add(this.labelCapacity);
            this.groupBox2.Controls.Add(this.labelLocation);
            this.groupBox2.Controls.Add(this.labelHolder);
            this.groupBox2.Controls.Add(this.labelEventId);
            this.groupBox2.Controls.Add(this.labelEventName);
            this.groupBox2.Location = new System.Drawing.Point(397, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 429);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(17, 214);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PlaceholderText = "Description";
            this.textBoxDescription.Size = new System.Drawing.Size(365, 200);
            this.textBoxDescription.TabIndex = 8;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(17, 191);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(88, 20);
            this.labelDescription.TabIndex = 7;
            this.labelDescription.Text = "Description:";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(17, 171);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(71, 20);
            this.labelEndTime.TabIndex = 6;
            this.labelEndTime.Text = "End time:";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(17, 151);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(77, 20);
            this.labelStartTime.TabIndex = 5;
            this.labelStartTime.Text = "Start time:";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(17, 131);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(69, 20);
            this.labelCapacity.TabIndex = 4;
            this.labelCapacity.Text = "Capacity:";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(17, 111);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(69, 20);
            this.labelLocation.TabIndex = 3;
            this.labelLocation.Text = "Location:";
            // 
            // labelHolder
            // 
            this.labelHolder.AutoSize = true;
            this.labelHolder.Location = new System.Drawing.Point(17, 91);
            this.labelHolder.Name = "labelHolder";
            this.labelHolder.Size = new System.Drawing.Size(58, 20);
            this.labelHolder.TabIndex = 2;
            this.labelHolder.Text = "Holder:";
            // 
            // labelEventId
            // 
            this.labelEventId.AutoSize = true;
            this.labelEventId.Location = new System.Drawing.Point(17, 71);
            this.labelEventId.Name = "labelEventId";
            this.labelEventId.Size = new System.Drawing.Size(63, 20);
            this.labelEventId.TabIndex = 1;
            this.labelEventId.Text = "EventID:";
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(17, 51);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(89, 20);
            this.labelEventName.TabIndex = 0;
            this.labelEventName.Text = "Event name:";
            // 
            // PFClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PFClient";
            this.Text = "PartyFinderClient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listBoxEvents;
        private Button buttonGetEvents;
        private Label labelProcessText;
        private Button buttonDeleteEvent;
        private GroupBox groupBox2;
        private Label labelDescription;
        private Label labelEndTime;
        private Label labelStartTime;
        private Label labelCapacity;
        private Label labelLocation;
        private Label labelHolder;
        private Label labelEventId;
        private Label labelEventName;
        private TextBox textBoxDescription;
    }
}