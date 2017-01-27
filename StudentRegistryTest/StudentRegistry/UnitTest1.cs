using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentRegistry
{
    public struct Subject
    {
        public string subjectName;
        public int[] grades;
        public Subject(string subjectName, int[] grades)
        {
            this.subjectName = subjectName;
            this.grades = grades;
        }
    }
    public struct Student
    {
        public string studentName;
        public Subject[] subjects;
        public Student(string studentName, Subject[] subjects)
        {
            this.studentName = studentName;
            this.subjects = subjects;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var students = new Student[] { new Student("Andrew Wiggins", new Subject[] { new Subject("math", new int[] { 10, 8, 9 }), new Subject("English", new int[] { 9, 9, 8, 4 }), new Subject("Science", new int[] { 5, 4, 10, 10 }) }), new Student("Jabari Parker", new Subject[] { new Subject("Science", new int[] { 5, 5, 4, 7 }), new Subject("English", new int[] { 10, 9 }), new Subject("Math", new int[] { 6, 7, 4, 10 }) }), new Student("Giannis Antetokounmpo", new Subject[] { new Subject("English", new int[] { 8, 8, 9 }), new Subject("Math", new int[] { 9, 7, 8, 4 }), new Subject("Science", new int[] { 4, 9, 6, 8 }) }) };
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        public void TestAverageGradeOfStudent()
        {
            var student=new Student("Andrew Wiggins", new Subject[] { new Subject("math", new int[] { 10, 8, 9 }), new Subject("English", new int[] { 9, 9, 8, 6 }), new Subject("Science", new int[] { 5, 7, 10, 10 }) });
            Assert.AreEqual(8.33m, AverageGeneralGrade(student)); 
        }

        decimal AverageGeneralGrade(Student student)
        {
            decimal[] averageGradeForEachSubject = new decimal[0];
            decimal averageGrade = 0;      
            for (int i = 0; i < student.subjects.Length; i++)
            {
                decimal numberOfGrades = 0;
                for (int j = 0; j < student.subjects[i].grades.Length; j++)
                {
                    
                    Array.Resize(ref averageGradeForEachSubject, averageGradeForEachSubject.Length + 1);
                    averageGradeForEachSubject[i] += student.subjects[i].grades[j];
                    numberOfGrades++;
                }
                averageGradeForEachSubject[i] = averageGradeForEachSubject[i] / numberOfGrades;
                averageGrade += averageGradeForEachSubject[i];
            }
            
            return Math.Round(averageGrade/student.subjects.Length,2, MidpointRounding.AwayFromZero);
        }
    }
}
