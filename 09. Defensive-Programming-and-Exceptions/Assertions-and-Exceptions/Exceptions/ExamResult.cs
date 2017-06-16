using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "Minimum grade cannot be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException(
                    "maxGrade",
                    "Maximum grade cannot be equal or lower than the minimum grade.");
            }

            this.maxGrade = value;
        }
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.MinGrade || this.MaxGrade < value)
            {
                string message = $"The grade should be int the range {this.MinGrade} ... {this.MaxGrade}.";

                throw new ArgumentOutOfRangeException("grade", message);
            }

            this.grade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("comments", "Comments cannot be null or empty.");
            }

            this.comments = value;
        }
    }
}
