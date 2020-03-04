namespace TRPO_curse_DB
{
    partial class FormConnetDB
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
            this.textBox_NameUser = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_NameUser = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_ConnectWithDB = new System.Windows.Forms.Label();
            this.button_SignIN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_NameUser
            // 
            this.textBox_NameUser.Location = new System.Drawing.Point(101, 172);
            this.textBox_NameUser.Name = "textBox_NameUser";
            this.textBox_NameUser.Size = new System.Drawing.Size(254, 20);
            this.textBox_NameUser.TabIndex = 0;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(101, 244);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(254, 20);
            this.textBox_Password.TabIndex = 1;
            // 
            // label_NameUser
            // 
            this.label_NameUser.AutoSize = true;
            this.label_NameUser.Location = new System.Drawing.Point(98, 146);
            this.label_NameUser.Name = "label_NameUser";
            this.label_NameUser.Size = new System.Drawing.Size(103, 13);
            this.label_NameUser.TabIndex = 2;
            this.label_NameUser.Text = "Имя пользователя";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(98, 217);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(45, 13);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Пароль";
            // 
            // label_ConnectWithDB
            // 
            this.label_ConnectWithDB.AutoSize = true;
            this.label_ConnectWithDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ConnectWithDB.Location = new System.Drawing.Point(147, 61);
            this.label_ConnectWithDB.Name = "label_ConnectWithDB";
            this.label_ConnectWithDB.Size = new System.Drawing.Size(188, 25);
            this.label_ConnectWithDB.TabIndex = 4;
            this.label_ConnectWithDB.Text = "Соединение с БД";
            // 
            // button_SignIN
            // 
            this.button_SignIN.Location = new System.Drawing.Point(167, 322);
            this.button_SignIN.Name = "button_SignIN";
            this.button_SignIN.Size = new System.Drawing.Size(124, 40);
            this.button_SignIN.TabIndex = 5;
            this.button_SignIN.Text = "Войти";
            this.button_SignIN.UseVisualStyleBackColor = true;
            this.button_SignIN.Click += new System.EventHandler(this.button_SignIN_Click);
            // 
            // FormConnetDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.button_SignIN);
            this.Controls.Add(this.label_ConnectWithDB);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_NameUser);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_NameUser);
            this.Name = "FormConnetDB";
            this.Text = "Соединение с БД";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_NameUser;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_NameUser;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_ConnectWithDB;
        private System.Windows.Forms.Button button_SignIN;
    }
}