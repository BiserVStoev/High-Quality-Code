namespace InheritanceAndPolymorphism.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;
        
        public OffsiteCourse(string courseName, string teacherName, ICollection<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                this.CheckIfNullOrEmpty(value, "town", "Town");

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourse = new StringBuilder();
            offsiteCourse.Append(base.ToString());
            offsiteCourse.Append("; Town = " + this.Town);
            offsiteCourse.Append(" }");

            return offsiteCourse.ToString();
        }
    }
}
