using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_And_Decryption_Desktop
{
    public partial class SecureCrypt : Form
    {
        public SecureCrypt()
        {
            InitializeComponent();
            txbOutputEncryption.ReadOnly = true;
            txbOutputDecryption.ReadOnly = true;

            txbOutputEncryption.TabStop = false;
            txbOutputDecryption.TabStop = false;

            btnCopyEncryption.Enabled = false;
            btnCopyDecryption.Enabled = false;
        }
        string ShiftText(string text, int key)
        {
            StringBuilder output = new StringBuilder();

            foreach (char c in text)
            {
                output.Append((char)(c + key));
            }

            return output.ToString();
        }
        private void CopyText(string text)
        {
            Clipboard.SetText(text);

            MessageBox.Show(
                "Text copied successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEncryption_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbInputEncryption.Text))
            {
                MessageBox.Show(
                    "Please Enter Text Before Encrypting.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            txbOutputEncryption.Text = ShiftText(txbInputEncryption.Text,(int)nudEncryptionKey.Value);
            btnCopyEncryption.Enabled = true;
        }

        private void btnDecryption_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbInputDecryption.Text))
            {
                MessageBox.Show(
                    "Please Enter Text Before Decrypting.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            txbOutputDecryption.Text = ShiftText(txbInputDecryption.Text,-(int)nudDecryptionKey.Value);
            btnCopyDecryption.Enabled = true;
        }

        private void btnCopyEncryption_Click(object sender, EventArgs e)
        {
            CopyText(txbOutputEncryption.Text);
           
        }

        private void btnCopyDecryption_Click(object sender, EventArgs e)
        {
            CopyText(txbOutputDecryption.Text);          
        }

        private void btnClearEncryption_Click(object sender, EventArgs e)
        {
            txbInputEncryption.Clear();
            txbOutputEncryption.Clear();

            btnCopyEncryption.Enabled = false;

            txbInputEncryption.Focus();
        }

        private void btnClearDecryption_Click(object sender, EventArgs e)
        {
            txbInputDecryption.Clear();
            txbOutputDecryption.Clear();

            btnCopyDecryption.Enabled = false;

            txbInputDecryption.Focus();
        }

        private void txbOutputEncryption_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This field is read-only.",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txbInputEncryption.Focus();
        }

        private void txbOutputDecryption_Enter(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This field is read-only.",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txbInputDecryption.Focus();
        }
    }
}
