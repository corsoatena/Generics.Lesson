using System;
using System.Collections.Generic;

namespace Generics.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataList<Student> dataStore = new DataList<Student> ();
            dataStore.PrintProperties();
        }

        public class DataList<T> where T : class, new()        
        {
            int counter = 0; 
            static int _index = 10;
            T[] _myArray = new T[_index];

            T obj = new(); // Student obj = new Student(); 
            public void Add(T eleString)
            {
                _myArray[counter] = eleString;
                counter++;
            } 
            public void PrintProperties()
            {
                foreach (var item in obj.GetType().GetProperties())
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    } 
    public class Person
    {
        public string FullName { get; set; }
        public int Id { get; set; }

        //public Person()
        //{

        //}
    }
    public class Student
    {
        public int Matricola { get; set; }
        public int VotoDiLaurea { get; set; }
    }
} 
