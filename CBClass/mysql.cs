using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CBClass
{
    public class Mysql : IDisposable
    {
        private static readonly MySqlConnection Connection = new MySqlConnection("server=localhost;database=biblioteca;uid=root");
        private static MySqlCommand _cmd;
        private readonly MySqlDataReader _rdr;

        public Mysql(string columns, string tables, string condition = null)
        {
            var cmdStr = $"SELECT {columns} FROM {tables}";

            if (!string.IsNullOrWhiteSpace(condition))
                cmdStr += $" WHERE {condition}";

            Connection.Open();
            _cmd = new MySqlCommand(cmdStr, Connection);
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

        // todo
        [Obsolete]
        public void Close()
        {
            _rdr.Close();
            Connection.Close();
        }

        public void Dispose()
        {
            _rdr.Close();
            Connection.Close();
        }

        public void ListView(ListView listView)
        {
            listView.Items.Clear();

            for (int i = 0; _rdr.Read(); i++)
            {
                listView.Items.Add(_rdr[0].ToString());
                for (int j = 1; listView.Columns.Count > j; j++)
                    listView.Items[i].SubItems.Add(_rdr[j].ToString());
            }
        }

        public static void Update(string table, string columns, string condition)
        {
            _cmd = new MySqlCommand("UPDATE " + table + " SET " + columns + " WHERE " + condition, Connection);
            Connection.Open();
            _cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public static void Insert(string table, string columns, string values)
        {
            _cmd = new MySqlCommand("INSERT INTO " + table + "(" + columns + ") VALUES(" + values + ")", Connection);
            Connection.Open();
            _cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public static void Delete(string table, string conditon)
        {
            _cmd = new MySqlCommand("DELETE FROM " + table + " WHERE " + conditon, Connection);
            Connection.Open();
            _cmd.ExecuteNonQuery();
            Connection.Close();
        }

    }
}
