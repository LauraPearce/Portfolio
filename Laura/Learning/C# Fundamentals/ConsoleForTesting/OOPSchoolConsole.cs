using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPChallenges.Schools;

namespace ConsoleForTesting
{
    public static class OOPSchoolConsole
    {
        public static void Run()
        {
            // hardcoded data for testing
            Student studentOne = new Student("John", "Smith");
            Student studentTwo = new Student("Carl", "Pearce");
            Student studentThree = new Student("Tracey", "Jeeves");
            Student studentFour = new Student("Nikki", "Jeeves");
            Student studentFive = new Student("Tracey", "Smith");
            Student studentSix = new Student("Ann", "Pearce");

            studentOne.LatestTestScore = 14;
            studentTwo.LatestTestScore= 15;
            studentThree.LatestTestScore = 65;
            studentFour.LatestTestScore = 76;
            studentFive.LatestTestScore = 56;
            studentSix.LatestTestScore = 55;

             // creates lists of students       
            List<Student> allStudents = new List<Student>() {studentOne, studentTwo, studentThree, studentFour, studentFive, studentSix};
            List<Student> englishClass = new List<Student>() { studentOne, studentTwo, studentThree };
            List<Student> mathsClass = new List<Student>() { studentFour, studentFive, studentSix };

            // TeachingGroups
            TeachingGroups redForm = new TeachingGroups("7Y", allStudents);
            TeachingGroups redEnglish = new TeachingGroups("English Class", englishClass);
            TeachingGroups redMaths = new TeachingGroups("Maths Class", mathsClass);
                                

            // displays the score of each student
            foreach (var student in allStudents)
            {
                Console.WriteLine($"{student.FirstName}'s test score is {student.LatestTestScore}.");
            }
            Console.WriteLine();
            Console.WriteLine();

            //displays the names and scores of the students with the best and worst marks in english and maths
            Student studentWithHighestScore = TeachingGroups.GetHighestAndLowestScore(englishClass, out Student studentWithLowestScore);

            Console.Write($"In English, {studentWithHighestScore.FirstName} has the highest score of {studentWithHighestScore.LatestTestScore}.");
            Console.Write($" {studentWithLowestScore.FirstName} has the lowest score of {studentWithLowestScore.LatestTestScore}.");

            studentWithHighestScore = TeachingGroups.GetHighestAndLowestScore(mathsClass, out studentWithLowestScore);

            Console.Write($"In Maths, {studentWithHighestScore.FirstName} has the highest score of {studentWithHighestScore.LatestTestScore}.");
            Console.WriteLine($" {studentWithLowestScore.FirstName} has the lowest score of {studentWithLowestScore.LatestTestScore}.");
           
            Console.WriteLine();
            Console.WriteLine();
            
            // displays the average scores of the english and maths classes
            Console.WriteLine($"In English, {TeachingGroups.GetAverageScore(englishClass)}");
            Console.WriteLine($"In Maths, {TeachingGroups.GetAverageScore(mathsClass)}");

            //displays the average score of all students 
            Console.WriteLine($"Across the year group, { TeachingGroups.GetAverageScore(allStudents)}");
            
        }
    }
}
