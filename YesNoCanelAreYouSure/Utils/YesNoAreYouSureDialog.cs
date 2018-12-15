using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YesNoCanelAreYouSure.Utils
{
    public class YesNoAreYouSureDialog
    {
        private readonly IGUIHandler _guiHandler;

        public YesNoAreYouSureDialog(IGUIHandler guiHandler = null)
        {
            _guiHandler = guiHandler ?? new GUIHandler();
        }

        public DialogResult NoAreYouSure(
            string message, string caption,
            string areYouSureMessage = "Are You Sure?", string areYouSureCaption = "")
        {
            var result = _guiHandler.YesNoCancelDialog(
                message, caption, MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Cancel || result == DialogResult.Yes)
            {
                return result;
            }

            else
            {
                var areYouSure = _guiHandler.YesNoCancelDialog(
                    areYouSureMessage, areYouSureCaption, MessageBoxButtons.YesNoCancel
                );

                if (areYouSure == DialogResult.Cancel)
                {
                    return DialogResult.Cancel;
                }
                else if (areYouSure == DialogResult.Yes)
                {
                    return DialogResult.No;
                }
                else
                {
                    return NoAreYouSure(message, caption, areYouSureMessage, areYouSureCaption);
                }
            }
        }
    }
}
