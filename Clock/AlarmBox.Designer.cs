namespace Clock
{
	partial class AlarmBox
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
			this.components = new System.ComponentModel.Container();
			this.gBx = new System.Windows.Forms.GroupBox();
			this.OnOff_Alarm = new System.Windows.Forms.CheckBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.OneTime = new System.Windows.Forms.CheckBox();
			this.chcdWeekDay = new System.Windows.Forms.CheckedListBox();
			this.deleteButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.gBx.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBx
			// 
			this.gBx.Controls.Add(this.OnOff_Alarm);
			this.gBx.Controls.Add(this.dateTimePicker1);
			this.gBx.Controls.Add(this.OneTime);
			this.gBx.Controls.Add(this.chcdWeekDay);
			this.gBx.Controls.Add(this.deleteButton);
			this.gBx.Location = new System.Drawing.Point(0, 0);
			this.gBx.Name = "gBx";
			this.gBx.Size = new System.Drawing.Size(539, 51);
			this.gBx.TabIndex = 0;
			this.gBx.TabStop = false;
			this.gBx.Text = "Будильник";
			// 
			// OnOff_Alarm
			// 
			this.OnOff_Alarm.AutoSize = true;
			this.OnOff_Alarm.Checked = true;
			this.OnOff_Alarm.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OnOff_Alarm.ImageKey = "(none)";
			this.OnOff_Alarm.Location = new System.Drawing.Point(79, 13);
			this.OnOff_Alarm.Name = "OnOff_Alarm";
			this.OnOff_Alarm.Size = new System.Drawing.Size(77, 17);
			this.OnOff_Alarm.TabIndex = 9;
			this.OnOff_Alarm.Text = "Вкл/Выкл";
			this.OnOff_Alarm.UseVisualStyleBackColor = true;
			this.OnOff_Alarm.CheckedChanged += new System.EventHandler(this.OnOff_Alarm_CheckedChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePicker1.CustomFormat = "HH:mm";
			this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(9, 16);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(64, 26);
			this.dateTimePicker1.TabIndex = 8;
			this.dateTimePicker1.Value = new System.DateTime(2026, 1, 12, 1, 42, 4, 115);
			this.dateTimePicker1.EnabledChanged += new System.EventHandler(this.dateTimePicker1_EnabledChanged);
			// 
			// OneTime
			// 
			this.OneTime.AutoSize = true;
			this.OneTime.Location = new System.Drawing.Point(79, 30);
			this.OneTime.Name = "OneTime";
			this.OneTime.Size = new System.Drawing.Size(74, 17);
			this.OneTime.TabIndex = 3;
			this.OneTime.Text = "Один Раз";
			this.OneTime.UseVisualStyleBackColor = true;
			this.OneTime.CheckedChanged += new System.EventHandler(this.OneTime_CheckedChanged);
			// 
			// chcdWeekDay
			// 
			this.chcdWeekDay.ColumnWidth = 33;
			this.chcdWeekDay.FormattingEnabled = true;
			this.chcdWeekDay.Location = new System.Drawing.Point(159, 19);
			this.chcdWeekDay.MultiColumn = true;
			this.chcdWeekDay.Name = "chcdWeekDay";
			this.chcdWeekDay.Size = new System.Drawing.Size(239, 19);
			this.chcdWeekDay.TabIndex = 2;
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(458, 15);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 1;
			this.deleteButton.Text = "Delete";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
			// 
			// AlarmBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gBx);
			this.Name = "AlarmBox";
			this.Size = new System.Drawing.Size(559, 51);
			this.gBx.ResumeLayout(false);
			this.gBx.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gBx;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.CheckBox OneTime;
		private System.Windows.Forms.CheckedListBox chcdWeekDay;
		private System.Windows.Forms.CheckBox OnOff_Alarm;
		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}
