namespace YARTE.UI
{
    partial class HtmlEditor
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
            this.editcontrolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.updateToolBarTimer = new System.Windows.Forms.Timer(this.components);
            this.textWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // editcontrolsToolStrip
            // 
            this.editcontrolsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.editcontrolsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.editcontrolsToolStrip.Name = "editcontrolsToolStrip";
            this.editcontrolsToolStrip.Size = new System.Drawing.Size(557, 25);
            this.editcontrolsToolStrip.TabIndex = 1;
            this.editcontrolsToolStrip.Text = "editcontrolsToolStrip";
            // 
            // updateToolBarTimer
            // 
            this.updateToolBarTimer.Interval = 200;
            // 
            // textWebBrowser
            // 
            this.textWebBrowser.AllowNavigation = false;
            this.textWebBrowser.AllowWebBrowserDrop = false;
            this.textWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.textWebBrowser.Location = new System.Drawing.Point(0, 25);
            this.textWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.textWebBrowser.Name = "textWebBrowser";
            this.textWebBrowser.ScriptErrorsSuppressed = true;
            this.textWebBrowser.Size = new System.Drawing.Size(557, 449);
            this.textWebBrowser.TabIndex = 2;
            this.textWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textWebBrowser_PreviewKeyDown);
            // 
            // HtmlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textWebBrowser);
            this.Controls.Add(this.editcontrolsToolStrip);
            this.Name = "HtmlEditor";
            this.Size = new System.Drawing.Size(557, 474);
            this.ContextMenuStripChanged += new System.EventHandler(this.HtmlEditor_ContextMenuStripChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip editcontrolsToolStrip;
        private System.Windows.Forms.Timer updateToolBarTimer;
        private System.Windows.Forms.WebBrowser textWebBrowser;
    }
}
