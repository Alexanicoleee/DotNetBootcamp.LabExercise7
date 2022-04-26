using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Model;
using System.Collections;
using CSharp.LabExercise7.Exceptions;


namespace CSharp.LabExercise7.Service
{
    class ModifyStudentRecord
    {
        public static void ModifyStudent(HashSet<Student> Students)
        {
            AuthenticationService authenticationService = new AuthenticationService();
            Console.Clear();
            try
            {
                authenticationService.Authenticate(Students);
                StudentRecordList.ListStudent(Students);
                Console.Write("\nEnter Student ID To be Updated: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Student student in Students)
                {
                    if (student.ID == id)
                    {
                        var studentCopy = new ArrayList()
                        {
                            student.ID, student.FirstName, student.LastName, student.GradeLevel, student.Section
                        };
                        int ID = (int)studentCopy[0];
                        Console.Write("Enter Student's new First Name: ");
                        string firstName = Console.ReadLine();
                        if (firstName.Trim().Equals("") || firstName == null) { firstName = (string)studentCopy[1];}
                        Console.Write("Enter Student's new Last Name: ");
                        string lastName = Console.ReadLine();
                        if (lastName.Trim().Equals("") || lastName == null) { lastName = (string)studentCopy[2]; }
                        Console.Write("Enter Student's new Grade Level: ");
                        string gradeLevel = Console.ReadLine();
                        if (gradeLevel.Trim().Equals("") || gradeLevel == null) { gradeLevel = studentCopy[3].ToString(); }
                        GradeLevelList gradeList = (GradeLevelList)Enum.Parse(typeof(GradeLevelList), gradeLevel.ToUpper(), true);
                        Console.Write("Enter Student's new Section: ");
                        string section = Console.ReadLine();
                        if (section.Trim().Equals("") || section == null) { section = studentCopy[4].ToString(); }
                        SectionList sect = (SectionList)Enum.Parse(typeof(SectionList), section.ToUpper(), true);

                        var students = new Student()
                        {
                            ID = ID,
                            FirstName = firstName,
                            LastName = lastName,
                            GradeLevel = gradeList,
                            Section = sect,
                        };
                        Students.Remove(student);
                        Students.Add(students);
                        Console.WriteLine($"Student {students.ID} has been updated\n");
                        return;
                    }
                }
                throw new Exception("Student's id does not exist");   
            }
            catch(AuthenticationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
