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
        }
    }
}
