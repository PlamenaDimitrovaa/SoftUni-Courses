using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private int _count;
        List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }

        public int Count => students.Count;


        public string RegisterStudent(Student student)
        {
            if (Capacity <= Count)
            {
                return "No seats in the classroom";
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
            {
                students.Remove(students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";

        }

        public string GetSubjectInfo(string subject)
        {
            var studentsSubject = students.Where(x => x.Subject == subject).ToList();
            if (studentsSubject.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (Student student in students)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return students.Count();
        }
        public Student GetStudent(string firstName, string lastName)
        {
            var currentStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return currentStudent;
        }
    }
}

