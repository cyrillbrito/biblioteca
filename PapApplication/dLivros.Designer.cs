using CbClass;
using System.ComponentModel;
using System.Windows.Forms;

namespace PapApplication
{
    partial class DLivros
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
            this.searchPaginas = new CbClass.SearchLocal();
            this.searchTitulo = new CbClass.SearchLocal();
            this.searchId = new CbClass.SearchLocal();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.searchData = new CbClass.SearchDate();
            this.searchCategoria = new Search();
            this.searchEditora = new Search();
            this.searchAutor = new Search();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchPaginas
            // 
            this.searchPaginas.CbColumnName = "n_pagi";
            this.searchPaginas.CbReadOnly = true;
            this.searchPaginas.CbText = "N. de Paginas";
            this.searchPaginas.CbValue = "";
            this.searchPaginas.Location = new System.Drawing.Point(12, 154);
            this.searchPaginas.Name = "searchPaginas";
            this.searchPaginas.Size = new System.Drawing.Size(136, 58);
            this.searchPaginas.TabIndex = 3;
            // 
            // searchTitulo
            // 
            this.searchTitulo.CbColumnName = "titulo";
            this.searchTitulo.CbReadOnly = true;
            this.searchTitulo.CbText = "Titulo";
            this.searchTitulo.CbValue = "";
            this.searchTitulo.Location = new System.Drawing.Point(12, 83);
            this.searchTitulo.Name = "searchTitulo";
            this.searchTitulo.Size = new System.Drawing.Size(136, 58);
            this.searchTitulo.TabIndex = 2;
            // 
            // searchId
            // 
            this.searchId.CbColumnName = "id_livr";
            this.searchId.CbReadOnly = true;
            this.searchId.CbText = "ID";
            this.searchId.CbValue = "";
            this.searchId.Location = new System.Drawing.Point(12, 12);
            this.searchId.Name = "searchId";
            this.searchId.Size = new System.Drawing.Size(136, 58);
            this.searchId.TabIndex = 1;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::PapApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(502, 179);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 40);
            this.buttonEdit.TabIndex = 15;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Image = global::PapApplication.Properties.Resources.save;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(502, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 40);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::PapApplication.Properties.Resources.cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(502, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // searchData
            // 
            this.searchData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchData.CbNumberDays = 0;
            this.searchData.CbReadOnly = true;
            this.searchData.CbText = "Data de lançamento";
            this.searchData.CbValue = "2014-06-09";
            this.searchData.Location = new System.Drawing.Point(332, 12);
            this.searchData.Name = "searchData";
            this.searchData.Size = new System.Drawing.Size(164, 57);
            this.searchData.TabIndex = 18;
            // 
            // searchCategoria
            // 
            this.searchCategoria.BackColor = System.Drawing.SystemColors.Control;
            this.searchCategoria.CbCheckBoxLocked = true;
            this.searchCategoria.CbColumnName = "categoria";
            this.searchCategoria.CbFormName = "categoria";
            this.searchCategoria.CbIdColumn = "id_cate";
            this.searchCategoria.CBisChecked = true;
            this.searchCategoria.CbReadOnly = true;
            this.searchCategoria.CbTableName = "categorias";
            this.searchCategoria.CbText = "Categoria";
            this.searchCategoria.CbValue = "ID";
            this.searchCategoria.Location = new System.Drawing.Point(154, 12);
            this.searchCategoria.Name = "searchCategoria";
            this.searchCategoria.Size = new System.Drawing.Size(172, 65);
            this.searchCategoria.TabIndex = 19;
            this.searchCategoria.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            // 
            // searchEditora
            // 
            this.searchEditora.BackColor = System.Drawing.SystemColors.Control;
            this.searchEditora.CbCheckBoxLocked = true;
            this.searchEditora.CbColumnName = "editora";
            this.searchEditora.CbFormName = "editora";
            this.searchEditora.CbIdColumn = "id_edit";
            this.searchEditora.CBisChecked = true;
            this.searchEditora.CbReadOnly = true;
            this.searchEditora.CbTableName = "editoras";
            this.searchEditora.CbText = "Editora";
            this.searchEditora.CbValue = "ID";
            this.searchEditora.Location = new System.Drawing.Point(154, 83);
            this.searchEditora.Name = "searchEditora";
            this.searchEditora.Size = new System.Drawing.Size(172, 65);
            this.searchEditora.TabIndex = 20;
            this.searchEditora.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            // 
            // searchAutor
            // 
            this.searchAutor.BackColor = System.Drawing.SystemColors.Control;
            this.searchAutor.CbCheckBoxLocked = true;
            this.searchAutor.CbColumnName = "nome";
            this.searchAutor.CbFormName = "autores";
            this.searchAutor.CbIdColumn = "id_auto";
            this.searchAutor.CBisChecked = true;
            this.searchAutor.CbReadOnly = true;
            this.searchAutor.CbTableName = "autores";
            this.searchAutor.CbText = "Autor";
            this.searchAutor.CbValue = "ID";
            this.searchAutor.Location = new System.Drawing.Point(154, 154);
            this.searchAutor.Name = "searchAutor";
            this.searchAutor.Size = new System.Drawing.Size(172, 65);
            this.searchAutor.TabIndex = 21;
            this.searchAutor.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Image = global::PapApplication.Properties.Resources.delete;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(502, 179);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 40);
            this.buttonEliminar.TabIndex = 22;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dLivros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 226);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.searchAutor);
            this.Controls.Add(this.searchEditora);
            this.Controls.Add(this.searchCategoria);
            this.Controls.Add(this.searchData);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.searchPaginas);
            this.Controls.Add(this.searchTitulo);
            this.Controls.Add(this.searchId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DLivros";
            this.Text = "dLivros";
            this.Load += new System.EventHandler(this.dLivros_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SearchLocal searchId;
        private SearchLocal searchTitulo;
        private SearchLocal searchPaginas;
        private Button buttonEdit;
        private Button buttonSave;
        private Button buttonCancel;
        private SearchDate searchData;
        private Search searchCategoria;
        private Search searchEditora;
        private Search searchAutor;
        private Button buttonEliminar;

    }
}