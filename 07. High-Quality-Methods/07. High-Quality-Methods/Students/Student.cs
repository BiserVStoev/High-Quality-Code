namespace Students
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateNullOrEmpty(value, "fisrtName", "First name");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateNullOrEmpty(value, "lastName", "Last name");

                this.lastName = value;
            }
        }

        public string AdditionalInfo { get; set; }

        public DateTime DateOfBirth { get; }

        public bool IsOlderThan(Student other)
        {
            var firstDate = this.DateOfBirth;
            var secondDate = other.DateOfBirth;

            return firstDate < secondDate;
        }

        private void ValidateNullOrEmpty(string stringToValidate, string paramName, string type)
        {
            if (string.IsNullOrWhiteSpace(stringToValidate))
            {
                throw new ArgumentNullException(paramName, $"{type} cannot be null or empty.");
            }
        }
    }
}
