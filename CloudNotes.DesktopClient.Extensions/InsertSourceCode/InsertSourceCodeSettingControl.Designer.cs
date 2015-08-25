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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertSourceCodeSettingControl));
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
            resources.ApplyResources(this.chkAutoLinks, "chkAutoLinks");
            this.chkAutoLinks.Name = "chkAutoLinks";
            this.chkAutoLinks.UseVisualStyleBackColor = true;
            // 
            // chkCollapse
            // 
            resources.ApplyResources(this.chkCollapse, "chkCollapse");
            this.chkCollapse.Name = "chkCollapse";
            this.chkCollapse.UseVisualStyleBackColor = true;
            // 
            // chkGutter
            // 
            resources.ApplyResources(this.chkGutter, "chkGutter");
            this.chkGutter.Name = "chkGutter";
            this.chkGutter.UseVisualStyleBackColor = true;
            // 
            // chkSmartTabs
            // 
            resources.ApplyResources(this.chkSmartTabs, "chkSmartTabs");
            this.chkSmartTabs.Name = "chkSmartTabs";
            this.chkSmartTabs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numTabSize
            // 
            resources.ApplyResources(this.numTabSize, "numTabSize");
            this.numTabSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
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
            this.numTabSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkShowToolbar
            // 
            resources.ApplyResources(this.chkShowToolbar, "chkShowToolbar");
            this.chkShowToolbar.Name = "chkShowToolbar";
            this.chkShowToolbar.UseVisualStyleBackColor = true;
            // 
            // InsertSourceCodeSettingControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowToolbar);
            this.Controls.Add(this.numTabSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSmartTabs);
            this.Controls.Add(this.chkGutter);
            this.Controls.Add(this.chkCollapse);
            this.Controls.Add(this.chkAutoLinks);
            this.Name = "InsertSourceCodeSettingControl";
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
