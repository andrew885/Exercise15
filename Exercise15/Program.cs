using System;
using ClassLibrary1;
using System.IO;
using System.Collections.Generic;
using Ionic.Zip;
using System.Text;

namespace Exercise15
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string path = @"Q:\ItAcademy\Homework\Tasks";
            string name = "Test.txt";
            List<string> Folders = GetFolders(path);
            Folders.Add(path);
            List<string> Files = new List<string>();

            foreach (var item in Folders)
            {
                string[] filePaths = Directory.GetFiles(@$"{item}", name);
                foreach (var filepath in filePaths)
                {
                    Files.Add(filepath);
                }
            }            

            if (Files.Count > 0)
            {
                using (ZipFile zip = new())
                {
                    foreach (var file in Files)
                    {                       
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                        zip.AddFile(file);
                        string zipfile = file.Remove(file.Length - 4);
                        zip.Save(zipfile + ".zip");

                        Console.WriteLine(zipfile + ".zip");
                    }
                }
            }
            else
            {
                throw new CustomException("Нет такого файла");
            }

        }

        static List<string> Folders = new List<string>();
        public static List<string> GetFolders(string path)
        {            
            DirectoryInfo dir = new DirectoryInfo(path);
           
            if (dir.GetDirectories().Length > 0)
            {                
                foreach (var item in dir.GetDirectories())
                {
                    Folders.Add(item.FullName);
                    string childFolder = @$"{item.FullName}";
                    GetFolders(@childFolder);
                }                
            }            
            return Folders;
        }        
    }
}
