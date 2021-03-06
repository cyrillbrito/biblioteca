﻿using CbClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class Leitores : Form
    {
        private const string Tables = "leitores";
        private string _columns = "id_leit, nome, morada, telemovel";
        private readonly bool _select;
        private string _conditions = "";

        public Leitores(bool select = false)
        {
            InitializeComponent();
            _select = select;
        }

        private void Leitores_Load(object sender, EventArgs e)
        {
            if (_select)
            {
                menuStrip1.Visible = false;
                buttonSelect.Font = new Font(buttonSelect.Font, FontStyle.Bold);
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.LoadFormProperties(this, true);
                label1.Text = "Selecionar Leitor";
            }
            else
                Methods.LoadFormProperties(this);
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DLeitores(int.Parse(listView.SelectedItems[0].Text));
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                var obj = new DLeitores(int.Parse(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var obj = new DLeitores(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ConditionChanged(object sender, EventArgs e)
        {
            var search = sender as Search;
            var searchLocal = sender as SearchLocal;

            var startPosition = _conditions.IndexOf(search != null ? search.CbIdColumn : searchLocal.CbColumnName, StringComparison.Ordinal);

            if (startPosition != -1)
            {
                var endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);

                if (endPosition == -1)
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if ((search != null && search.CbValue != "") || (searchLocal != null && searchLocal.CbValue != ""))
            {
                if (_conditions != "")
                    _conditions += " AND ";

                if (search != null)
                    _conditions += search.CbIdColumn + " = " + search.CbValue;
                else
                    _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
            }

            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            Hide();
            switch (((ToolStripMenuItem)sender).Text)
            {
                case "Livros": var a = new Livros(); a.ShowDialog(); break;
                case "Leitores": var b = new Leitores(); b.ShowDialog(); break;
                case "Requisitar": var c = new Requisita(); c.ShowDialog(); break;
                case "Autores": var d = new Autores(); d.ShowDialog(); break;
                case "Categorias": var f = new Categoria(); f.ShowDialog(); break;
                case "Editoras": var g = new Editora(); g.ShowDialog(); break;
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                if (_select)
                {
                    Variables.ReturnValue = int.Parse(listView.SelectedItems[0].Text);
                    Close();
                }
                else
                {
                    Methods.SaveFormProperties();

                    var c = new Requisita("0", listView.SelectedItems[0].Text);
                    Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }
    }
}
