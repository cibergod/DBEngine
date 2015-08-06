using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Odbc;
using System.IO;
/*класс соеденения с базой данных */
namespace TryOpenConnect
{
    class ConnectDB
    {
        //базовая папка для потключения
        public string BaseDirectory {get; set;}
       
        //поле для хранения подключения к базе 
        OdbcConnection conn { get; set; }
        
        //создание строки потключения
        string CreateConnectString() 
        {
            //создаем строку потключения к 7 версии парадокса 
            string tmp = @"Driver={Microsoft Paradox Driver (*.db )}; Persist Security Info=False; Mode=Read; Extended Properties='DSN=Paradox; DBQ=%PATCH%; DefaultDir=%PATCH%;DriverId=538; FIL=Paradox 7.X; MaxBufferSize=2048; PageTimeout=600;'; Initial Catalog=%PATCH%;";
            //если директория существует то потключаемся
            if((BaseDirectory!=null) && (BaseDirectory!=""))
            {
                //если папка существует потключаемся к ней 
                if(Directory.Exists(BaseDirectory))
                {
                    //подставляем указанный путь к папке 
                  tmp =  tmp.Replace("%PATCH%",BaseDirectory);
                }
                else tmp="";

            }
            else tmp="";
            //возвращаем результат 
            return tmp;
        }
        //подключаемся к базе данных Paradox
        public bool OpenConnect()
        {
            bool ConnectAccept = false;
            string ConnParem= CreateConnectString();
            //если создали строку подключения пробуем с ней подключиться
            if(ConnParem!="")
            {
                //создаем соеденение с базой данных 
                conn = new OdbcConnection(ConnParem);
                //открываем соеденеие 
                conn.Open();
                //если соеденение открыто то 
                ConnectAccept = (conn.State == ConnectionState.Open);
               
            }
            //возвращаем результат соеденеия
            return ConnectAccept;
        }

        //получает список таблиц в директории
        public string[] GetTable()
        {
            //получаем список файлов 
            return Directory.GetFiles(BaseDirectory, "*.db*");
        }

        //получаем данные из таблицы по запросу  
        public DataTable GetSQL(string SQL) 
        {
            DataTable Result = new DataTable();
            //проверяем запрос если он содержит текст то что то делаем  
            if((SQL!=null)&&(SQL!=""))
            //если соеденение установлено будем что то делать 
            if (OpenConnect()) 
            {
                //формируем запрос
                OdbcCommand QWERY = new OdbcCommand()
                {
                    Connection = conn,
                    CommandText = SQL
                };
                //выполняем запрос
                OdbcDataReader reader = QWERY.ExecuteReader();
                //заполняем результат в виде таблици
                Result.Load(reader);
            }
            //возвращаем результат работы 
            return Result;
        }

    }
}


