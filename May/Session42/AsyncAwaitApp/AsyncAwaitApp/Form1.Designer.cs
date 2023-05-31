namespace AsyncAwaitApp
{
    partial class Form1
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
            btn_Hello = new Button();
            btn_sync = new Button();
            btnTask_1 = new Button();
            btnPrintAsync1 = new Button();
            btnPrintAsync2 = new Button();
            SuspendLayout();
            // 
            // btn_Hello
            // 
            btn_Hello.BackColor = Color.Red;
            btn_Hello.ForeColor = SystemColors.ActiveCaptionText;
            btn_Hello.Location = new Point(111, 101);
            btn_Hello.Name = "btn_Hello";
            btn_Hello.Size = new Size(75, 72);
            btn_Hello.TabIndex = 0;
            btn_Hello.Text = "button1";
            btn_Hello.UseVisualStyleBackColor = false;
            btn_Hello.Click += btnHello_Click;
            // 
            // btn_sync
            // 
            btn_sync.BackColor = SystemColors.ActiveCaption;
            btn_sync.Location = new Point(370, 107);
            btn_sync.Name = "btn_sync";
            btn_sync.Size = new Size(75, 60);
            btn_sync.TabIndex = 1;
            btn_sync.Text = "PrintSync";
            btn_sync.UseVisualStyleBackColor = false;
            btn_sync.Click += btnPrintSync_Click;
            // 
            // btnTask_1
            // 
            btnTask_1.BackColor = Color.Red;
            btnTask_1.ForeColor = SystemColors.ActiveCaptionText;
            btnTask_1.Location = new Point(634, 101);
            btnTask_1.Name = "btnTask_1";
            btnTask_1.Size = new Size(75, 72);
            btnTask_1.TabIndex = 2;
            btnTask_1.Text = "Task1";
            btnTask_1.UseVisualStyleBackColor = false;
            btnTask_1.Click += btnTask_1_Click;
            // 
            // btnPrintAsync1
            // 
            btnPrintAsync1.BackColor = Color.Red;
            btnPrintAsync1.ForeColor = SystemColors.ActiveCaptionText;
            btnPrintAsync1.Location = new Point(143, 262);
            btnPrintAsync1.Name = "btnPrintAsync1";
            btnPrintAsync1.Size = new Size(157, 72);
            btnPrintAsync1.TabIndex = 3;
            btnPrintAsync1.Text = "PrintAsync1";
            btnPrintAsync1.UseVisualStyleBackColor = false;
            btnPrintAsync1.Click += btnPrintAsync1_Click;
            // 
            // btnPrintAsync2
            // 
            btnPrintAsync2.BackColor = Color.Red;
            btnPrintAsync2.ForeColor = SystemColors.ActiveCaptionText;
            btnPrintAsync2.Location = new Point(464, 262);
            btnPrintAsync2.Name = "btnPrintAsync2";
            btnPrintAsync2.Size = new Size(157, 72);
            btnPrintAsync2.TabIndex = 4;
            btnPrintAsync2.Text = "PrintAsync2";
            btnPrintAsync2.UseVisualStyleBackColor = false;
            btnPrintAsync2.Click += btnPrintAsync2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrintAsync2);
            Controls.Add(btnPrintAsync1);
            Controls.Add(btnTask_1);
            Controls.Add(btn_sync);
            Controls.Add(btn_Hello);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Hello;
        private Button btn_sync;
        private Button btnTask_1;
        private Button btnPrintAsync1;
        private Button btnPrintAsync2;
    }
}