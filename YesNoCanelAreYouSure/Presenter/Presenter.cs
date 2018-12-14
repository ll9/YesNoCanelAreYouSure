using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesNoCanelAreYouSure.Presenter
{
    public class Presenter
    {
        private readonly IForm1 _form;

        public Presenter(IForm1 form)
        {
            _form = form;
        }
    }
}
