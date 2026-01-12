using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleXorCipher.Forms
{
    public partial class IntKeyForm : Form
    {
        private Size _defaultSize;

        public IntKeyForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            _defaultSize = Size;
            keyNumeric.Value = Preferences.IntKey;
        }

        private void IntKeyForm_Load(object sender, EventArgs e)
        {
            Size = _defaultSize;
        }

        private void keyNumeric_ValueChanged(object sender, EventArgs e)
        {
            Preferences.IntKey = (int)keyNumeric.Value;
        }
    }
}
