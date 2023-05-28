
namespace FOR_BD
{
    partial class AddAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAcc));
            this.CasesTree = new System.Windows.Forms.TreeView();
            this.UsersTree = new System.Windows.Forms.TreeView();
            this.cancel = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CasesTree
            // 
            this.CasesTree.Location = new System.Drawing.Point(12, 12);
            this.CasesTree.Name = "CasesTree";
            this.CasesTree.Size = new System.Drawing.Size(126, 370);
            this.CasesTree.TabIndex = 0;
            this.CasesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CasesTree_AfterSelect);
            // 
            // UsersTree
            // 
            this.UsersTree.Location = new System.Drawing.Point(144, 12);
            this.UsersTree.Name = "UsersTree";
            this.UsersTree.Size = new System.Drawing.Size(277, 370);
            this.UsersTree.TabIndex = 1;
            this.UsersTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.UsersTree_AfterSelect);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(299, 408);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(122, 35);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(12, 408);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(122, 35);
            this.yes.TabIndex = 3;
            this.yes.Text = "Подтвердить";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // AddAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 455);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.UsersTree);
            this.Controls.Add(this.CasesTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAcc";
            this.Text = "Открыть работнику доступ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CasesTree;
        private System.Windows.Forms.TreeView UsersTree;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button yes;
    }
}