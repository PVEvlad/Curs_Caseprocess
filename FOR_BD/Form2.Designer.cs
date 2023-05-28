
namespace FOR_BD
{
    partial class Inter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inter));
            this.persons = new System.Windows.Forms.Button();
            this.reestr = new System.Windows.Forms.Button();
            this.casesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caseprocessDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caseprocessDataSet = new FOR_BD.CaseprocessDataSet();
            this.casesTableAdapter = new FOR_BD.CaseprocessDataSetTableAdapters.casesTableAdapter();
            this.caseprocessDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.caseprocessDataSet1 = new FOR_BD.caseprocessDataSet1();
            this.casesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.casesTableAdapter1 = new FOR_BD.caseprocessDataSet1TableAdapters.casesTableAdapter();
            this.Tables = new System.Windows.Forms.DataGridView();
            this.casesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.NewAccess = new System.Windows.Forms.Button();
            this.tableAdapterManager1 = new FOR_BD.CaseprocessDataSetTableAdapters.TableAdapterManager();
            this.bdel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // persons
            // 
            this.persons.BackColor = System.Drawing.SystemColors.Control;
            this.persons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.persons.Location = new System.Drawing.Point(10, 300);
            this.persons.Margin = new System.Windows.Forms.Padding(5);
            this.persons.Name = "persons";
            this.persons.Size = new System.Drawing.Size(134, 40);
            this.persons.TabIndex = 1;
            this.persons.Text = "Пользователи";
            this.persons.UseVisualStyleBackColor = false;
            this.persons.Click += new System.EventHandler(this.persons_Click);
            // 
            // reestr
            // 
            this.reestr.BackColor = System.Drawing.SystemColors.Control;
            this.reestr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reestr.Location = new System.Drawing.Point(160, 300);
            this.reestr.Margin = new System.Windows.Forms.Padding(5);
            this.reestr.Name = "reestr";
            this.reestr.Size = new System.Drawing.Size(130, 40);
            this.reestr.TabIndex = 2;
            this.reestr.Text = "Реестр";
            this.reestr.UseVisualStyleBackColor = false;
            this.reestr.Click += new System.EventHandler(this.reestr_Click);
            // 
            // casesBindingSource
            // 
            this.casesBindingSource.DataMember = "cases";
            this.casesBindingSource.DataSource = this.caseprocessDataSetBindingSource;
            // 
            // caseprocessDataSetBindingSource
            // 
            this.caseprocessDataSetBindingSource.DataSource = this.caseprocessDataSet;
            this.caseprocessDataSetBindingSource.Position = 0;
            // 
            // caseprocessDataSet
            // 
            this.caseprocessDataSet.DataSetName = "CaseprocessDataSet";
            this.caseprocessDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // casesTableAdapter
            // 
            this.casesTableAdapter.ClearBeforeFill = true;
            // 
            // caseprocessDataSetBindingSource1
            // 
            this.caseprocessDataSetBindingSource1.DataSource = this.caseprocessDataSet;
            this.caseprocessDataSetBindingSource1.Position = 0;
            // 
            // caseprocessDataSet1
            // 
            this.caseprocessDataSet1.DataSetName = "caseprocessDataSet1";
            this.caseprocessDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // casesBindingSource1
            // 
            this.casesBindingSource1.DataMember = "cases";
            this.casesBindingSource1.DataSource = this.caseprocessDataSet1;
            // 
            // casesTableAdapter1
            // 
            this.casesTableAdapter1.ClearBeforeFill = true;
            // 
            // Tables
            // 
            this.Tables.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Tables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tables.GridColor = System.Drawing.Color.Black;
            this.Tables.Location = new System.Drawing.Point(21, 18);
            this.Tables.Margin = new System.Windows.Forms.Padding(5);
            this.Tables.Name = "Tables";
            this.Tables.RowHeadersVisible = false;
            this.Tables.RowHeadersWidth = 51;
            this.Tables.RowTemplate.Height = 24;
            this.Tables.Size = new System.Drawing.Size(381, 271);
            this.Tables.TabIndex = 0;
            // 
            // casesBindingSource2
            // 
            this.casesBindingSource2.DataMember = "cases";
            this.casesBindingSource2.DataSource = this.caseprocessDataSetBindingSource1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(21, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 276);
            this.listBox1.TabIndex = 3;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // NewAccess
            // 
            this.NewAccess.BackColor = System.Drawing.SystemColors.Control;
            this.NewAccess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewAccess.Location = new System.Drawing.Point(300, 299);
            this.NewAccess.Margin = new System.Windows.Forms.Padding(5);
            this.NewAccess.Name = "NewAccess";
            this.NewAccess.Size = new System.Drawing.Size(130, 40);
            this.NewAccess.TabIndex = 4;
            this.NewAccess.Text = "Открыть доступ";
            this.NewAccess.UseVisualStyleBackColor = false;
            this.NewAccess.Visible = false;
            this.NewAccess.Click += new System.EventHandler(this.NewAccess_Click);
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.casesTableAdapter = this.casesTableAdapter;
            this.tableAdapterManager1.crime_placesTableAdapter = null;
            this.tableAdapterManager1.departmentTableAdapter = null;
            this.tableAdapterManager1.evidence_placeTableAdapter = null;
            this.tableAdapterManager1.evidence_typeTableAdapter = null;
            this.tableAdapterManager1.family_membership_typeTableAdapter = null;
            this.tableAdapterManager1.membersTableAdapter = null;
            this.tableAdapterManager1.participant_statusTableAdapter = null;
            this.tableAdapterManager1.partisipant_statusesTableAdapter = null;
            this.tableAdapterManager1.partisipantsTableAdapter = null;
            this.tableAdapterManager1.postsTableAdapter = null;
            this.tableAdapterManager1.relativesTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = FOR_BD.CaseprocessDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdel
            // 
            this.bdel.BackColor = System.Drawing.SystemColors.Control;
            this.bdel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bdel.Location = new System.Drawing.Point(440, 300);
            this.bdel.Margin = new System.Windows.Forms.Padding(5);
            this.bdel.Name = "bdel";
            this.bdel.Size = new System.Drawing.Size(130, 40);
            this.bdel.TabIndex = 5;
            this.bdel.Text = "Удалить";
            this.bdel.UseVisualStyleBackColor = false;
            this.bdel.Visible = false;
            this.bdel.Click += new System.EventHandler(this.bdel_Click);
            // 
            // Inter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(728, 348);
            this.Controls.Add(this.bdel);
            this.Controls.Add(this.NewAccess);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.reestr);
            this.Controls.Add(this.persons);
            this.Controls.Add(this.Tables);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Inter";
            this.Text = "Реестр МВД города Черепушкина района Колотушкина";
            this.Load += new System.EventHandler(this.Inter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseprocessDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button persons;
        private System.Windows.Forms.Button reestr;
        private System.Windows.Forms.BindingSource caseprocessDataSetBindingSource;
        private CaseprocessDataSet caseprocessDataSet;
        private System.Windows.Forms.BindingSource casesBindingSource;
        private CaseprocessDataSetTableAdapters.casesTableAdapter casesTableAdapter;
        private System.Windows.Forms.BindingSource caseprocessDataSetBindingSource1;
        private caseprocessDataSet1 caseprocessDataSet1;
        private System.Windows.Forms.BindingSource casesBindingSource1;
        private caseprocessDataSet1TableAdapters.casesTableAdapter casesTableAdapter1;
        private System.Windows.Forms.DataGridView Tables;
        private System.Windows.Forms.BindingSource casesBindingSource2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button NewAccess;
        private CaseprocessDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button bdel;
    }
}