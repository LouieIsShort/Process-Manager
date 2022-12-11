namespace Process_Manager.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ProcessesTab = new System.Windows.Forms.TabPage();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.TerminateProcessButton = new System.Windows.Forms.Button();
            this.ProcessorDataGrid = new System.Windows.Forms.DataGridView();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.SettingsCheckBoxes = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.ProcessesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessorDataGrid)).BeginInit();
            this.SettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ProcessesTab);
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // ProcessesTab
            // 
            this.ProcessesTab.Controls.Add(this.RefreshButton);
            this.ProcessesTab.Controls.Add(this.TerminateProcessButton);
            this.ProcessesTab.Controls.Add(this.ProcessorDataGrid);
            this.ProcessesTab.Location = new System.Drawing.Point(4, 22);
            this.ProcessesTab.Name = "ProcessesTab";
            this.ProcessesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProcessesTab.Size = new System.Drawing.Size(768, 400);
            this.ProcessesTab.TabIndex = 0;
            this.ProcessesTab.Text = "Processes";
            this.ProcessesTab.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(687, 342);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // TerminateProcessButton
            // 
            this.TerminateProcessButton.Location = new System.Drawing.Point(687, 371);
            this.TerminateProcessButton.Name = "TerminateProcessButton";
            this.TerminateProcessButton.Size = new System.Drawing.Size(75, 23);
            this.TerminateProcessButton.TabIndex = 1;
            this.TerminateProcessButton.Text = "Terminate";
            this.TerminateProcessButton.UseVisualStyleBackColor = true;
            // 
            // ProcessorDataGrid
            // 
            this.ProcessorDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.ProcessorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessorDataGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProcessorDataGrid.Location = new System.Drawing.Point(7, 7);
            this.ProcessorDataGrid.Name = "ProcessorDataGrid";
            this.ProcessorDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessorDataGrid.Size = new System.Drawing.Size(674, 387);
            this.ProcessorDataGrid.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.SettingsCheckBoxes);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(768, 400);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // SettingsCheckBoxes
            // 
            this.SettingsCheckBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsCheckBoxes.FormattingEnabled = true;
            this.SettingsCheckBoxes.Items.AddRange(new object[] {
            "Auto Refresh",
            "Terminate Related Processes",
            "Group processes"});
            this.SettingsCheckBoxes.Location = new System.Drawing.Point(7, 7);
            this.SettingsCheckBoxes.Name = "SettingsCheckBoxes";
            this.SettingsCheckBoxes.Size = new System.Drawing.Size(755, 61);
            this.SettingsCheckBoxes.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Manager | Main";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.ProcessesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessorDataGrid)).EndInit();
            this.SettingsPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ProcessesTab;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button TerminateProcessButton;
        private System.Windows.Forms.DataGridView ProcessorDataGrid;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.CheckedListBox SettingsCheckBoxes;
    }
}