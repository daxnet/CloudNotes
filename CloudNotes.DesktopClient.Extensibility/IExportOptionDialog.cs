using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensibility
{
    public interface IExportOptionDialog
    {
        DialogResult ShowDialog();
        DialogResult ShowDialog(IWin32Window owner);
        object Options { get; }
    }
}
