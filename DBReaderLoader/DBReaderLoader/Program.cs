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
            //загрузим таблицу чтобы знать ее столбцы
            DataTable MyNewTable = MyCreateTable.LoadDataTablefromXML("Test");
            //создаем пустую строку на основе стобцов таблицы
            DataRow MyNewRow = MyNewTable.NewRow();
            //заполняем значение строк таблицы
            MyNewRow["ID"]          = 1;
            MyNewRow["MyTestText"]  = "Test Text";
            //обьявляем класс работы с таблицей
            DataTableAction MyActionInTable = new DataTableAction();
            //вызываем функцию добавления строки в таблицу
            MyActionInTable.insert(MyNewRow, "Test");
            /************************************************************************************/
            
        }
    }
}
