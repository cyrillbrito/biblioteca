﻿namespace PapeApplication
{
    partial class livros
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.p_direita = new System.Windows.Forms.Panel();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.p_esquerda = new System.Windows.Forms.Panel();
            this.radioNaBiblioteca = new System.Windows.Forms.RadioButton();
            this.searchCategoria = new CBClass.Controls.Search();
            this.radioRequisitado = new System.Windows.Forms.RadioButton();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.searchLocal1 = new CBClass.SearchLocal();
            this.searchEditora = new CBClass.Controls.Search();
            this.searchAutor = new CBClass.Controls.Search();
            this.p_baixo = new System.Windows.Forms.Panel();
            this.p_cima.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.p_direita.SuspendLayout();
            this.p_esquerda.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Título";
            this.columnHeader2.Width = 90;
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
            this.listView.TabIndex = 10;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.buttonDetails_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // p_cima
            // 
            this.p_cima.Controls.Add(this.label1);
            this.p_cima.Controls.Add(this.menuStrip1);
            this.p_cima.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_cima.Location = new System.Drawing.Point(0, 0);
            this.p_cima.Name = "p_cima";
            this.p_cima.Size = new System.Drawing.Size(884, 80);
            this.p_cima.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Livros";
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
            this.menuStrip1.TabIndex = 0;
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
            this.p_direita.TabIndex = 9;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.Image = global::PapeApplication.Properties.Resources.foward;
            this.buttonSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSelect.Location = new System.Drawing.Point(6, 162);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(150, 40);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "Selecionar";
            this.buttonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Image = global::PapeApplication.Properties.Resources.add;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.Location = new System.Drawing.Point(6, 24);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 40);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Adicionar Novo";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::PapeApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(6, 116);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(150, 40);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetails.Image = global::PapeApplication.Properties.Resources.information;
            this.buttonDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDetails.Location = new System.Drawing.Point(6, 70);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(150, 40);
            this.buttonDetails.TabIndex = 0;
            this.buttonDetails.Text = "Ver Dados";
            this.buttonDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // p_esquerda
            // 
            this.p_esquerda.Controls.Add(this.radioNaBiblioteca);
            this.p_esquerda.Controls.Add(this.searchCategoria);
            this.p_esquerda.Controls.Add(this.radioRequisitado);
            this.p_esquerda.Controls.Add(this.radioTodos);
            this.p_esquerda.Controls.Add(this.searchLocal1);
            this.p_esquerda.Controls.Add(this.searchEditora);
            this.p_esquerda.Controls.Add(this.searchAutor);
            this.p_esquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_esquerda.Location = new System.Drawing.Point(0, 80);
            this.p_esquerda.Name = "p_esquerda";
            this.p_esquerda.Size = new System.Drawing.Size(195, 382);
            this.p_esquerda.TabIndex = 8;
            // 
            // radioNaBiblioteca
            // 
            this.radioNaBiblioteca.AutoSize = true;
            this.radioNaBiblioteca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNaBiblioteca.Location = new System.Drawing.Point(12, 329);
            this.radioNaBiblioteca.Name = "radioNaBiblioteca";
            this.radioNaBiblioteca.Size = new System.Drawing.Size(111, 22);
            this.radioNaBiblioteca.TabIndex = 2;
            this.radioNaBiblioteca.Text = "Na biblioteca";
            this.radioNaBiblioteca.UseVisualStyleBackColor = true;
            this.radioNaBiblioteca.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // searchCategoria
            // 
            this.searchCategoria.BackColor = System.Drawing.SystemColors.Control;
            this.searchCategoria.CBCheckBoxLocked = false;
            this.searchCategoria.CBColumnName = "Categoria";
            this.searchCategoria.CBFormName = "categoria";
            this.searchCategoria.CBIdColumn = "id_cate";
            this.searchCategoria.CBisChecked = false;
            this.searchCategoria.CBReadOnly = false;
            this.searchCategoria.CBTableName = "categorias";
            this.searchCategoria.CBText = "Categoria";
            this.searchCategoria.CBValue = "ID";
            this.searchCategoria.Location = new System.Drawing.Point(12, 88);
            this.searchCategoria.Name = "searchCategoria";
            this.searchCategoria.Size = new System.Drawing.Size(172, 65);
            this.searchCategoria.TabIndex = 0;
            this.searchCategoria.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            this.searchCategoria.CheckBoxCheckedChanged += new System.EventHandler(this.search_CheckBoxCheckedChange);
            this.searchCategoria.ConditionChanged += new System.EventHandler(this.search_ConditionChanged);
            // 
            // radioRequisitado
            // 
            this.radioRequisitado.AutoSize = true;
            this.radioRequisitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRequisitado.Location = new System.Drawing.Point(12, 357);
            this.radioRequisitado.Name = "radioRequisitado";
            this.radioRequisitado.Size = new System.Drawing.Size(112, 22);
            this.radioRequisitado.TabIndex = 1;
            this.radioRequisitado.Text = "Requisitados";
            this.radioRequisitado.UseVisualStyleBackColor = true;
            this.radioRequisitado.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.Checked = true;
            this.radioTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTodos.Location = new System.Drawing.Point(12, 301);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(69, 22);
            this.radioTodos.TabIndex = 0;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "Todos";
            this.radioTodos.UseVisualStyleBackColor = true;
            this.radioTodos.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // searchLocal1
            // 
            this.searchLocal1.CBColumnName = "titulo";
            this.searchLocal1.CBReadOnly = false;
            this.searchLocal1.CBText = "Titulo";
            this.searchLocal1.CBValue = "";
            this.searchLocal1.Location = new System.Drawing.Point(12, 24);
            this.searchLocal1.Name = "searchLocal1";
            this.searchLocal1.Size = new System.Drawing.Size(136, 58);
            this.searchLocal1.TabIndex = 10;
            this.searchLocal1.textChanged += new System.EventHandler(this.search_ConditionChanged);
            // 
            // searchEditora
            // 
            this.searchEditora.BackColor = System.Drawing.SystemColors.Control;
            this.searchEditora.CBCheckBoxLocked = false;
            this.searchEditora.CBColumnName = "Editora";
            this.searchEditora.CBFormName = "editora";
            this.searchEditora.CBIdColumn = "id_edit";
            this.searchEditora.CBisChecked = false;
            this.searchEditora.CBReadOnly = false;
            this.searchEditora.CBTableName = "Editoras";
            this.searchEditora.CBText = "Editora";
            this.searchEditora.CBValue = "ID";
            this.searchEditora.Location = new System.Drawing.Point(12, 230);
            this.searchEditora.Name = "searchEditora";
            this.searchEditora.Size = new System.Drawing.Size(172, 65);
            this.searchEditora.TabIndex = 9;
            this.searchEditora.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            this.searchEditora.CheckBoxCheckedChanged += new System.EventHandler(this.search_CheckBoxCheckedChange);
            this.searchEditora.ConditionChanged += new System.EventHandler(this.search_ConditionChanged);
            // 
            // searchAutor
            // 
            this.searchAutor.BackColor = System.Drawing.SystemColors.Control;
            this.searchAutor.CBCheckBoxLocked = false;
            this.searchAutor.CBColumnName = "Nome";
            this.searchAutor.CBFormName = "autores";
            this.searchAutor.CBIdColumn = "id_auto";
            this.searchAutor.CBisChecked = false;
            this.searchAutor.CBReadOnly = false;
            this.searchAutor.CBTableName = "Autores";
            this.searchAutor.CBText = "Autor";
            this.searchAutor.CBValue = "ID";
            this.searchAutor.Location = new System.Drawing.Point(12, 159);
            this.searchAutor.Name = "searchAutor";
            this.searchAutor.Size = new System.Drawing.Size(172, 65);
            this.searchAutor.TabIndex = 0;
            this.searchAutor.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            this.searchAutor.CheckBoxCheckedChanged += new System.EventHandler(this.search_CheckBoxCheckedChange);
            this.searchAutor.ConditionChanged += new System.EventHandler(this.search_ConditionChanged);
            // 
            // p_baixo
            // 
            this.p_baixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_baixo.Location = new System.Drawing.Point(0, 462);
            this.p_baixo.Name = "p_baixo";
            this.p_baixo.Size = new System.Drawing.Size(884, 50);
            this.p_baixo.TabIndex = 7;
            // 
            // livros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.p_esquerda);
            this.Controls.Add(this.p_direita);
            this.Controls.Add(this.p_cima);
            this.Controls.Add(this.p_baixo);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "livros";
            this.Text = "livros";
            this.Load += new System.EventHandler(this.livros_Load);
            this.p_cima.ResumeLayout(false);
            this.p_cima.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.p_direita.ResumeLayout(false);
            this.p_esquerda.ResumeLayout(false);
            this.p_esquerda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private CBClass.Controls.Search searchAutor;
        private System.Windows.Forms.Panel p_cima;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel p_direita;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel p_esquerda;
        private System.Windows.Forms.Panel p_baixo;
        private CBClass.Controls.Search searchEditora;
        private CBClass.SearchLocal searchLocal1;
        private CBClass.Controls.Search searchCategoria;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem livrosToolStrip;
        private System.Windows.Forms.ToolStripMenuItem leitoresToolStrip;
        private System.Windows.Forms.ToolStripMenuItem requisitarToolStripMenuItem;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionariosToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioNaBiblioteca;
        private System.Windows.Forms.RadioButton radioRequisitado;
        private System.Windows.Forms.RadioButton radioTodos;
        private System.Windows.Forms.Label label1;
    }
}