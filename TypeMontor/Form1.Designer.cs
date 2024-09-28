using System.Windows.Forms;

namespace TypeMontor
{
    partial class TypeMontor
    {

        private System.ComponentModel.IContainer components = null;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeMenuItem;



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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeMontor));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            closeMenuItem = new ToolStripMenuItem();

            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(173, 107, 214);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "W.P.M";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(173, 107, 214);
            label2.Location = new Point(117, 11);
            label2.Name = "label2";
            label2.Size = new Size(40, 17);
            label2.TabIndex = 1;
            label2.Text = "Acc.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(173, 107, 214);
            label3.Location = new Point(71, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 2;
            label3.Text = "Avg.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(173, 107, 214);
            label4.Location = new Point(184, 11);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 3;
            label4.Text = "keystr.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DarkGray;
            label5.Location = new Point(208, 28);
            label5.Name = "label5";
            label5.Size = new Size(40, 17);
            label5.TabIndex = 4;
            label5.Text = "prev";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DarkGray;
            label6.Location = new Point(12, 28);
            label6.Name = "label6";
            label6.Size = new Size(40, 17);
            label6.TabIndex = 5;
            label6.Text = "prev";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.DarkGray;
            label7.Location = new Point(71, 28);
            label7.Name = "label7";
            label7.Size = new Size(40, 17);
            label7.TabIndex = 6;
            label7.Text = "prev";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkGray;
            label8.Location = new Point(117, 28);
            label8.Name = "label8";
            label8.Size = new Size(40, 17);
            label8.TabIndex = 7;
            label8.Text = "prev";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { closeMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(153, 48);
            // 
            // closeMenuItem
            // 
            closeMenuItem.Name = "closeMenuItem";
            closeMenuItem.Size = new Size(152, 22);
            closeMenuItem.Text = "Close";
            closeMenuItem.Click += new EventHandler(CloseMenuItem_Click);
            // 
            // TypeMontor
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(260, 54);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Cascadia Code", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TypeMontor";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.Manual;
            Text = "Form";
            TopMost = true;
            TransparencyKey = Color.White;
            ContextMenuStrip = contextMenuStrip1; // Attach the context menu to the form
            ResumeLayout(false);
            PerformLayout();
        }


        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        #endregion
    }
}