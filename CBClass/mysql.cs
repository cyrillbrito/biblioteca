using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CBClass
{
    public class Mysql
    {
        static MySqlConnection _con = new MySqlConnection("server=localhost;database=biblioteca;uid=root");
        static MySqlCommand _cmd;
        MySqlDataReader _rdr;

        public Mysql(string columns, string tables, string condition = null)
        {

            string cmdStr = "SELECT " + columns + " FROM " + tables;

            if (condition != null && condition != "")
                cmdStr += " WHERE " + condition;

            _con.Open();
            _cmd = new MySqlCommand(cmdStr, _con);
            _rdr = _cmd.ExecuteReader();

        }

        public bool Read()
        {
            return _rdr.Read();
        }

        public string Read(string column)
        {
            return _rdr[column].ToString();
        }

        public void Close()
        {
            _rdr.Close();
            _con.Close();
        }

        public void ListView(ListView listView)
        {
            listView.Items.Clear();
            for (int i = 0; _rdr.Read(); i++)//loop por todos os filmes
            {
                listView.Items.Add(_rdr[0].ToString());//add filme
                for (int j = 1; listView.Columns.Count > j; j++)//loop por todas as colunas
                    listView.Items[i].SubItems.Add(_rdr[j].ToString());//add coluna
            }
            _con.Close();
        }

        public static void Update(string table, string columns, string condition)
        {
            _cmd = new MySqlCommand("UPDATE " + table + " SET " + columns + " WHERE " + condition, _con);
            _con.Open();
            _cmd.ExecuteNonQuery();
            _con.Close();
        }

        public static void Insert(string table, string columns, string values)
        {
            _cmd = new MySqlCommand("INSERT INTO " + table + "(" + columns + ") VALUES(" + values + ")", _con);
            _con.Open();
            _cmd.ExecuteNonQuery();
            _con.Close();
        }

        public static void Delete(string table, string conditon)
        {
            _cmd = new MySqlCommand("DELETE FROM " + table + " WHERE " + conditon, _con);
            _con.Open();
            _cmd.ExecuteNonQuery();
            _con.Close();
        }
    }
}
