using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleXorCipher.Forms
{
    public partial class StringKeyForm : Form
    {
        private Size _defaultSize;

        public StringKeyForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            _defaultSize = Size;
            keyTextBox.Text = Preferences.StringKey;
        }

        private void StringKeyForm_Load(object sender, EventArgs e)
        {
            Size = _defaultSize;
        }

        private void trimBtn_Click(object sender, EventArgs e)
        {
            keyTextBox.Text = keyTextBox.Text.Trim(' ', '\n', '\r');
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {
            Preferences.StringKey = keyTextBox.Text;
        }
    }
}
