using System;
using System.Collections.Generic;
using System.Text;
//добавляем библиотеку для работы с таблицами
using System.Data;
namespace DBReaderLoader
{
    //класс для работы с виртуальными таблицами 
    class DataTableAction
    {


        //обьявляем класс загрузки и сохранения XML
        DBXML XMLREadLoad = new DBXML();
        /*
        если функция добавит записи в таблицу то она 
        вернет значение true если не получиться то вернет значение false*/
        public  void insert(
                        DataRow Record, //запись которую нужно добавить в таблицу
                        string NameTable //имя таблицы в которую нужно добавить данные
                   ) 
            { 
           
            //нужно проверить существует ли таблица с таким именем в нашем файловом хранилище
            if (XMLREadLoad.ExistXMLTable(NameTable))
            {
                //если таблица существует то будем в нее записывать данные 
                /*****************************************************************************/
                //открываем таблицу
                DataTable LoadTable = XMLREadLoad.LoadDataTablefromXML(NameTable);
                DataRow tmpRow = LoadTable.NewRow();
                //присваиваем столбцы из параметров столбцам 
                for (int R = 0; R < tmpRow.ItemArray.Length; R++) 
                {
                    //Каждую запись присваваем записи таблицы
                    tmpRow[R] = Record[R];
                }
                //записываем в таблицу строку 
                LoadTable.Rows.Add(tmpRow);
                //Сохраняем таблицу обратно в файл
                XMLREadLoad.SaveDataTableInXML(LoadTable);
                /*****************************************************************************/
            }
            else 
            {
                //если таблицы нет то будем делать что то еще 
            }
           
            }
        //2.0
        //копия функции с инекрементным флагом
        public void insert(
                        DataRow Record, //запись которую нужно добавить в таблицу
                        string NameTable, //имя таблицы в которую нужно добавить данные
                        string IncrementRow
                   )
        {
            if (IncrementRow == "")
            {
                //если значение флага пусто то вызываем 1 функцию для добавления строки
                insert(Record, NameTable);
            }
            else 
            {
                //открываем таблицу
                DataTable LoadTable = XMLREadLoad.LoadDataTablefromXML(NameTable);
                //если в таблице есть записи стоит считать 
                if(LoadTable.Rows.Count>0
                {
                //расчитываем следующее значение для строки 
                var MaxValue = LoadTable.Rows[0][IncrementRow].GetType();
                    //перебираем список значений данного поля во всей таблице
                    foreach(DataRow S in LoadTable.Rows)
                    {
                       
                    }
                }
            }
           
        }
        
    }
}
