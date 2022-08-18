using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPChallenges.Schools
{
    public class Student
    {
        /// <summary>
        /// holds the first name of a student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// holds the last name of a student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// holds the latest test score of a student
        /// </summary>
        private int latestTestScore;

        public int LatestTestScore
        {
            get { return latestTestScore; }
            set
            {
                // validates if the test score is outside of 1-100
                if (value <= 100 && value > 0)
                {
                    latestTestScore = value; 
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(latestTestScore), "Test Score must be between 1 and 100.");    
                }
            }
        }

        /// <summary>
        /// creates a student
        /// </summary>
        /// <param name="firstName">sets a first name</param>
        /// <param name="lastName">sets a last name</param>
        public Student (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName= lastName;
        }

        /// <summary>
        /// creates a student who already has a test score
        /// </summary>
        /// <param name="firstName">sets a first name</param>
        /// <param name="lastName">sets a last name</param>
        /// <param name="latestTestScore">sets a test score</param>
        public Student(string firstName, string lastName, int latestTestScore) : this(firstName, lastName)
        {
            LatestTestScore = latestTestScore;
        }

    }
}
