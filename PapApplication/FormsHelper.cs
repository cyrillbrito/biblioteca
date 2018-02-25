using CbClass;
using System;

namespace PapApplication
{
    static class FormsHelper
    {
        public static string SearchConditionChanged(object sender, string conditions)
        {
            var search = sender as Search;
            var searchLocal = sender as SearchLocal;

            var startPosition = conditions.IndexOf(searchLocal == null ? search.CbIdColumn : searchLocal.CbColumnName, StringComparison.Ordinal);

            if (startPosition != -1)//Foi encontrado
            {
                var endPosition = conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
                    conditions = conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    conditions = conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (search != null && search.CbValue != "")// Search normal
            {
                if (conditions != "")
                    conditions += " AND ";
                conditions += search.CbIdColumn + " = " + search.CbValue;
            }
            else if (searchLocal != null)// SearchLocal
            {
                if (searchLocal.CbColumnName != "")
                {
                    if (conditions != "")
                        conditions += " AND ";
                    conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
                }
            }

            return conditions;
        }
    }
}
