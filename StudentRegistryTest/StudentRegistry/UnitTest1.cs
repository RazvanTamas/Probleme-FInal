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
            Assert.AreEqual(8.33m, AverageGeneralGradeForEachStudent(student)); 
        }

        [TestMethod]
        public void TestCountACertainGradeForEachStudent()
        {
            var student = new Student("Andrew Wiggins", new Subject[] { new Subject("math", new int[] { 10, 8, 9 }), new Subject("English", new int[] { 9, 9, 8, 6 }), new Subject("Science", new int[] { 5, 7, 10, 10 }) });
            Assert.AreEqual(3, CountACertainGradeForEachStudent(student, 10));
        }

        [TestMethod]
        public void TestSeparateNames()
        {
            var student = new Student("Andrew Wiggins The Third", new Subject[] { new Subject("math", new int[] { 10, 8, 9 }), new Subject("English", new int[] { 9, 9, 8, 6 }), new Subject("Science", new int[] { 5, 7, 10, 10 }) });
            CollectionAssert.AreEqual(new string[] { "Andrew", "Wiggins","The","Third" }, SeparateNamesInDifferentStrings(student));
        }

        [TestMethod]
        public void TestIfInAlphabeticalOrder()
        {
            string[] studentOne = new string[] { "Joany","Darter" };
            string[] studentTwo = new string[] { "John","Barter", "Misc" };
            Assert.AreEqual(true, CheckIfInAlphabeticalOrder(studentOne, studentTwo));
        }

        decimal AverageGeneralGradeForEachStudent(Student student)
        {
            decimal[] averageGradeForEachSubject = new decimal[0];
            decimal averageGrade = 0;      
            for (int i = 0; i < student.subjects.Length; i++)
            {
                AverageGradeForEachSubject(student, ref averageGradeForEachSubject, ref averageGrade, i);
            }
            return Math.Round(averageGrade/student.subjects.Length,2, MidpointRounding.AwayFromZero);
        }

        private static void AverageGradeForEachSubject(Student student, ref decimal[] averageGradeForEachSubject, ref decimal averageGrade, int i)
        {        
            for (int j = 0; j < student.subjects[i].grades.Length; j++)
            {

                Array.Resize(ref averageGradeForEachSubject, averageGradeForEachSubject.Length + 1);
                averageGradeForEachSubject[i] += student.subjects[i].grades[j];           
            }
            averageGradeForEachSubject[i] = averageGradeForEachSubject[i] / student.subjects[i].grades.Length;
            averageGrade += averageGradeForEachSubject[i];
        }

        int CountACertainGradeForEachStudent(Student student,int grade)
        {
            int count = 0;
            for (int i = 0; i < student.subjects.Length; i++)
            {
                count = GoThroughSubjectToCountGrade(student, grade, count, i);
            }
            return count;
        }

        private static int GoThroughSubjectToCountGrade(Student student, int grade, int count, int i)
        {
            for (int j = 0; j < student.subjects[i].grades.Length; j++)
                if (student.subjects[i].grades[j] == grade)
                    count++;
            return count;
        }

        string[] SeparateNamesInDifferentStrings(Student student)
        {                     
            string[] names = new string[1];
            int j = 0;
            for (int i = 0; i < student.studentName.Length; i++)
            {
                if (student.studentName[i]!=' ')
                    names[j] += student.studentName[i];
                else
                {
                    Array.Resize(ref names, names.Length + 1);
                    j++;                  
                }          
            }
            return names;
        }

        public bool CheckIfInAlphabeticalOrder(string[]studentOneNames,string[]studentTwoNames)
        {
            int minNumberOfNames = (studentOneNames.Length < studentOneNames.Length) ? studentOneNames.Length : studentTwoNames.Length;
            bool isAlphabetical = true;
            for (int i = 0; i < minNumberOfNames; i++)
            {
                int j = 0;               
                while (j < minLengthOfNames(studentOneNames[i], studentTwoNames[i]))
                {
                    if (studentOneNames[i][j] < studentTwoNames[i][j])
                        return isAlphabetical = true;
                    else if (studentOneNames[i][j] > studentTwoNames[i][j])
                        return isAlphabetical = false;
                    else j++;
                }             
            }
            return isAlphabetical;
        }

        int minLengthOfNames(string nameOne,string nameTwo)
        {
            return (nameOne.Length < nameTwo.Length) ? nameOne.Length : nameTwo.Length;           
        }
    }
}
