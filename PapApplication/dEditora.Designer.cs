using CbClass;
using System.ComponentModel;
using System.Windows.Forms;

namespace PapApplication
{
    partial class DEditora
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.searchEditora = new CbClass.SearchLocal();
            this.searchId = new CbClass.SearchLocal();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::PapApplication.Properties.Resources.cancel;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(154, 58);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Image = global::PapApplication.Properties.Resources.save;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.Location = new System.Drawing.Point(154, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 40);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Image = global::PapApplication.Properties.Resources.edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.Location = new System.Drawing.Point(154, 94);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 40);
            this.buttonEdit.TabIndex = 30;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // searchEditora
            // 
            this.searchEditora.CbColumnName = "editora";
            this.searchEditora.CbReadOnly = true;
            this.searchEditora.CbText = "Editora";
            this.searchEditora.CbValue = "";
            this.searchEditora.Location = new System.Drawing.Point(12, 76);
            this.searchEditora.Name = "searchEditora";
            this.searchEditora.Size = new System.Drawing.Size(136, 58);
            this.searchEditora.TabIndex = 29;
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
            this.searchId.TabIndex = 28;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.Image = global::PapApplication.Properties.Resources.delete;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEliminar.Location = new System.Drawing.Point(154, 104);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(120, 40);
            this.buttonEliminar.TabIndex = 33;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.ButtonEliminar_Click);
            // 
            // dEditora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 152);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.searchEditora);
            this.Controls.Add(this.searchId);
            this.Controls.Add(this.buttonEliminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DEditora";
            this.Text = "dEditora";
            this.Load += new System.EventHandler(this.DEditora_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonEdit;
        private SearchLocal searchEditora;
        private SearchLocal searchId;
        private Button buttonEliminar;
    }
}