using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CBClass
{
    public class Mysql : IDisposable
    {
        private static readonly MySqlConnection Connection = new MySqlConnection("server=localhost;database=biblioteca;uid=root");
        private readonly MySqlDataReader _reader;

        public Mysql(string columns, string tables, string condition = null)
        {
            var cmdStr = $"SELECT {columns} FROM {tables}";

            if (!string.IsNullOrWhiteSpace(condition))
                cmdStr += $" WHERE {condition}";

            Connection.Open();
            var cmd = new MySqlCommand(cmdStr, Connection);
            _reader = cmd.ExecuteReader();
        }

        public bool Read()
        {
            return _reader.Read();
        }

        public string Read(string column)
        {
            return _reader[column].ToString();
        }

        public void ListView(ListView listView)
        {
            listView.Items.Clear();

            for (int i = 0; _reader.Read(); i++)
            {
                listView.Items.Add(_reader[0].ToString());
                for (int j = 1; listView.Columns.Count > j; j++)
                    listView.Items[i].SubItems.Add(_reader[j].ToString());
            }
        }

        public void Dispose()
        {
            _reader.Close();
            Connection.Close();
        }

        public static void Update(string table, string columns, string condition)
        {
            var cmd = new MySqlCommand("UPDATE " + table + " SET " + columns + " WHERE " + condition, Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public static void Insert(string table, string columns, string values)
        {
            var cmd = new MySqlCommand("INSERT INTO " + table + "(" + columns + ") VALUES(" + values + ")", Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public static void Delete(string table, string conditon)
        {
            var cmd = new MySqlCommand("DELETE FROM " + table + " WHERE " + conditon, Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
