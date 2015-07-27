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
        bool insert(
                        DataRow Record, //запись которую нужно добавить в таблицу
                        string NameTable //имя таблицы в которую нужно добавить данные
                   ) 
        { 
            //флаг добавления данных 
            bool INSERT=false;
            //нужно проверить существует ли таблица с таким именем в нашем файловом хранилище
            if (XMLREadLoad.ExistXMLTable(NameTable))
            {
                //если таблица существует то будем в нее записывать данные 
                /*****************************************************************************/
                //открываем таблицу
                DataTable LoadTable = XMLREadLoad.LoadDataTablefromXML(NameTable);
                //записываем в таблицу строку 
                LoadTable.Rows.Add(Record);
                //Сохраняем таблицу обратно в файл
                XMLREadLoad.SaveDataTableInXML(LoadTable);
                /*****************************************************************************/
            }
            else 
            {
                //если таблицы нет то будем делать что то еще 
            }
            //возвращаем результат
            return INSERT;
        }
        
    }
}
