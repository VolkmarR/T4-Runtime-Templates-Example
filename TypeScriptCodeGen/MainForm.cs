using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TypeScriptCodeGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btAssembly_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                edAssembly.Text = ofd.FileName;
        }

        private void btOutput_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
                edOutput.Text = sfd.FileName;
        }

        private void btAnalyze_Click(object sender, EventArgs e)
        {
            var analyzer = new TypeScriptCodeGen.Analyzers.Analyzer(edAssembly.Text);
            if (!analyzer.Execute())
            {
                MessageBox.Show(analyzer.ParseError);
                return;
            }

            var generator = new TypeScriptCodeGen.Generators.TypeScriptProxy(analyzer);
            meGenerated.Text = generator.TransformText();
            btSave.Enabled = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(edOutput.Text, meGenerated.Text);
                MessageBox.Show("File saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error saving file{0}{1}", Environment.NewLine, ex.Message));
            }
        }
    }
}
