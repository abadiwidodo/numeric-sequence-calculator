using System.Text;
using NumericSequenceCalculator.Controllers;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace NumericSequenceCalculator.UnitTests
{
    [TestFixture]
    public class SequenceCalculatorTest
    {
        [TestCase(10, 1, "1 2 3 4 5 6 7 8 9 10")]
        [TestCase(100, 1, "91 92 93 94 95 96 97 98 99 100")]
        [TestCase(1000, 1, "996 997 998 999 1000")]
        [TestCase(10000, 1, "9996 9997 9998 9999 10000")]
        [TestCase(100000, 1, "99996 99997 99998 99999 100000")]
        public void SequenceCalculator_Generate_Sequence_Correctly(int intNumber, int loadNumber, string expectedPartialResult)
        {
            // Act
            StringBuilder result = SequenceCalculator.GetSequence(intNumber, loadNumber);
            Assert.IsTrue(result.ToString().Contains(expectedPartialResult));
        }

        [TestCase(10, 1, "2 4 6 8 10")]
        [TestCase(100, 1, "92 94 96 98 100")]
        [TestCase(1000, 1, "996 998 1000")]
        [TestCase(10000, 1, "9996 9998 10000")]
        [TestCase(100000, 1, "99996 99998 100000")]
        public void SequenceCalculator_Generate_Odds_Sequence_Correctly(int intNumber, int loadNumber, string expectedPartialResult)
        {
            // Act
            StringBuilder result = SequenceCalculator.GetOddsSequence(intNumber, loadNumber);
            Assert.IsTrue(result.ToString().Contains(expectedPartialResult));
        }


        [TestCase(10, 1, "1 3 5 7 9")]
        [TestCase(100, 1, "91 93 95 97 99")]
        [TestCase(1000, 1, "997 999")]
        [TestCase(10000, 1, "9997 9999")]
        [TestCase(100000, 1, "99997 99999")]
        public void SequenceCalculator_Generate_Evens_Sequence_Correctly(int intNumber, int loadNumber, string expectedPartialResult)
        {
            // Act
            StringBuilder result = SequenceCalculator.GetEvensSequence(intNumber, loadNumber);
            Assert.IsTrue(result.ToString().Contains(expectedPartialResult));
        }

        [TestCase(10, 1, "1 2 C 4 E C 7 8 C E")]
        [TestCase(100, 1, "91 92 C 94 E C 97 98 C E")]
        [TestCase(1000, 1, "C 982 983 C E 986 C 988 989 Z 991 992 C 994 E C 997 998 C E")]
        public void SequenceCalculator_Generate_ZCE_Sequence_Correctly(int intNumber, int loadNumber, string expectedPartialResult)
        {
            // Act
            StringBuilder result = SequenceCalculator.GetZCESequence(intNumber, loadNumber);
            Assert.IsTrue(result.ToString().Contains(expectedPartialResult));
        }

        [TestCase(1000, "0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 ")]
        [TestCase(6765, "0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765")]
        [TestCase(10000, "0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765")]
        [TestCase(100000, "0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711 28657 46368 75025")]
        [TestCase(1000000, "0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711 28657 46368 75025 121393 196418 317811 514229 832040")]
        public void SequenceCalculator_Generate_Fibonacci_Sequence_Correctly(int intNumber, string expectedPartialResult)
        {
            // Act
            StringBuilder result = SequenceCalculator.GetFibonacci(intNumber);
            Assert.IsTrue(result.ToString().Contains(expectedPartialResult));
        }
    }
}
