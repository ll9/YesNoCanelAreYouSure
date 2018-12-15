using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesNoCanelAreYouSure.Utils;

namespace YesNoCanelAreYouSure.Presenter
{
    public class Presenter
    {
        private readonly IForm1 _form;

        public Presenter(IForm1 form)
        {
            _form = form;
            InitEvents();
        }

        private void InitEvents()
        {
            _form.Trigger += OpenYesNoCanelDialog;
        }

        private void OpenYesNoCanelDialog(object sender, EventArgs e)
        {
            var shouldSaveTempProject = new YesNoAreYouSureDialog().NoAreYouSure(
                "Soll das temporäre Projekt gespeichert werden?", "Projekt Speichern");

            if (shouldSaveTempProject == DialogResult.Yes)
            {
                MessageBox.Show("Saving...");
            } 
            else if (shouldSaveTempProject == DialogResult.No)
            {
                MessageBox.Show("Not Saving");
            }
            else if (shouldSaveTempProject == DialogResult.Cancel)
            {
                MessageBox.Show("Canceling");
            }
        }

    }
}
