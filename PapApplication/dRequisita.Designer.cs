﻿namespace PapeApplication
{
    partial class dRequisita
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.searchId = new CBClass.SearchLocal();
            this.searchDevolucao = new CBClass.SearchDate();
            this.searchRequisita = new CBClass.SearchDate();
            this.searchLivro = new CBClass.Controls.Search();
            this.searchLeitor = new CBClass.Controls.Search();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEntregar = new System.Windows.Forms.Button();
            this.searchEntrega = new CBClass.SearchDate();
            this.buttonEstender = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::PapeApplication.Properties.Resources.cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(360, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Image = global::PapeApplication.Properties.Resources.save;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(360, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 40);
            this.buttonSave.TabIndex = 25;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::PapeApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(360, 172);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 40);
            this.buttonEdit.TabIndex = 24;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // searchId
            // 
            this.searchId.CBColumnName = "id_livr";
            this.searchId.CBReadOnly = true;
            this.searchId.CBText = "ID";
            this.searchId.CBValue = "";
            this.searchId.Location = new System.Drawing.Point(12, 12);
            this.searchId.Name = "searchId";
            this.searchId.Size = new System.Drawing.Size(136, 58);
            this.searchId.TabIndex = 31;
            // 
            // searchDevolucao
            // 
            this.searchDevolucao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchDevolucao.CBNumberDays = 0;
            this.searchDevolucao.CBReadOnly = false;
            this.searchDevolucao.CBText = "Data da entrega";
            this.searchDevolucao.CBValue = "2014-06-09";
            this.searchDevolucao.Location = new System.Drawing.Point(190, 147);
            this.searchDevolucao.Name = "searchDevolucao";
            this.searchDevolucao.Size = new System.Drawing.Size(164, 57);
            this.searchDevolucao.TabIndex = 29;
            // 
            // searchRequisita
            // 
            this.searchRequisita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchRequisita.CBNumberDays = 0;
            this.searchRequisita.CBReadOnly = false;
            this.searchRequisita.CBText = "Data requisição";
            this.searchRequisita.CBValue = "2014-06-09";
            this.searchRequisita.Location = new System.Drawing.Point(190, 12);
            this.searchRequisita.Name = "searchRequisita";
            this.searchRequisita.Size = new System.Drawing.Size(164, 57);
            this.searchRequisita.TabIndex = 27;
            // 
            // searchLivro
            // 
            this.searchLivro.BackColor = System.Drawing.SystemColors.Control;
            this.searchLivro.CBCheckBoxLocked = true;
            this.searchLivro.CBColumnName = "titulo";
            this.searchLivro.CBFormName = "livros";
            this.searchLivro.CBIdColumn = "id_livr";
            this.searchLivro.CBisChecked = true;
            this.searchLivro.CBReadOnly = true;
            this.searchLivro.CBTableName = "Livros";
            this.searchLivro.CBText = "Livro";
            this.searchLivro.CBValue = "ID";
            this.searchLivro.Location = new System.Drawing.Point(12, 76);
            this.searchLivro.Name = "searchLivro";
            this.searchLivro.Size = new System.Drawing.Size(172, 65);
            this.searchLivro.TabIndex = 23;
            this.searchLivro.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            // 
            // searchLeitor
            // 
            this.searchLeitor.BackColor = System.Drawing.SystemColors.Control;
            this.searchLeitor.CBCheckBoxLocked = true;
            this.searchLeitor.CBColumnName = "nome";
            this.searchLeitor.CBFormName = "leitores";
            this.searchLeitor.CBIdColumn = "id_leit";
            this.searchLeitor.CBisChecked = true;
            this.searchLeitor.CBReadOnly = true;
            this.searchLeitor.CBTableName = "Leitores";
            this.searchLeitor.CBText = "Leitor";
            this.searchLeitor.CBValue = "ID";
            this.searchLeitor.Location = new System.Drawing.Point(12, 147);
            this.searchLeitor.Name = "searchLeitor";
            this.searchLeitor.Size = new System.Drawing.Size(172, 65);
            this.searchLeitor.TabIndex = 22;
            this.searchLeitor.ButtonClick += new System.EventHandler(this.search_ButtonClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 39);
            this.label1.TabIndex = 32;
            this.label1.Text = "O livro ainda não foi entregue.";
            this.label1.Visible = false;
            // 
            // buttonEntregar
            // 
            this.buttonEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEntregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEntregar.Location = new System.Drawing.Point(360, 122);
            this.buttonEntregar.Name = "buttonEntregar";
            this.buttonEntregar.Size = new System.Drawing.Size(120, 44);
            this.buttonEntregar.TabIndex = 33;
            this.buttonEntregar.Text = "Entregar Livro";
            this.buttonEntregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEntregar.UseVisualStyleBackColor = true;
            this.buttonEntregar.Click += new System.EventHandler(this.buttonEntregar_Click);
            // 
            // searchEntrega
            // 
            this.searchEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchEntrega.CBNumberDays = 90;
            this.searchEntrega.CBReadOnly = false;
            this.searchEntrega.CBText = "Data limite de entrega";
            this.searchEntrega.CBValue = "2014-06-12";
            this.searchEntrega.Location = new System.Drawing.Point(190, 76);
            this.searchEntrega.Name = "searchEntrega";
            this.searchEntrega.Size = new System.Drawing.Size(162, 55);
            this.searchEntrega.TabIndex = 35;
            // 
            // buttonEstender
            // 
            this.buttonEstender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEstender.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEstender.Location = new System.Drawing.Point(360, 72);
            this.buttonEstender.Name = "buttonEstender";
            this.buttonEstender.Size = new System.Drawing.Size(120, 44);
            this.buttonEstender.TabIndex = 36;
            this.buttonEstender.Text = "Estender data de entrega";
            this.buttonEstender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEstender.UseVisualStyleBackColor = true;
            this.buttonEstender.Click += new System.EventHandler(this.buttonEstender_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Image = global::PapeApplication.Properties.Resources.delete;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(360, 172);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 40);
            this.buttonEliminar.TabIndex = 37;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dRequisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 220);
            this.Controls.Add(this.buttonEstender);
            this.Controls.Add(this.searchEntrega);
            this.Controls.Add(this.buttonEntregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchId);
            this.Controls.Add(this.searchDevolucao);
            this.Controls.Add(this.searchRequisita);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.searchLivro);
            this.Controls.Add(this.searchLeitor);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dRequisita";
            this.Text = "dRequisitar";
            this.Load += new System.EventHandler(this.dRequisita_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private CBClass.Controls.Search searchLivro;
        private CBClass.Controls.Search searchLeitor;
        private CBClass.SearchDate searchRequisita;
        private CBClass.SearchDate searchDevolucao;
        private CBClass.SearchLocal searchId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEntregar;
        private CBClass.SearchDate searchEntrega;
        private System.Windows.Forms.Button buttonEstender;
        private System.Windows.Forms.Button buttonEliminar;
    }
}