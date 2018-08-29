namespace ActAud
{
    partial class FormClients
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.RefreshButton = new System.Windows.Forms.ToolStripButton();
			this.PCListView = new System.Windows.Forms.ListView();
			this.RefreshProgressBar = new System.Windows.Forms.ProgressBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.CancelRefreshButton = new System.Windows.Forms.Button();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(454, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// RefreshButton
			// 
			this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(65, 22);
			this.RefreshButton.Text = "Обновить";
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// PCListView
			// 
			this.PCListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PCListView.Location = new System.Drawing.Point(0, 25);
			this.PCListView.Name = "PCListView";
			this.PCListView.Size = new System.Drawing.Size(454, 301);
			this.PCListView.TabIndex = 1;
			this.PCListView.UseCompatibleStateImageBehavior = false;
			this.PCListView.View = System.Windows.Forms.View.List;
			this.PCListView.DoubleClick += new System.EventHandler(this.PCListView_DoubleClick);
			// 
			// RefreshProgressBar
			// 
			this.RefreshProgressBar.BackColor = System.Drawing.SystemColors.Control;
			this.RefreshProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RefreshProgressBar.Location = new System.Drawing.Point(0, 0);
			this.RefreshProgressBar.Name = "RefreshProgressBar";
			this.RefreshProgressBar.Size = new System.Drawing.Size(430, 23);
			this.RefreshProgressBar.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.RefreshProgressBar);
			this.panel1.Controls.Add(this.CancelRefreshButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 326);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(454, 23);
			this.panel1.TabIndex = 3;
			// 
			// CancelRefreshButton
			// 
			this.CancelRefreshButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CancelRefreshButton.Location = new System.Drawing.Point(430, 0);
			this.CancelRefreshButton.Name = "CancelRefreshButton";
			this.CancelRefreshButton.Size = new System.Drawing.Size(24, 23);
			this.CancelRefreshButton.TabIndex = 3;
			this.CancelRefreshButton.Text = "X";
			this.CancelRefreshButton.UseVisualStyleBackColor = true;
			this.CancelRefreshButton.Click += new System.EventHandler(this.CancelRefreshButton_Click);
			// 
			// FormClients
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 349);
			this.Controls.Add(this.PCListView);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormClients";
			this.Text = "Мониторинг событий информационной безопасности";
			this.Load += new System.EventHandler(this.OnFormClientsLoad);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton RefreshButton;
		private System.Windows.Forms.ListView PCListView;
		private System.Windows.Forms.ProgressBar RefreshProgressBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button CancelRefreshButton;

	}
}