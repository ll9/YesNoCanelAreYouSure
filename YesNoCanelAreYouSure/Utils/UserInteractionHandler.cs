using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YesNoCanelAreYouSure.Utils
{
    public class GUIHandler : IGUIHandler
    {
        public DialogResult YesNoCancelDialog(string message, string caption, MessageBoxButtons buttons)
        {
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);
            return result;
        }
    }
}
