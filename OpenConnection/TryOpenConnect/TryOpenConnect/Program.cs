using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TryOpenConnect
{
    class Program
    {
        static void Main(string[] args)
        {
                ConnectDB MyDB = new ConnectDB();
                MyDB.BaseDirectory = @"d:\Paradox\";
          
                
            
            Console.ReadKey();
        }
    }
}



