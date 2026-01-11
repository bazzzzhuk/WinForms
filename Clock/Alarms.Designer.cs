namespace Clock
{
	partial class AlarmsDialog
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
			this.AddButton = new System.Windows.Forms.Button();
			this.flowLP = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(20, 415);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(146, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// flowLP
			// 
			this.flowLP.AutoScroll = true;
			this.flowLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLP.Location = new System.Drawing.Point(13, 13);
			this.flowLP.Name = "flowLP";
			this.flowLP.Size = new System.Drawing.Size(668, 251);
			this.flowLP.TabIndex = 2;
			this.flowLP.WrapContents = false;
			// 
			// AlarmsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(693, 450);
			this.Controls.Add(this.flowLP);
			this.Controls.Add(this.AddButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "AlarmsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Alarms";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.FlowLayoutPanel flowLP;
	}
}