﻿using CbClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class Categoria : Form
    {
        private const string Tables = "categorias";
        private string _columns = "id_cate, categoria";
        private readonly bool _select;
        private string _conditions;

        public Categoria(bool select = false)
        {
            InitializeComponent();
            _select = select;
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            if (_select)
            {
                menuStrip1.Visible = false;
                buttonSelect.Font = new Font(buttonSelect.Font, FontStyle.Bold);
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.LoadFormProperties(this, true);
                label1.Text = "Selecionar Categoria";
            }
            else
                Methods.LoadFormProperties(this);
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DCategoria(int.Parse(listView.SelectedItems[0].Text));
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DCategoria(int.Parse(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            var obj = new DCategoria(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ConditionChanged(object sender, EventArgs e)
        {
            var search = sender as Search;
            var searchLocal = sender as SearchLocal;

            if ((search == null || search.CbValue == "") && (searchLocal == null || searchLocal.CbValue == ""))
                return;

            var startPosition = _conditions.IndexOf(search != null ? search.CbIdColumn : searchLocal.CbColumnName, StringComparison.Ordinal);

            if (startPosition != -1)
            {
                var endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);

                if (endPosition == -1)
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (_conditions != "")
                _conditions += " AND ";

            if (search != null)
                _conditions += search.CbIdColumn + " = " + search.CbValue;
            else
                _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";

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

        private void buttonSelect_Click(object sender, EventArgs e)
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

                    var c = new Livros(false, listView.SelectedItems[0].Text);
                    Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }
    }
}
