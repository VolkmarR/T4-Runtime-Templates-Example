namespace TypeScriptCodeGen
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.meGenerated = new System.Windows.Forms.TextBox();
            this.btOutput = new System.Windows.Forms.Button();
            this.btAssembly = new System.Windows.Forms.Button();
            this.btAnalyze = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.edAssembly = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "dll";
            this.ofd.Filter = "Assembly|*.dll";
            this.ofd.Title = "WebApi Assembly";
            // 
            // meGenerated
            // 
            this.meGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meGenerated.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meGenerated.Location = new System.Drawing.Point(13, 68);
            this.meGenerated.Multiline = true;
            this.meGenerated.Name = "meGenerated";
            this.meGenerated.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.meGenerated.Size = new System.Drawing.Size(648, 370);
            this.meGenerated.TabIndex = 22;
            // 
            // btOutput
            // 
            this.btOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOutput.Location = new System.Drawing.Point(637, 444);
            this.btOutput.Name = "btOutput";
            this.btOutput.Size = new System.Drawing.Size(24, 20);
            this.btOutput.TabIndex = 21;
            this.btOutput.Text = "...";
            this.btOutput.UseVisualStyleBackColor = true;
            this.btOutput.Click += new System.EventHandler(this.btOutput_Click);
            // 
            // btAssembly
            // 
            this.btAssembly.Location = new System.Drawing.Point(637, 12);
            this.btAssembly.Name = "btAssembly";
            this.btAssembly.Size = new System.Drawing.Size(24, 20);
            this.btAssembly.TabIndex = 20;
            this.btAssembly.Text = "...";
            this.btAssembly.UseVisualStyleBackColor = true;
            this.btAssembly.Click += new System.EventHandler(this.btAssembly_Click);
            // 
            // btAnalyze
            // 
            this.btAnalyze.Location = new System.Drawing.Point(588, 37);
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btAnalyze.TabIndex = 19;
            this.btAnalyze.Text = "Analyze";
            this.btAnalyze.UseVisualStyleBackColor = true;
            this.btAnalyze.Click += new System.EventHandler(this.btAnalyze_Click);
            // 
            // edOutput
            // 
            this.edOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edOutput.Location = new System.Drawing.Point(135, 445);
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(496, 20);
            this.edOutput.TabIndex = 18;
            this.edOutput.Text = "GeneratedProxies.ts";
            // 
            // edAssembly
            // 
            this.edAssembly.Location = new System.Drawing.Point(135, 12);
            this.edAssembly.Name = "edAssembly";
            this.edAssembly.Size = new System.Drawing.Size(496, 20);
            this.edAssembly.TabIndex = 17;
            this.edAssembly.Text = "WebApi.dll";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "TS Proxy File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "WebApi Assembly";
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSave.Location = new System.Drawing.Point(584, 471);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "ts";
            this.sfd.Filter = "TypeScript Files|*.ts";
            this.sfd.Title = "Save TS Proxy File as...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 506);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.meGenerated);
            this.Controls.Add(this.btOutput);
            this.Controls.Add(this.btAssembly);
            this.Controls.Add(this.btAnalyze);
            this.Controls.Add(this.edOutput);
            this.Controls.Add(this.edAssembly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "TypeScript WebApi Proxy Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox meGenerated;
        private System.Windows.Forms.Button btOutput;
        private System.Windows.Forms.Button btAssembly;
        private System.Windows.Forms.Button btAnalyze;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.TextBox edAssembly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}

