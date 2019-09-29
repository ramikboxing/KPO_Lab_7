using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Kpo4381_nmv.Utility
{
    public static class LogUtility
    {
        private static string _fileNameProtocol = null;
        
        public static void Error(string message) // Lab7
        {
         /*using (FileStream fstream = new FileStream(@"C:\VS\Error.txt", FileMode.OpenOrCreate))
         {
             byte[] sendData = Encoding.UTF8.GetBytes(message + "-" + DateTime.Now + "\r\n");
             fstream.Seek(5, SeekOrigin.End);           // End - курсор в конце файла   Begin - начало файла Current - текущее позиция в файле
             fstream.Write(sendData, 0, sendData.Length);
         }*/
         //Конструкция using унчтожает объекты FileStream после того как все операторы и вырожения отработает в блоке 
         //Для лабораторной использует try - finally
                                                     /*OpenOrCeate- если файл сущ-ет, то он перезаписывается иначе создается новый   
                                                     Append -если файл сущ-ет, то текст добавляется в конец файла иначе создается новый. Открывается только для записи
                                                     Create - создать ноывай или перезаписать файл
                                                     CreateNew - создать файл если он уже существует выкинуть ошибку
                                                     Open - открыть файл Если его нет выкинуть ошибку
                                                    Truncare - Если файл существует то он перезаписыывается */
                
         FileStream fstream = null;
          try
          {   //Операция с потоком
                _fileNameProtocol = "Error.txt";
                System.Diagnostics.Debug.Assert(_fileNameProtocol != null, "Имя файла не задано"); // Утверждение
                fstream = new FileStream(@"C:\VS\" + _fileNameProtocol, FileMode.Append);
                byte[] sendData = Encoding.UTF8.GetBytes(message + "-" + DateTime.Now + "\r\n");
                fstream.Write(sendData, 0, sendData.Length);
          }
          finally
          {   //Закрытие потока
                if (fstream != null) fstream.Close();
          }
        }
        public static void ErrorLog(string message)
        {
            string path = @"C:\VS\ErrorLog.txt"; // Расположение файла с сохр-ми ошибками
            File.AppendAllText(path, DateTime.Now + "-" + message + "\r\n");
        }
        public static void ErrorLog(Exception ex)
        {
            string path = @"C:\VS\ErrorLog1.txt";
            File.AppendAllText(path, DateTime.Now + "-" + ex.Message + "\r\n");
        }
    }
}
