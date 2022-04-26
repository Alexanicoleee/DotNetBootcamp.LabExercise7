using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Model;

namespace CSharp.LabExercise7.Exceptions
{
    class AuthenticationException : Exception
    {
        public AuthenticationException() : this("Invalid credentials. Authentication failed.")
        {

        }

        public AuthenticationException(string message) : base(message)
        {

        }
    }

    class AuthenticationService
    {
        public void Authenticate(HashSet<Student> Students)
        {
            if (Students.Count == 0)
            {
                throw new AuthenticationException("Student Record List is Empty.");
            }
        }
    }
}
