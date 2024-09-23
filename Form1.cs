using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Model;
using Interface;
using Service;
using System.Windows.Forms;
using System.IO;
using Utils;

namespace app
{
    public partial class Form1 : Form
    { 
        private DocumentController _documentController;
        private Logger _logger;
        string fileName = "No name";
        public Form1()
        {
            InitializeComponent();

            Setting appSetting = new Setting { WorkingDirectory = "D:\\Documents" };
            _documentController = new DocumentController(appSetting);
            _logger = new Logger();

            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
        }

        private void Notepad_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = "No name";
            txtContent.Text = " ";
            this.Text = "Notepad - " + fileName;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string content = _documentController.LoadFromFile(filePath);  // Sử dụng DocumentController
                    txtContent.Text = content;
                    _logger.Log("File opened successfully.");  // Ghi log với Logger
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to open file: " + ex.Message);
                    MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    _documentController.WriteToFile(filePath, txtContent.Lines);  // Sử dụng DocumentController
                    _logger.Log("File saved successfully.");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to save file: " + ex.Message);
                    MessageBox.Show("Error saving file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtContent.CanUndo)
            {
                txtContent.Undo();
                _logger.Log("Undo action performed.");
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtContent.SelectedText != string.Empty)
            {
                Clipboard.SetText(txtContent.SelectedText);
                txtContent.SelectedText = string.Empty; // Xóa nội dung đã cắt
                _logger.Log("Cut action performed.");
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtContent.SelectedText != string.Empty)
            {
                Clipboard.SetText(txtContent.SelectedText);
                _logger.Log("Copy action performed.");
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtContent.Paste();
                _logger.Log("Paste action performed.");
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtContent.SelectAll();
            _logger.Log("Select All action performed.");
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtContent.Font = fontDialog.Font;
                _logger.Log("Font changed to " + fontDialog.Font.Name);
            }
        }

    }
}
