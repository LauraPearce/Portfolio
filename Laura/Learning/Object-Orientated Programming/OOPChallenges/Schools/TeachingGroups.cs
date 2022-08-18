using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Schools
{
    public class TeachingGroups
    {
        /// <summary>
        /// the name of a teaching group
        /// </summary>
        public string TeachingGroup { get; set; }
        /// <summary>
        /// a list of students
        /// </summary>
        public List<Student> Students { get; set; }

        /// <summary>
        /// creates a new teaching group
        /// </summary>
        /// <param name="teachingGroup"> sets the name of the group</param>
        /// <param name="students"> sets the list of students within that group</param>
        public TeachingGroups(string teachingGroup, List<Student> students)
        { 
            TeachingGroup = teachingGroup;          
            Students = students;    
        }

        /// <summary>
        /// calculates the highest and lowest score from a list of students
        /// </summary>
        /// <param name="listOfStudents"> list of students which contains their latest test score</param>
        /// <param name="studentWithLowestScore"> output the student with the lowest score</param>
        /// <returns> return the student with the highest score </returns>
        public static Student GetHighestAndLowestScore(List<Student> listOfStudents, out Student studentWithLowestScore)
        {
            listOfStudents.Sort((a, b) => b.LatestTestScore.CompareTo(a.LatestTestScore));

            Student studentWithHighestScore = listOfStudents.First();
            studentWithLowestScore = listOfStudents.Last();

            return studentWithHighestScore;
        }

        /// <summary>
        /// calculates the average score from a list of students
        /// </summary>
        /// <param name="listOfStudents"> contains a list of students which includes their latest test score</param>
        /// <returns> text which contains the average score </returns>
        public static string GetAverageScore(List<Student> listOfStudents)
        {
            decimal allScoresTotalled = 0;

            foreach (var student in listOfStudents)
            {
                allScoresTotalled += student.LatestTestScore;
            }

            allScoresTotalled = Math.Round(allScoresTotalled / listOfStudents.Count);

            return $"the average score of the students is {allScoresTotalled}.";
        }




    }
}
