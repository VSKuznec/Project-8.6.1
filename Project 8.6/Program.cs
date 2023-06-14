using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = ("C:\\Repository");

            try
            {
                DirectoryInfo Fs = new DirectoryInfo(Path);
                TimeSpan timeSpan = TimeSpan.FromMinutes(30);

                if (Fs.Exists)
                {
                    foreach (FileInfo file in Fs.GetFiles())
                    {
                        if (file.LastAccessTime + timeSpan < DateTime.Now)
                        {
                            file.Delete();
                        }
                    }

                    foreach (DirectoryInfo SubFs in Fs.GetDirectories())
                    {
                        if (SubFs.Exists)
                        {
                            foreach (FileInfo ChildFile in SubFs.GetFiles())
                            {
                                if (ChildFile.LastAccessTime + timeSpan < DateTime.Now)
                                {
                                    ChildFile.Delete();
                                }
                            }

                            Directory.Delete(SubFs.FullName, true);
                        }
                        else
                        {
                            Console.WriteLine("Error: Directory not found at path {0}", SubFs.FullName);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: Folder not found at path {0}", Path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}