
namespace FOR_BD
{
    partial class Enter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enter));
            this.caseprocessDataSet = new FOR_BD.CaseprocessDataSet();
            this.auth1 = new System.Windows.Forms.Button();
            this.nickname = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // caseprocessDataSet
            // 
            this.caseprocessDataSet.DataSetName = "CaseprocessDataSet";
            this.caseprocessDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // auth1
            // 
            this.auth1.Location = new System.Drawing.Point(21, 77);
            this.auth1.Name = "auth1";
            this.auth1.Size = new System.Drawing.Size(258, 39);
            this.auth1.TabIndex = 0;
            this.auth1.Text = "Авторизация";
            this.auth1.UseVisualStyleBackColor = true;
            this.auth1.Click += new System.EventHandler(this.auth1_Click);
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(21, 12);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(258, 22);
            this.nickname.TabIndex = 2;
            this.nickname.Text = "Имя";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(21, 40);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(258, 22);
            this.password.TabIndex = 3;
            this.password.Text = "Пароль";
            // 
            // Enter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 124);
            this.Controls.Add(this.password);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.auth1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Enter";
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CaseprocessDataSet caseprocessDataSet;
        private System.Windows.Forms.Button auth1;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.TextBox password;
    }
}

