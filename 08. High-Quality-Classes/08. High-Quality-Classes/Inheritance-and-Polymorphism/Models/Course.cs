namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course
    {
        private readonly ICollection<string> students;
        private string courseName;
        private string teacherName;

        protected Course(string courseName, string teacherName, ICollection<string> students)
        {
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                this.CheckIfNullOrEmpty(value, "courseName", "Course name");

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                this.CheckIfNullOrEmpty(value, "teacherName", "Teacher name");

                this.teacherName = value;
            }
        }

        public IEnumerable<string> Students => this.students;

        public virtual void AddStudent(string student)
        {
            this.CheckIfNullOrEmpty(student, "student", "Student");

            this.students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder course = new StringBuilder();
            course.Append(string.Format("{0} {{ Name = ", this.GetType().Name));
            course.Append(this.CourseName);
            course.Append("; Teacher = " + this.TeacherName);
            course.Append("; Students = ");
            course.Append(this.GetStudentsAsString());

            return course.ToString();
        }

        protected void CheckIfNullOrEmpty(string value, string paramName, string messageHolder)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"{paramName}", $"{messageHolder} cannot be null or empty.");
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || !this.Students.Any())
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}
