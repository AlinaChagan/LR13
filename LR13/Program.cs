using System;
using System.IO;
using System.Text;

namespace Laba13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CHALDiskInfo.OnUpdate += CHALLog.WriteInTXT;
            CHALFileInfo.OnUpdate += CHALLog.WriteInTXT;
            CHALDirInfo.OnUpdate += CHALLog.WriteInTXT;
            CHALFileManager.OnUpdate += CHALLog.WriteInTXT;

            CHALDiskInfo.ShowFreeSpace(@"D:\");
            CHALDiskInfo.ShowFileSystemInfo(@"C:\");
            CHALDiskInfo.ShowAllDrivesInfo();

            CHALFileInfo.ShowFullPath(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Log.txt");
            CHALFileInfo.ShowFileInfo(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Log.txt");
            CHALFileInfo.ShowFileDates(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Log.txt");

            CHALDirInfo.ShowCreationTime(@"C:\ALINA\Term3");
            CHALDirInfo.ShowNumberOfFiles(@"C:\ALINA\Term3");
            CHALDirInfo.ShowNumberOfSubdirectories(@"C:\ALINA\Term3");
            CHALDirInfo.ShowParentDirectory(@"C:\ALINA\Term3");

            CHALFileManager.InspectDrive(@"С:\");
            CHALFileManager.CopyFiles(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\", ".cs");
            CHALFileManager.Archive(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Archivetest", @"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Unarchivetest");
            FindInfo();
        }

        public static void FindInfo()
        {
            //Немного шиткода и танцев с бубном ради странного функционала,но его люди обычно вообще не делают,так что я хоть попытался и оно працуе 
            var output = new StringBuilder();

            using (var stream = new StreamReader(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Log.txt"))
            {
                var textline = "";
                var isActual = false;
                while (stream.EndOfStream == false)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += "\n";
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "------------------------------")
                    {
                        if (isActual)
                        {
                            textline += "\n";
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual) output.AppendFormat("------------------------------\n");
                }
            }

            using (var stream = new StreamWriter(@"C:\ALINA\Term3\ООП\лабораторные\лаба13\LR13\Log.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}