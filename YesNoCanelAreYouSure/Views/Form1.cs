using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YesNoCanelAreYouSure
{
    public partial class Form1 : Form, IForm1
    {
        public event EventHandler Trigger;

        public Form1()
        {
            InitializeComponent();
            var presenter = new Presenter.Presenter(this);
        }

        private void TriggerButton_Click(object sender, EventArgs e)
        {
            OnTrigger();
        }

        private void OnTrigger()
        {
            Trigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
