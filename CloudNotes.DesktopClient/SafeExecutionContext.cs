using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
    /// <summary>
    /// Represents the application execution context within which
    /// the exception will be handled.
    /// </summary>
    public static class SafeExecutionContext
    {
        public static void Execute(Form form, Action body, Action initialize = null, Action cleanup = null)
        {
            try
            {
                form.Cursor = Cursors.WaitCursor;
                if (initialize != null)
                {
                    initialize();
                }
                body();
            }
            catch (Exception exc)
            {
                FrmExceptionDialog.ShowException(exc);
            }
            finally
            {
                if (cleanup != null)
                {
                    cleanup();
                }
                form.Cursor = Cursors.Default;
            }
        }

        public static async Task ExecuteAsync(Form form, Func<Task> body, Action initialize = null, Action cleanup = null)
        {
            try
            {
                form.Cursor = Cursors.WaitCursor;
                if (initialize != null)
                {
                    initialize();
                }
                await body();
            }
            catch (Exception exc)
            {
                FrmExceptionDialog.ShowException(exc);
            }
            finally
            {
                if (cleanup != null)
                {
                    cleanup();
                }
                form.Cursor = Cursors.Default;
            }
        }
    }
}
