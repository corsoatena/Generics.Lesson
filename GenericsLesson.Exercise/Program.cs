using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generics.Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            PopulateLists(people, logs);
            string path = @"C:\logs\logger"; 
            LogGenerator.WriteLog(people, path);
         //   LogGenerator.WriteLog(logs, path);


           
        } 
        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person() { FirstName="Bruno", CF="BNNVNVB572728788" } );
            people.Add(new Person() { FirstName = "Mario", CF = "KHKJKK5465646" });
            people.Add(new Person() { FirstName = "Elisa", CF = "TGHGHG57767HJHJHJ" });

            logs.Add(new LogEntry() { Message = "prelevato 10000 EURO" });
            logs.Add(new LogEntry() { Message = "prelevato 2000 EURO" });
            logs.Add(new LogEntry() { Message = "prelevato 5000 EURO" });
        }
        //static void WriteLogEntry(List<LogEntry> dati)
        //{
        //    /// Scrive su un file qualsiasi tipo  di class 
        //}
        //static void WriteLogPerson(List<Person> dati)
        //{
            


        //} 

        public static class LogGenerator 
        {
            public static void WriteLog<T>(List<T> rows, string filePath) where T : class
            {
                List<string> lines = new List<string>();
                StringBuilder line = new StringBuilder();

                if (rows == null || rows.Count == 0)
                    return;


                var colonne = rows.First().GetType().GetProperties(); // FirstName, CF

                foreach (var col in colonne) // Add HEADER 
                {
                    line.Append(col.Name);
                    line.Append(',');
                }

                lines.Add(line.ToString().Substring(0, line.Length -1));

                foreach (var row in rows) // Riga composta da N colonne
                {  
                    line = new StringBuilder(); 
                    foreach (var col in colonne)
                    {
                        line.Append(col.GetValue(row));
                        line.Append(',');

                    }

                    lines.Add(line.ToString().Substring(0,line.Length - 1)); 
                }

                File.WriteAllLines(filePath, lines); 
            }
        }
    }
    public class LogEntry
    {    
        public string Message { get; set; }       
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string CF { get; set; }     

    }
}
