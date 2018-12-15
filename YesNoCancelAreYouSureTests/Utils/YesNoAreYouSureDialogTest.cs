using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesNoCanelAreYouSure.Utils;

namespace YesNoCancelAreYouSureTests.Utils
{
    [TestFixture]
    class YesNoAreYouSureDialogTest
    {
        private Mock<IGUIHandler> _guiHandler;
        private YesNoAreYouSureDialog _dialog;

        [SetUp]
        public void Setup()
        {
            _guiHandler = new Mock<IGUIHandler>();
            _dialog = new YesNoAreYouSureDialog(_guiHandler.Object);
        }

        /// <summary>
        /// Test Cases:
        /// 1. Yes => return DialogResult Yes
        /// 2. Cancel => return DialogResult Cancel
        /// 3. No 
        /// 3.1 Yes return No
        /// 3.2 Cancel return Cancel
        /// 3.3 return Show
        /// </summary>
        [TestCase(DialogResult.Yes, ExpectedResult = DialogResult.Yes)]
        [TestCase(DialogResult.Cancel, ExpectedResult = DialogResult.Cancel)]
        [TestCase(new[] { DialogResult.No, DialogResult.Yes }, ExpectedResult = DialogResult.No)]
        [TestCase(new[] { DialogResult.No, DialogResult.Cancel }, ExpectedResult = DialogResult.Cancel)]
        [TestCase(new[] { DialogResult.No, DialogResult.No, DialogResult.Yes }, ExpectedResult = DialogResult.Yes)]
        [TestCase(new[] { DialogResult.No, DialogResult.No, DialogResult.Cancel }, ExpectedResult = DialogResult.Cancel)]
        public DialogResult Show_WhenCalled_ReturnsResult(params DialogResult[] res)
        {
            _guiHandler.Setup(g => g.YesNoCancelDialog(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.YesNoCancel))
                .Returns(new Queue<DialogResult>(res).Dequeue);

            return _dialog.NoAreYouSure(It.IsAny<string>(), It.IsAny<string>());
        }
    }
}
