namespace processManagement
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
            fileOpen = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            applyButton = new Button();
            restartCheck = new CheckBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // fileOpen
            // 
            fileOpen.Location = new Point(155, 62);
            fileOpen.Name = "fileOpen";
            fileOpen.Size = new Size(101, 45);
            fileOpen.TabIndex = 0;
            fileOpen.Text = "파일 열기";
            fileOpen.UseVisualStyleBackColor = true;
            fileOpen.Click += fileOpen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(155, 42);
            label1.Name = "label1";
            label1.Size = new Size(101, 17);
            label1.TabIndex = 1;
            label1.Text = "선택된 파일 위치";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("맑은 고딕", 9F);
            label2.Location = new Point(262, 42);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(41, 17);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(262, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(210, 23);
            comboBox1.TabIndex = 4;
            // 
            // applyButton
            // 
            applyButton.BackColor = SystemColors.Window;
            applyButton.Font = new Font("맑은 고딕", 18.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            applyButton.Location = new Point(292, 327);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(128, 51);
            applyButton.TabIndex = 6;
            applyButton.Text = "적용";
            applyButton.UseVisualStyleBackColor = false;
            applyButton.Click += applyButton_Click;
            // 
            // restartCheck
            // 
            restartCheck.AutoSize = true;
            restartCheck.BackColor = Color.LightGray;
            restartCheck.Font = new Font("맑은 고딕", 11F);
            restartCheck.Location = new Point(155, 171);
            restartCheck.Name = "restartCheck";
            restartCheck.Size = new Size(128, 24);
            restartCheck.TabIndex = 7;
            restartCheck.Text = "종료 시 재실행";
            restartCheck.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F);
            label3.Location = new Point(200, 126);
            label3.Name = "label3";
            label3.Size = new Size(54, 21);
            label3.TabIndex = 8;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 390);
            Controls.Add(label3);
            Controls.Add(restartCheck);
            Controls.Add(applyButton);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fileOpen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button fileOpen;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Button applyButton;
        private CheckBox restartCheck;
        private Label label3;
    }
}
