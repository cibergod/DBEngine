using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DirFindSPR
{



    class Program
    {
        static string PATCH = "";
        static DirectoryInfo MyDir;
        static void DirList()
        {
            string[] ListDir = Directory.GetDirectories(PATCH);

            string Name = "";
            foreach (string N in ListDir)
            {
             //   Console.WriteLine(N);
                MyDir = new DirectoryInfo(N);
                try
                {
                    Convert.ToInt32(MyDir.Name);
                    Console.WriteLine(MyDir.Name);
                }
                catch 
                { 
                    //не подходит 
                }



                
            }
        }

        static void Main(string[] args)
        {
            PATCH = @"o:\162T_01\DATA\KZN\";
            DirList();

            Console.ReadKey();
        }
    }
}
