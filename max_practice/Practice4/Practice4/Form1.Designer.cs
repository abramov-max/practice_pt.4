namespace Practice4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRegUp = new System.Windows.Forms.Button();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRegUp
            // 
            this.buttonRegUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRegUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegUp.Location = new System.Drawing.Point(96, 69);
            this.buttonRegUp.Name = "buttonRegUp";
            this.buttonRegUp.Size = new System.Drawing.Size(442, 118);
            this.buttonRegUp.TabIndex = 0;
            this.buttonRegUp.Text = "Зарегистрироваться";
            this.buttonRegUp.UseVisualStyleBackColor = true;
            this.buttonRegUp.Click += new System.EventHandler(this.buttonRegUp_Click);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogIn.Location = new System.Drawing.Point(96, 235);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(442, 113);
            this.buttonLogIn.TabIndex = 1;
            this.buttonLogIn.Text = "Авторизироваться";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(619, 452);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.buttonRegUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRegUp;
        private System.Windows.Forms.Button buttonLogIn;
    }
}

