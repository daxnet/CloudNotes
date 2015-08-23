namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    partial class InsertSourceCodeSettingControl
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
            this.chkAutoLinks = new System.Windows.Forms.CheckBox();
            this.chkCollapse = new System.Windows.Forms.CheckBox();
            this.chkGutter = new System.Windows.Forms.CheckBox();
            this.chkSmartTabs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numTabSize = new System.Windows.Forms.NumericUpDown();
            this.chkShowToolbar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTabSize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAutoLinks
            // 
            this.chkAutoLinks.AutoSize = true;
            this.chkAutoLinks.Location = new System.Drawing.Point(13, 16);
            this.chkAutoLinks.Name = "chkAutoLinks";
            this.chkAutoLinks.Size = new System.Drawing.Size(257, 17);
            this.chkAutoLinks.TabIndex = 0;
            this.chkAutoLinks.Text = "Auto detect hyperlinks in the highlighted element.";
            this.chkAutoLinks.UseVisualStyleBackColor = true;
            // 
            // chkCollapse
            // 
            this.chkCollapse.AutoSize = true;
            this.chkCollapse.Location = new System.Drawing.Point(13, 39);
            this.chkCollapse.Name = "chkCollapse";
            this.chkCollapse.Size = new System.Drawing.Size(339, 17);
            this.chkCollapse.TabIndex = 1;
            this.chkCollapse.Text = "Force highlighted elements on the page to be collapsed by default.";
            this.chkCollapse.UseVisualStyleBackColor = true;
            // 
            // chkGutter
            // 
            this.chkGutter.AutoSize = true;
            this.chkGutter.Location = new System.Drawing.Point(13, 62);
            this.chkGutter.Name = "chkGutter";
            this.chkGutter.Size = new System.Drawing.Size(282, 17);
            this.chkGutter.TabIndex = 2;
            this.chkGutter.Text = "Display the gutter with the line numbers at the left side.";
            this.chkGutter.UseVisualStyleBackColor = true;
            // 
            // chkSmartTabs
            // 
            this.chkSmartTabs.AutoSize = true;
            this.chkSmartTabs.Location = new System.Drawing.Point(13, 85);
            this.chkSmartTabs.Name = "chkSmartTabs";
            this.chkSmartTabs.Size = new System.Drawing.Size(167, 17);
            this.chkSmartTabs.TabIndex = 3;
            this.chkSmartTabs.Text = "Enable the smart tabs feature.";
            this.chkSmartTabs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tab size:";
            // 
            // numTabSize
            // 
            this.numTabSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTabSize.Location = new System.Drawing.Point(66, 108);
            this.numTabSize.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numTabSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTabSize.Name = "numTabSize";
            this.numTabSize.Size = new System.Drawing.Size(57, 20);
            this.numTabSize.TabIndex = 5;
            this.numTabSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkShowToolbar
            // 
            this.chkShowToolbar.AutoSize = true;
            this.chkShowToolbar.Location = new System.Drawing.Point(13, 134);
            this.chkShowToolbar.Name = "chkShowToolbar";
            this.chkShowToolbar.Size = new System.Drawing.Size(91, 17);
            this.chkShowToolbar.TabIndex = 6;
            this.chkShowToolbar.Text = "Show toolbar.";
            this.chkShowToolbar.UseVisualStyleBackColor = true;
            // 
            // InsertSourceCodeSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowToolbar);
            this.Controls.Add(this.numTabSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSmartTabs);
            this.Controls.Add(this.chkGutter);
            this.Controls.Add(this.chkCollapse);
            this.Controls.Add(this.chkAutoLinks);
            this.Name = "InsertSourceCodeSettingControl";
            this.Size = new System.Drawing.Size(534, 430);
            ((System.ComponentModel.ISupportInitialize)(this.numTabSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox chkAutoLinks;
        internal System.Windows.Forms.CheckBox chkCollapse;
        internal System.Windows.Forms.CheckBox chkGutter;
        internal System.Windows.Forms.CheckBox chkSmartTabs;
        internal System.Windows.Forms.NumericUpDown numTabSize;
        internal System.Windows.Forms.CheckBox chkShowToolbar;
    }
}
