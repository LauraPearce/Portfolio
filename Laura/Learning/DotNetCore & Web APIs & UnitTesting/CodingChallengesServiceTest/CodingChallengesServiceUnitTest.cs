using CodingChallenges;
using CodingChallenges.Services;
using CodingChallenges.Test.Mocks;

namespace CodingChallengesServiceTest
{
    //TODO: rename tests using the best practise doc
    [TestClass]
    public class CodingChallengesServiceUnitTest
    {
        [TestMethod]
        public void FindTheSmallestAndBiggestNumbersSuccess()
        {
            // arrange
            List<int> numbers = new List<int> { 43, 6356, 41, 63, 9 };
            List<int> expected = new List<int> { 9, 6356 };

            // act
            List<int> actual = CodingChallengesService.FindTheSmallestAndBiggestNumbers(numbers);

            // assert
            Assert.AreEqual(expected.First(), actual.First());
            Assert.AreEqual(expected.Last(), actual.Last());
        }

        [TestMethod]
        public void HackerSpeakSuccess()
        {
            // arrange
            string text = "Convert to hacker speak please.";
            string expected = "C0nv3rt t0 h4ck3r 5p34k pl3453.";

            // act
            string actual = CodingChallengesService.HackerSpeak(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HowManyDsSuccess()
        {
            // arrange
            string text = "dog dog Dog.";
            int expected = 3;

            // act
            int actual = CodingChallengesService.HowManyDs(text);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FizzBuzzSuccess()
        {
            // arrange
            int number = 15;
            string expected = "FizzBuzz";

            // act
            string actual = CodingChallengesService.FizzBuzzInterviewQuestion(number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FizzSuccess()
        {
            // arrange
            int number = 12;
            string expected = "Fizz";

            // act
            string actual = CodingChallengesService.FizzBuzzInterviewQuestion(number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BuzzSuccess()
        {
            // arrange
            int number = 20;
            string expected = "Buzz";

            // act
            string actual = CodingChallengesService.FizzBuzzInterviewQuestion(number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotFizzBuzzFizzOrBuzzSuccess()
        {
            // arrange
            int number = 17;
            string expected = "17";

            // act
            string actual = CodingChallengesService.FizzBuzzInterviewQuestion(number);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateFileSuccess()
        {
            // arrange            
            string filePath = @"C:\Documents and Settings\user\Desktop\hocuspocus";
            string expected = "hocuspocus.txt";

            // act
            string actual = CodingChallengesService.CreateFile(filePath);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AmongUsImposterFormulaSuccess()
        {
            // arrange            
            double player = 10;
            double imposter = 2;
            double expected = 20;

            // act
            double actual = CodingChallengesService.AmongUsImposterFormula(player, imposter);

            // assert
            Assert.AreEqual(expected, actual);
        }

            //TODO: check that you finished a test for all of the coding challenges

        [TestMethod]
        public void ThrowExceptionForWrongHandLengthSuccess()
        {
            // arrange
            string[] hand = new string[1] {"3hhh"};

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CodingChallengesService.PokerHandRanking(hand));
        }

        [TestMethod]
        public void ThrowExceptionForIncorrectSuitEntrySuccess()
        {
            // arrange
            string[] hand = new string[1] { "3b" };

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CodingChallengesService.PokerHandRanking(hand));
        }

        [TestMethod]
        public void ThrowExceptionIfCardValueCannotBeParsedSuccess()
        {
            // arrange
            string[] hand = new string[1] { "$h" };

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CodingChallengesService.PokerHandRanking(hand));
        }

        [TestMethod]
        public void ThrowExceptionForCardValueOutOfRangeSuccess()
        {
            // arrange
            string[] hand = new string[1] { "53h" };

            // act and assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CodingChallengesService.PokerHandRanking(hand));
        }

        [TestMethod]
        public void RoyalFlushSuccess()
        {
            // arrange
            string[] hand = new string[5] { "10h", "Jh", "Qh", "Kh", "Ah" };
            string expected = "Royal Flush";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StraightFlushSuccess()
        {
            // arrange
            string[] hand = new string[5] { "10h", "9h", "8h", "7h", "6h" };
            string expected = "Straight Flush";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourOfAKindSuccess()
        {
            // arrange
            string[] hand = new string[5] { "10h", "10d", "10s", "10c", "6h" };
            string expected = "Four Of A Kind";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(expected, actual);
        }

        //TODO: change to expected from name of card hand
        [TestMethod]
        public void FullHouseSuccess()
        {
            // arrange
            string[] hand = new string[5] { "10h", "10d", "10s", "6c", "6h" };
            string fullHouse = "Full House";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(fullHouse, actual);
        }

        [TestMethod]
        public void FlushSuccess()
        {
            // arrange
            string[] hand = new string[5] { "9h", "5h", "Qh", "3h", "2h" };
            string flush = "Flush";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(flush, actual);
        }


        [TestMethod]
        public void StraightSuccess()
        {
            // arrange
            string[] hand = new string[5] { "6h", "5d", "4s", "3c", "2h" };
            string straight = "Straight";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(straight, actual);
        }

        [TestMethod]
        public void ThreeOfAKindSuccess()
        {
            // arrange
            string[] hand = new string[5] { "6h", "6d", "6s", "3c", "2h" };
            string threeOfAKind = "Three Of A Kind";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(threeOfAKind, actual);
        }


        [TestMethod]
        public void TwoPairsSuccess()
        {
            // arrange
            string[] hand = new string[5] { "6h", "6d", "10s", "10c", "2h" };
            string twoPairs = "Two Pairs";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(twoPairs, actual);
        }


        [TestMethod]
        public void PairSuccess()
        {
            // arrange
            string[] hand = new string[5] { "6h", "7d", "10s", "10c", "2h" };
            string pair = "Pair";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(pair, actual);
        }


        [TestMethod]
        public void HighCardSuccess()
        {
            // arrange
            string[] hand = new string[5] { "6h", "7d", "10s", "Jc", "2h" };
            string expected = "High Card";

            // act
            string actual = CodingChallengesService.PokerHandRanking(hand);

            // assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void SomethingThatUsesExternalComponentSuccess()
        {
            // arrange
            string firstName = "Roger";
            string secondName = "Smith";
            string expected = "Roger Smith";
            MockExternalComponentService mockExternalComponentService = new MockExternalComponentService(); 

            // act
            string actual = CodingChallengesService.SomethingThatUsesExternalComponent(mockExternalComponentService, firstName, secondName);

            // assert
            Assert.AreEqual(expected, actual);

        }









    }
}