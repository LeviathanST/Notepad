using System;
using System.Windows.Forms;

namespace MyNotepad_self
{
    public partial class Form1 : Form
    {
        string fileName = "No name";
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveSetting()
        {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Font = txtWord.Font;
            Properties.Settings.Default.Save();
        }

        private void LoadSetting()
        {
            this.Location = Properties.Settings.Default.Location;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;
            txtWord.Font = Properties.Settings.Default.Font;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSetting();

            this.Text = "Notedpad - " + fileName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSetting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = txtWord.Font;
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtWord.Font = fontDialog1.Font;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName; // Cập nhật fileName với tên file mới
                System.IO.File.WriteAllText(fileName, txtWord.Text);
                this.Text = "Notedpad + " + fileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "No name")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, txtWord.Text);
                this.Text = "Notepad + " + fileName;
            }
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            if (txtWord.Modified)
            {
                this.Text = "Notepad - " + fileName + " *";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtWord.Modified)
            {
                var result = MessageBox.Show("Do you want to save your changes?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(null, null);
                }
                else if (result == DialogResult.Cancel)
                {
                    // Nếu người dùng chọn Cancel thì quá trình mở file sẽ bị hủy 
                    return;
                }
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                txtWord.Text = System.IO.File.ReadAllText(fileName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = "No name";
            txtWord.Text = " ";
            this.Text = "Notepad - " + fileName;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtWord.CanUndo == true)
            {
                txtWord.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                txtWord.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWord.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWord.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWord.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtWord.SelectAll();
        }
    }
}
