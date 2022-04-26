using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.LabExercise7.Model;
using CSharp.LabExercise7.Exceptions;


namespace CSharp.LabExercise7.Service
{
    class StudentRecordList
    {
        public static void ListStudent(HashSet<Student> Students)
        {
            AuthenticationService authenticationService = new AuthenticationService();
            Console.Clear();
            try
            {
                authenticationService.Authenticate(Students);
                Console.WriteLine("\t\t\t========== STUDENT RECORD LIST =========");
                IEnumerable<Student> query = Students.OrderBy(stud => stud.ID);
                foreach (var student in query)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine();
                Console.Write("Do you want to search Student Record? (y to search/ any key to Menu): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Console.Write("Search by ID: ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    foreach (var student in query)
                    {
                        if (student.ID == ID)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\t========== STUDENT RECORD LIST =========");
                            Console.WriteLine($"Searched Student ID: {ID}");
                            Console.WriteLine(student);
                            return;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("\t\t\t========== STUDENT RECORD LIST =========");
                    Console.WriteLine($"Searched Student ID {ID} not found");
                }
                else
                {
                    return;
                }
                
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
