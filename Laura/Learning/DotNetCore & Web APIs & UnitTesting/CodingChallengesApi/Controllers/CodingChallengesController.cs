using Microsoft.AspNetCore.Mvc;
using CodingChallenges.Services;

namespace CodingChallenges
{
    [ApiController]
    [Route("[controller]")]
    public class CodingChallengesController : Controller
    {
        [HttpPost("FindTheSmallestAndBiggestNumbers")]
        public IActionResult FindTheSmallestAndBiggestNumbers(List<int> numbers)
        {
            List<int> result = CodingChallengesService.FindTheSmallestAndBiggestNumbers(numbers);
            return Ok(result);
        }

        [HttpPost("HackerSpeak")]
        public IActionResult HackerSpeak(string text)
        {
            string result = CodingChallengesService.HackerSpeak(text);
            return Ok(result);
        }

        [HttpPost("HowManyDs")]
        public IActionResult HowManyDs(string text)
        {
            int result = CodingChallengesService.HowManyDs(text);
            return Ok(result);
        }

        [HttpPost("FizzBuzzInterviewQuestion")]
        public IActionResult FizzBuzzInterviewQuestion(int number)
        {
            string result = CodingChallengesService.FizzBuzzInterviewQuestion(number);
            return Ok(result);
        }

        [HttpPost("CreateFile")]
        public IActionResult CreateFile(string path)
        {
            string result = CodingChallengesService.CreateFile(path);
            return Ok(result);
        }

        [HttpPost("AmongUsImposterFormula")]
        public IActionResult AmongUsImposterFormula(double player, double imposter)
        {
            double result = CodingChallengesService.AmongUsImposterFormula(player, imposter);
            return Ok(result);
        }

        [HttpPost("AtmPinCodeLengthValidation")]
        public IActionResult AtmPinCodeLengthValidation(string pin)
        {
            string result = CodingChallengesService.AtmPinCodeLengthValidation(pin);
            return Ok(result);
        }

        [HttpPost("IsThePhoneNumberFormattedCorrectly")]
        public IActionResult IsThePhoneNumberFormattedCorrectly(string number)
        {
            string result = CodingChallengesService.IsThePhoneNumberFormattedCorrectly(number);
            return Ok(result);
        }

        [HttpPost("CheckIfANumberIsPrime")]
        public IActionResult CheckIfANumberIsPrime(int number)
        {
            string result = CodingChallengesService.CheckIfANumberIsPrime(number);
            return Ok(result);
        }

        [HttpPost("PokerHandRanking")]
        public IActionResult PokerHandRanking(string[] hand)
        {
            string handValue = CodingChallengesService.PokerHandRanking(hand);

            // no errow thrown by poker hand ranking
            if (handValue != null)
            {
                return Ok(handValue);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, handValue);
            }
        }

        [HttpPost("SomethingThatUsesExternalComponentEndpoint")]
        public IActionResult SomethingThatUsesExternalComponentEndpoint(int number)
        {
            string result = CodingChallengesService.CheckIfANumberIsPrime(number);
            return Ok(result);
        }

    }
}
