using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CBClass
{
    public class mysql
    {
        static MySqlConnection con = new MySqlConnection("server=localhost;database=biblioteca;uid=root");
        static MySqlCommand cmd;
        MySqlDataReader rdr;

        public mysql(string columns, string tables, string condition = null)
        {

            string cmdStr = "SELECT " + columns + " FROM " + tables;

            if (condition != null && condition != "")
                cmdStr += " WHERE " + condition;

            con.Open();
            cmd = new MySqlCommand(cmdStr, con);
            rdr = cmd.ExecuteReader();

        }

        public bool read()
        {
            return rdr.Read();
        }

        public string read(string column)
        {
            return rdr[column].ToString();
        }

        public void close()
        {
            rdr.Close();
            con.Close();
        }

        public void listView(ListView listView)
        {
            listView.Items.Clear();
            for (int i = 0; rdr.Read(); i++)//loop por todos os filmes
            {
                listView.Items.Add(rdr[0].ToString());//add filme
                for (int j = 1; listView.Columns.Count > j; j++)//loop por todas as colunas
                    listView.Items[i].SubItems.Add(rdr[j].ToString());//add coluna
            }
            con.Close();
        }

        public static void update(string table, string columns, string condition)
        {
            cmd = new MySqlCommand("UPDATE " + table + " SET " + columns + " WHERE " + condition, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void insert(string table, string columns, string values)
        {
            cmd = new MySqlCommand("INSERT INTO " + table + "(" + columns + ") VALUES(" + values + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void delete(string table, string conditon)
        {
            cmd = new MySqlCommand("DELETE FROM " + table + " WHERE " + conditon, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
