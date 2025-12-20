using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.labelTime = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.cb_ShowDate = new System.Windows.Forms.CheckBox();
			this.cb_ShowWeekday = new System.Windows.Forms.CheckBox();
			this.btn_HideControls = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.SuspendLayout();
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.labelTime.Cursor = System.Windows.Forms.Cursors.PanNW;
			this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTime.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelTime.Location = new System.Drawing.Point(50, 9);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(224, 42);
			this.labelTime.TabIndex = 0;
			this.labelTime.Text = "CurrentTime";
			this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.labelTime.Click += new System.EventHandler(this.labelTime_Click);
			this.labelTime.MouseHover += new System.EventHandler(this.labelTime_MouseHover);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// cb_ShowDate
			// 
			this.cb_ShowDate.AutoSize = true;
			this.cb_ShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_ShowDate.Location = new System.Drawing.Point(20, 226);
			this.cb_ShowDate.Name = "cb_ShowDate";
			this.cb_ShowDate.Size = new System.Drawing.Size(176, 29);
			this.cb_ShowDate.TabIndex = 1;
			this.cb_ShowDate.Text = "Показать дату";
			this.cb_ShowDate.UseVisualStyleBackColor = true;
			// 
			// cb_ShowWeekday
			// 
			this.cb_ShowWeekday.AutoSize = true;
			this.cb_ShowWeekday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_ShowWeekday.Location = new System.Drawing.Point(20, 261);
			this.cb_ShowWeekday.Name = "cb_ShowWeekday";
			this.cb_ShowWeekday.Size = new System.Drawing.Size(254, 31);
			this.cb_ShowWeekday.TabIndex = 2;
			this.cb_ShowWeekday.Text = "Показать день недели";
			this.cb_ShowWeekday.UseCompatibleTextRendering = true;
			this.cb_ShowWeekday.UseVisualStyleBackColor = true;
			// 
			// btn_HideControls
			// 
			this.btn_HideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_HideControls.Location = new System.Drawing.Point(20, 315);
			this.btn_HideControls.Name = "btn_HideControls";
			this.btn_HideControls.Size = new System.Drawing.Size(254, 100);
			this.btn_HideControls.TabIndex = 3;
			this.btn_HideControls.Text = "Hide controls";
			this.btn_HideControls.UseVisualStyleBackColor = true;
			this.btn_HideControls.Click += new System.EventHandler(this.btn_HideControls_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "System tray";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 445);
			this.Controls.Add(this.btn_HideControls);
			this.Controls.Add(this.cb_ShowWeekday);
			this.Controls.Add(this.cb_ShowDate);
			this.Controls.Add(this.labelTime);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = FormStartPosition.Manual;
			
			this.Text = "Clock PV_521";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox cb_ShowDate;
		private System.Windows.Forms.CheckBox cb_ShowWeekday;
		private System.Windows.Forms.Button btn_HideControls;
		private System.Windows.Forms.NotifyIcon notifyIcon;
	}
}

