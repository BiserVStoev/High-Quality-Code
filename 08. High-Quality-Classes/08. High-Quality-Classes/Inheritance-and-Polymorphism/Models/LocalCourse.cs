namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, ICollection<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                this.CheckIfNullOrEmpty(value, "lab", "Lab");

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder localCourse = new StringBuilder();
            localCourse.Append(base.ToString());
            localCourse.Append("; Lab = " + this.Lab);
            localCourse.Append(" }");

            return localCourse.ToString();
        }
    }
}
