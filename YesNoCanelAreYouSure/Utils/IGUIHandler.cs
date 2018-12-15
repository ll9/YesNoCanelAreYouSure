using System.Windows.Forms;

namespace YesNoCanelAreYouSure.Utils
{
    public interface IGUIHandler
    {
        DialogResult YesNoCancelDialog(string message, string caption, MessageBoxButtons buttons);
    }
}