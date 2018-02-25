namespace PapeApplication
{
    partial class dAutores
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
            this.searchDataNascimento = new CBClass.SearchDate();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.searchNacionalidade = new CBClass.SearchLocal();
            this.searchNome = new CBClass.SearchLocal();
            this.searchId = new CBClass.SearchLocal();
            this.searchDataFalecimento = new CBClass.SearchDate();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchDataNascimento
            // 
            this.searchDataNascimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchDataNascimento.CBNumberDays = 0;
            this.searchDataNascimento.CBReadOnly = true;
            this.searchDataNascimento.CBText = "Data de nascimento";
            this.searchDataNascimento.CBValue = "2014-06-09";
            this.searchDataNascimento.Location = new System.Drawing.Point(154, 12);
            this.searchDataNascimento.Name = "searchDataNascimento";
            this.searchDataNascimento.Size = new System.Drawing.Size(164, 57);
            this.searchDataNascimento.TabIndex = 28;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::PapeApplication.Properties.Resources.cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(324, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 27;
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
            this.buttonSave.Location = new System.Drawing.Point(324, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 40);
            this.buttonSave.TabIndex = 26;
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
            this.buttonEdit.Location = new System.Drawing.Point(324, 158);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 40);
            this.buttonEdit.TabIndex = 25;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // searchNacionalidade
            // 
            this.searchNacionalidade.CBColumnName = "nacionalidade";
            this.searchNacionalidade.CBReadOnly = true;
            this.searchNacionalidade.CBText = "Nacionalidade";
            this.searchNacionalidade.CBValue = "";
            this.searchNacionalidade.Location = new System.Drawing.Point(12, 140);
            this.searchNacionalidade.Name = "searchNacionalidade";
            this.searchNacionalidade.Size = new System.Drawing.Size(136, 58);
            this.searchNacionalidade.TabIndex = 21;
            // 
            // searchNome
            // 
            this.searchNome.CBColumnName = "nome";
            this.searchNome.CBReadOnly = true;
            this.searchNome.CBText = "Nome";
            this.searchNome.CBValue = "";
            this.searchNome.Location = new System.Drawing.Point(12, 76);
            this.searchNome.Name = "searchNome";
            this.searchNome.Size = new System.Drawing.Size(136, 58);
            this.searchNome.TabIndex = 20;
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
            this.searchId.TabIndex = 19;
            // 
            // searchDataFalecimento
            // 
            this.searchDataFalecimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchDataFalecimento.CBNumberDays = 0;
            this.searchDataFalecimento.CBReadOnly = true;
            this.searchDataFalecimento.CBText = "Data de falecimento";
            this.searchDataFalecimento.CBValue = "2014-06-09";
            this.searchDataFalecimento.Location = new System.Drawing.Point(154, 77);
            this.searchDataFalecimento.Name = "searchDataFalecimento";
            this.searchDataFalecimento.Size = new System.Drawing.Size(164, 57);
            this.searchDataFalecimento.TabIndex = 29;
            this.searchDataFalecimento.Visible = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox.Location = new System.Drawing.Point(166, 140);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(94, 22);
            this.checkBox.TabIndex = 30;
            this.checkBox.Text = "Já faleceu";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Image = global::PapeApplication.Properties.Resources.delete;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(324, 158);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 40);
            this.buttonEliminar.TabIndex = 31;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dAutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 207);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.searchDataFalecimento);
            this.Controls.Add(this.searchDataNascimento);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.searchNacionalidade);
            this.Controls.Add(this.searchNome);
            this.Controls.Add(this.searchId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dAutores";
            this.Text = "dAutores";
            this.Load += new System.EventHandler(this.dAutores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CBClass.SearchDate searchDataNascimento;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private CBClass.SearchLocal searchNacionalidade;
        private CBClass.SearchLocal searchNome;
        private CBClass.SearchLocal searchId;
        private CBClass.SearchDate searchDataFalecimento;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button buttonEliminar;
    }
}