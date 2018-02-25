namespace PapApplication
{
    partial class DLeitores
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
            this.searchNome = new CbClass.SearchLocal();
            this.searchEmail = new CbClass.SearchLocal();
            this.searchMorada = new CbClass.SearchLocal();
            this.searchTelemovel = new CbClass.SearchLocal();
            this.searchId = new CbClass.SearchLocal();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonImagem = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::PapApplication.Properties.Resources.cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(422, 58);
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
            this.buttonSave.Image = global::PapApplication.Properties.Resources.save;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(422, 12);
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
            this.buttonEdit.Image = global::PapApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(422, 158);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 40);
            this.buttonEdit.TabIndex = 24;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // searchNome
            // 
            this.searchNome.CbColumnName = "nome";
            this.searchNome.CbReadOnly = false;
            this.searchNome.CbText = "Nome";
            this.searchNome.CbValue = "";
            this.searchNome.Location = new System.Drawing.Point(138, 76);
            this.searchNome.Name = "searchNome";
            this.searchNome.Size = new System.Drawing.Size(136, 58);
            this.searchNome.TabIndex = 27;
            // 
            // searchEmail
            // 
            this.searchEmail.CbColumnName = "email";
            this.searchEmail.CbReadOnly = false;
            this.searchEmail.CbText = "Email";
            this.searchEmail.CbValue = "";
            this.searchEmail.Location = new System.Drawing.Point(138, 140);
            this.searchEmail.Name = "searchEmail";
            this.searchEmail.Size = new System.Drawing.Size(136, 58);
            this.searchEmail.TabIndex = 28;
            // 
            // searchMorada
            // 
            this.searchMorada.CbColumnName = "morada";
            this.searchMorada.CbReadOnly = false;
            this.searchMorada.CbText = "Morada";
            this.searchMorada.CbValue = "";
            this.searchMorada.Location = new System.Drawing.Point(280, 12);
            this.searchMorada.Name = "searchMorada";
            this.searchMorada.Size = new System.Drawing.Size(136, 58);
            this.searchMorada.TabIndex = 29;
            // 
            // searchTelemovel
            // 
            this.searchTelemovel.CbColumnName = "telemovel";
            this.searchTelemovel.CbReadOnly = false;
            this.searchTelemovel.CbText = "Telemovel";
            this.searchTelemovel.CbValue = "";
            this.searchTelemovel.Location = new System.Drawing.Point(280, 76);
            this.searchTelemovel.Name = "searchTelemovel";
            this.searchTelemovel.Size = new System.Drawing.Size(136, 58);
            this.searchTelemovel.TabIndex = 30;
            // 
            // searchId
            // 
            this.searchId.CbColumnName = "id_leit";
            this.searchId.CbReadOnly = true;
            this.searchId.CbText = "ID";
            this.searchId.CbValue = "";
            this.searchId.Location = new System.Drawing.Point(138, 12);
            this.searchId.Name = "searchId";
            this.searchId.Size = new System.Drawing.Size(136, 58);
            this.searchId.TabIndex = 31;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::PapApplication.Properties.Resources.unknown;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // buttonImagem
            // 
            this.buttonImagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImagem.Image = global::PapApplication.Properties.Resources.import;
            this.buttonImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonImagem.Location = new System.Drawing.Point(12, 154);
            this.buttonImagem.Name = "buttonImagem";
            this.buttonImagem.Size = new System.Drawing.Size(120, 44);
            this.buttonImagem.TabIndex = 33;
            this.buttonImagem.Text = "Escolher imagem";
            this.buttonImagem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImagem.UseVisualStyleBackColor = true;
            this.buttonImagem.Click += new System.EventHandler(this.buttonImagem_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Image = global::PapApplication.Properties.Resources.delete;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(422, 158);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 40);
            this.buttonEliminar.TabIndex = 32;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // dLeitores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 204);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonImagem);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.searchId);
            this.Controls.Add(this.searchTelemovel);
            this.Controls.Add(this.searchMorada);
            this.Controls.Add(this.searchEmail);
            this.Controls.Add(this.searchNome);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DLeitores";
            this.Text = "dLeitores";
            this.Load += new System.EventHandler(this.dLeitores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private CbClass.SearchLocal searchNome;
        private CbClass.SearchLocal searchEmail;
        private CbClass.SearchLocal searchMorada;
        private CbClass.SearchLocal searchTelemovel;
        private CbClass.SearchLocal searchId;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonImagem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}