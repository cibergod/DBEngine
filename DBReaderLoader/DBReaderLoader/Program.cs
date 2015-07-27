using System;
using System.Collections.Generic;
using System.Text;
//библиотека для работы  стаблицами
using System.Data;
namespace DBReaderLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявляем  класс для создания таблицы
            DBXML MyCreateTable = new DBXML();
            //объявляем  список столбцов таблицы
            List<DataColumn> CollumnTable = new List<DataColumn>();
            
            //создаем новый столбец.
            DataColumn 
                column = new DataColumn(); 
            //создаем числовое поле 
            column.DataType = System.Type.GetType("System.Int32");
            //задаем имя столбцу
            column.ColumnName = "ID";
            //добавляем в список столбцов
            CollumnTable.Add(column);

            column = new DataColumn(); //создаем новый столбец.
            //создаем числовое поле 
            column.DataType = System.Type.GetType("System.String");
            //задаем имя столбцу
            column.ColumnName = "MyTestText";
            //добавляем в список столбцов
            CollumnTable.Add(column);

            //создаем таблицу
            DataTable MyNewTable =   MyCreateTable.CreateTable("Test",CollumnTable);
            //запустим создание таблицы и сохранение ее в файл
            MyCreateTable.SaveDataTableInXML(MyNewTable);
            
        }
    }
}
