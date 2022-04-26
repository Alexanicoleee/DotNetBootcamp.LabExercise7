using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Service;

namespace CSharp.LabExercise7.Model
{
    public class Menu
    {
        HashSet<Student> Students;

        public Menu()
        {
            this.Students = new HashSet<Student>();
            Logger logger = Logger.GetInstance();
            logger.AddToLog();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] - Add     Records");
                Console.WriteLine("[2] - List    Records");
                Console.WriteLine("[3] - Modify  Records");
                Console.WriteLine("[4] - Delete  Records");
                Console.WriteLine("[5] - Exit    Program");
                try
                {
                    Console.Write("\nSelect your choice: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            AddStudentRecord.AddStudent(Students);
                            break;
                        case "2":
                            Console.Clear();
                            StudentRecordList.ListStudent(Students);
                            break;
                        case "3":
                            Console.Clear();
                            ModifyStudentRecord.ModifyStudent(Students);
                            break;
                        case "4":
                            Console.Clear();
                            DeleteStudentRecord.DeleteStudent(Students);
                            break;
                        case "5":
                            SaveToFile.Exit(Students);
                            break;
                        default:
                            Console.WriteLine("Please enter a number from 1-5.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\nPress Any Key To Continue...");
                Console.ReadLine();
            }
        }
    }
}
