using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || MaxProblemsSolved < value)
            {
                string message = string.Format(
                    "The number of problems solved must be in the range {0}...{1}",
                    MinProblemsSolved,
                    MaxProblemsSolved);

                throw new ArgumentOutOfRangeException(
                    "problemsSolved",
                    message);
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved >= 0 && this.ProblemsSolved <= 2)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }

        if (this.ProblemsSolved >= 3 && this.ProblemsSolved <= 5)
        {
            return new ExamResult(3, 2, 6, "Poor result: few problems solved.");
        }

        if (this.ProblemsSolved >= 6 && this.ProblemsSolved <= 7)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }

        if (this.ProblemsSolved > 8 && this.ProblemsSolved <= 9)
        {
            return new ExamResult(5, 2, 6, "Good result: some problems solved.");
        }

        return new ExamResult(6, 2, 6, "Excellent result: nothing done.");
    }
}
