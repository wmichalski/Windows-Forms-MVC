namespace PAIN1
{
    partial class RecordingsForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.DropdownFilters = new System.Windows.Forms.ToolStripComboBox();
            this.recordingsListView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRelease = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dropdownAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDelete,
            this.toolStripButtonEdit,
            this.DropdownFilters});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(33, 22);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAdd.Click += new System.EventHandler(this.ToolStripButtonAdd_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(44, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonDelete.Click += new System.EventHandler(this.ToolStripButtonDelete_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(31, 22);
            this.toolStripButtonEdit.Text = "Edit";
            this.toolStripButtonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEdit.Click += new System.EventHandler(this.ToolStripButtonEdit_Click);
            // 
            // DropdownFilters
            // 
            this.DropdownFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownFilters.Items.AddRange(new object[] {
            "all",
            "this century",
            "prev century"});
            this.DropdownFilters.Name = "DropdownFilters";
            this.DropdownFilters.Size = new System.Drawing.Size(121, 25);
            this.DropdownFilters.DropDownClosed += new System.EventHandler(this.DropdownFilters_DropDownClosed);
            // 
            // recordingsListView
            // 
            this.recordingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderArtist,
            this.columnHeaderRelease,
            this.columnHeaderGenre});
            this.recordingsListView.ContextMenuStrip = this.contextMenuStrip1;
            this.recordingsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingsListView.HideSelection = false;
            this.recordingsListView.Location = new System.Drawing.Point(0, 25);
            this.recordingsListView.Name = "recordingsListView";
            this.recordingsListView.Size = new System.Drawing.Size(800, 425);
            this.recordingsListView.TabIndex = 5;
            this.recordingsListView.UseCompatibleStateImageBehavior = false;
            this.recordingsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 120;
            // 
            // columnHeaderArtist
            // 
            this.columnHeaderArtist.Text = "Artist";
            this.columnHeaderArtist.Width = 120;
            // 
            // columnHeaderRelease
            // 
            this.columnHeaderRelease.Text = "Release";
            this.columnHeaderRelease.Width = 120;
            // 
            // columnHeaderGenre
            // 
            this.columnHeaderGenre.Text = "Genre";
            this.columnHeaderGenre.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropdownAdd,
            this.dropdownEdit,
            this.dropdownDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 70);
            // 
            // dropdownAdd
            // 
            this.dropdownAdd.Name = "dropdownAdd";
            this.dropdownAdd.Size = new System.Drawing.Size(107, 22);
            this.dropdownAdd.Text = "Add";
            this.dropdownAdd.Click += new System.EventHandler(this.dropdownAdd_Click);
            // 
            // dropdownEdit
            // 
            this.dropdownEdit.Name = "dropdownEdit";
            this.dropdownEdit.Size = new System.Drawing.Size(107, 22);
            this.dropdownEdit.Text = "Edit";
            this.dropdownEdit.Click += new System.EventHandler(this.dropdownEdit_Click);
            // 
            // dropdownDelete
            // 
            this.dropdownDelete.Name = "dropdownDelete";
            this.dropdownDelete.Size = new System.Drawing.Size(107, 22);
            this.dropdownDelete.Text = "Delete";
            this.dropdownDelete.Click += new System.EventHandler(this.dropdownDelete_Click);
            // 
            // RecordingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.recordingsListView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RecordingsForm";
            this.Text = "Recordings";
            this.Activated += new System.EventHandler(this.RecordingsForm_Activated);
            this.Deactivate += new System.EventHandler(this.RecordingsForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordingsForm_FormClosing);
            this.Load += new System.EventHandler(this.RecordingsForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ListView recordingsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderArtist;
        private System.Windows.Forms.ColumnHeader columnHeaderRelease;
        private System.Windows.Forms.ColumnHeader columnHeaderGenre;
        private System.Windows.Forms.ToolStripComboBox DropdownFilters;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dropdownAdd;
        private System.Windows.Forms.ToolStripMenuItem dropdownEdit;
        private System.Windows.Forms.ToolStripMenuItem dropdownDelete;
    }
}

