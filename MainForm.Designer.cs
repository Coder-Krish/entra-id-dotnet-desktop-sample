namespace demo_azure
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            RichTextBox infoPara;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            apiResult = new RichTextBox();
            label1 = new Label();
            infoPara = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(681, 12);
            button1.Name = "button1";
            button1.Size = new Size(107, 42);
            button1.TabIndex = 0;
            button1.Text = "Fetch Data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // apiResult
            // 
            apiResult.BackColor = SystemColors.InactiveCaptionText;
            apiResult.ForeColor = Color.SpringGreen;
            apiResult.Location = new Point(12, 139);
            apiResult.Name = "apiResult";
            apiResult.Size = new Size(776, 274);
            apiResult.TabIndex = 1;
            apiResult.Text = "";
            apiResult.TextChanged += apiResult_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 2;
            label1.Click += label1_Click;
            // 
            // infoPara
            // 
            infoPara.BorderStyle = BorderStyle.None;
            infoPara.Enabled = false;
            infoPara.Location = new Point(12, 61);
            infoPara.Name = "infoPara";
            infoPara.ReadOnly = true;
            infoPara.Size = new Size(776, 72);
            infoPara.TabIndex = 3;
            infoPara.Text = resources.GetString("infoPara.Text");
            infoPara.TextChanged += infoPara_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(infoPara);
            Controls.Add(label1);
            Controls.Add(apiResult);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox apiResult;
        private Label label1;
        private RichTextBox infoPara;
    }
}
