using System;
using CbClass;

namespace PapApplication
{
    class FormsHelper
    {
        //public void SearchConditionChanged(object sender, string conditions)
        //{
        //    var search = sender as Search;
        //    var searchLocal = sender as SearchLocal;
        //    int startPosition;

        //    if (searchLocal == null)
        //        startPosition = conditions.IndexOf(search.CbIdColumn);
        //    else
        //        startPosition = conditions.IndexOf(searchLocal.CbColumnName);

        //    if (startPosition != -1)//Foi encontrado
        //    {
        //        int endPosition = conditions.IndexOf("AND", startPosition);
        //        if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
        //            conditions = conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
        //        else
        //            conditions = conditions.Remove(startPosition, endPosition - startPosition + 3);
        //    }

        //    if (search != null && search.CbValue != "")// Search normal
        //    {
        //        if (conditions != "")
        //            conditions += " AND ";
        //        conditions += search.CbIdColumn + " = " + search.CbValue;
        //    }
        //    else if (searchLocal != null)// SearchLocal
        //    {
        //        if (searchLocal.CbColumnName != "")
        //        {
        //            if (conditions != "")
        //                conditions += " AND ";
        //            conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
        //        }
        //    }
        //    Methods.updateListView(listView, columns, tables, conditions);
        //}

        //private void search_ConditionChanged(object sender, EventArgs e)
        //{
        //    var search = (Search)sender;
        //    var searchLocal = sender as SearchLocal;
        //    int startPosition;

        //    if (searchLocal == null)
        //        startPosition = _conditions.IndexOf(search.CbIdColumn);
        //    else
        //        startPosition = _conditions.IndexOf(searchLocal.CbColumnName);

        //    if (startPosition != -1)//Foi encontrado
        //    {
        //        var endPosition = _conditions.IndexOf("AND", startPosition);
        //        if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
        //            _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
        //        else
        //            _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
        //    }

        //    if (!string.IsNullOrWhiteSpace(search?.CbValue))// Search normal
        //    {
        //        if (!string.IsNullOrWhiteSpace(_conditions))
        //            _conditions += " AND ";
        //        _conditions += search.CbIdColumn + " = " + search.CbValue;
        //    }
        //    else if (searchLocal != null)// SearchLocal
        //    {
        //        if (!string.IsNullOrWhiteSpace(searchLocal.CbColumnName))
        //        {
        //            if (!string.IsNullOrWhiteSpace(_conditions))
        //                _conditions += " AND ";
        //            _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
        //        }
        //    }
        //    Methods.UpdateListView(listView, _columns, Tables, _conditions);
        //}
    }
}
