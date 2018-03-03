using CbClass;
using System.ComponentModel;
using System.Windows.Forms;

namespace PapApplication
{
    partial class Categoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.searchCategoria = new CbClass.SearchLocal();
            this.p_esquerda = new System.Windows.Forms.Panel();
            this.p_baixo = new System.Windows.Forms.Panel();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.p_direita = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.p_cima = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.livrosToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.leitoresToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.requisitarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_esquerda.SuspendLayout();
            this.p_direita.SuspendLayout();
            this.p_cima.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchCategoria
            // 
            this.searchCategoria.CbColumnName = "categoria";
            this.searchCategoria.CbReadOnly = false;
            this.searchCategoria.CbText = "Categoria";
            this.searchCategoria.CbValue = "";
            this.searchCategoria.Location = new System.Drawing.Point(12, 24);
            this.searchCategoria.Name = "searchCategoria";
            this.searchCategoria.Size = new System.Drawing.Size(136, 58);
            this.searchCategoria.TabIndex = 10;
            this.searchCategoria.TextChanged += new System.EventHandler(this.Search_ConditionChanged);
            // 
            // p_esquerda
            // 
            this.p_esquerda.Controls.Add(this.searchCategoria);
            this.p_esquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_esquerda.Location = new System.Drawing.Point(0, 80);
            this.p_esquerda.Name = "p_esquerda";
            this.p_esquerda.Size = new System.Drawing.Size(195, 382);
            this.p_esquerda.TabIndex = 13;
            // 
            // p_baixo
            // 
            this.p_baixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_baixo.Location = new System.Drawing.Point(0, 462);
            this.p_baixo.Name = "p_baixo";
            this.p_baixo.Size = new System.Drawing.Size(884, 50);
            this.p_baixo.TabIndex = 12;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.Image = global::PapApplication.Properties.Resources.foward;
            this.buttonSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSelect.Location = new System.Drawing.Point(6, 162);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(150, 40);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "Selecionar";
            this.buttonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // p_direita
            // 
            this.p_direita.Controls.Add(this.buttonSelect);
            this.p_direita.Controls.Add(this.buttonAdd);
            this.p_direita.Controls.Add(this.buttonEdit);
            this.p_direita.Controls.Add(this.buttonDetails);
            this.p_direita.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_direita.Location = new System.Drawing.Point(719, 80);
            this.p_direita.Name = "p_direita";
            this.p_direita.Size = new System.Drawing.Size(165, 382);
            this.p_direita.TabIndex = 14;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Image = global::PapApplication.Properties.Resources.add;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(6, 24);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 40);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Adicionar Novo";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::PapApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(6, 116);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(150, 40);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetails.Image = global::PapApplication.Properties.Resources.information;
            this.buttonDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDetails.Location = new System.Drawing.Point(6, 70);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(150, 40);
            this.buttonDetails.TabIndex = 0;
            this.buttonDetails.Text = "Ver Dados";
            this.buttonDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.ButtonDetails_Click);
            // 
            // p_cima
            // 
            this.p_cima.Controls.Add(this.label1);
            this.p_cima.Controls.Add(this.menuStrip1);
            this.p_cima.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_cima.Location = new System.Drawing.Point(0, 0);
            this.p_cima.Name = "p_cima";
            this.p_cima.Size = new System.Drawing.Size(884, 80);
            this.p_cima.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de Categorias";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.livrosToolStrip,
            this.leitoresToolStrip,
            this.requisitarToolStripMenuItem,
            this.autoresToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.editorasToolStripMenuItem,
            this.funcionariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // livrosToolStrip
            // 
            this.livrosToolStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livrosToolStrip.Name = "livrosToolStrip";
            this.livrosToolStrip.Size = new System.Drawing.Size(59, 24);
            this.livrosToolStrip.Text = "Livros";
            this.livrosToolStrip.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // leitoresToolStrip
            // 
            this.leitoresToolStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leitoresToolStrip.Name = "leitoresToolStrip";
            this.leitoresToolStrip.Size = new System.Drawing.Size(73, 24);
            this.leitoresToolStrip.Text = "Leitores";
            this.leitoresToolStrip.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // requisitarToolStripMenuItem
            // 
            this.requisitarToolStripMenuItem.Name = "requisitarToolStripMenuItem";
            this.requisitarToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.requisitarToolStripMenuItem.Text = "Requisitar";
            this.requisitarToolStripMenuItem.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // autoresToolStripMenuItem
            // 
            this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            this.autoresToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.autoresToolStripMenuItem.Text = "Autores";
            this.autoresToolStripMenuItem.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // editorasToolStripMenuItem
            // 
            this.editorasToolStripMenuItem.Name = "editorasToolStripMenuItem";
            this.editorasToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.editorasToolStripMenuItem.Text = "Editoras";
            this.editorasToolStripMenuItem.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // funcionariosToolStripMenuItem
            // 
            this.funcionariosToolStripMenuItem.Name = "funcionariosToolStripMenuItem";
            this.funcionariosToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.funcionariosToolStripMenuItem.Text = "Funcionários";
            this.funcionariosToolStripMenuItem.Visible = false;
            this.funcionariosToolStripMenuItem.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(195, 80);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(524, 382);
            this.listView.TabIndex = 15;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.ButtonDetails_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Categoria";
            this.columnHeader2.Width = 90;
            // 
            // categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.p_esquerda);
            this.Controls.Add(this.p_direita);
            this.Controls.Add(this.p_cima);
            this.Controls.Add(this.p_baixo);
            this.Name = "Categoria";
            this.Text = "categoria";
            this.Load += new System.EventHandler(this.Categoria_Load);
            this.p_esquerda.ResumeLayout(false);
            this.p_direita.ResumeLayout(false);
            this.p_cima.ResumeLayout(false);
            this.p_cima.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SearchLocal searchCategoria;
        private Panel p_esquerda;
        private Panel p_baixo;
        private Button buttonSelect;
        private Panel p_direita;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDetails;
        private Panel p_cima;
        private ColumnHeader columnHeader1;
        private ListView listView;
        private ColumnHeader columnHeader2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem livrosToolStrip;
        private ToolStripMenuItem leitoresToolStrip;
        private ToolStripMenuItem requisitarToolStripMenuItem;
        private ToolStripMenuItem autoresToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem editorasToolStripMenuItem;
        private ToolStripMenuItem funcionariosToolStripMenuItem;
        private Label label1;

    }
}