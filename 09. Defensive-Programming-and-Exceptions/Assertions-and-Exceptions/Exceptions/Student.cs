﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams; 
     
    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("firstName", "First name cannot be null or empty.");
            }

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
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("lastName", "Last name cannot be null or empty.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams", "The exams cannot be null.");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalculateAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams.");
        }

        double[] examScore = new double[this.Exams.Count];

        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            int gradeRange = examResults[i].MaxGrade - examResults[i].MinGrade;
            double grade = examResults[i].Grade - examResults[i].MinGrade;

            examScore[i] = grade / gradeRange;
        }

        return examScore.Average();
    }
}