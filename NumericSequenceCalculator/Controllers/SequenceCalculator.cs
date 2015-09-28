using System.Numerics;
using System.Text;

namespace NumericSequenceCalculator.Controllers
{
    public static class SequenceCalculator
    {
        public static int MAX_INPUT = 100000;
        public static int MAX_INIT_LOAD_NUMBER = 1000000;

        public static StringBuilder GetFibonacci(int endNumber)
        {
            StringBuilder strFibo = new StringBuilder();

            BigInteger previousprevious = 1;
            BigInteger previous = 1;
            BigInteger currentfibo = 2;

            strFibo.Append("0 1 1 ");

            while (currentfibo <= endNumber)
            {
                strFibo.Append(currentfibo + " ");

                previousprevious = previous;
                previous = currentfibo;

                //get next fibo
                currentfibo = previousprevious + previous;
            }
            return strFibo;
        }

        private static void GetStartAndEndNumber(int inputNumber, int loadNumber, out int startNumber, out int endNumber)
        {
            startNumber = 1;
            endNumber = inputNumber;

            if (inputNumber <= MAX_INPUT)
            {
                if (loadNumber > 1)
                {
                    startNumber = 0;
                    endNumber = 0;
                }
            }
            else
            {
                startNumber = (MAX_INPUT * (loadNumber - 1)) + 1;
                endNumber = (loadNumber) * MAX_INPUT;

                if (endNumber > inputNumber) endNumber = inputNumber;
                if (startNumber > endNumber)
                {
                    startNumber = 0;
                    endNumber = 0;
                }
            }
        }

        public static StringBuilder GetSequence(int inputNumber, int loadNumber)
        {
            //input is 10,000,000 & load is 1 -> 1 - 1000000
            //input is 10,000,000 & load is 2 -> 1000001 - 2000000
            //input is 10,000,000 & load is 3 -> 2000001 - 3000000
            //input is 10,000,000 & load is 5 -> 5000001 - 6000000
            //input 100,0

            int startNumber = 1;
            int endNumber = inputNumber;

            GetStartAndEndNumber(inputNumber, loadNumber, out startNumber, out endNumber);

            if (startNumber == 0 && endNumber == 0) return null;
            //if (inputNumber <= MAX_INPUT)
            //{
            //    if (loadNumber > 1)
            //        return null;
            //}
            //else
            //{
            //    startNumber = (MAX_INPUT * (loadNumber - 1)) + 1;
            //    endNumber = (loadNumber) * MAX_INPUT;

            //    if (endNumber > inputNumber) endNumber = inputNumber;
            //    if (startNumber > endNumber) return null;
            //}

            StringBuilder str = new StringBuilder();

            for (int i = startNumber; i <= endNumber; i++)
            {
                str.Append(i + " ");
            }

            return str;
        }

        public static StringBuilder GetOddsSequence(int inputNumber, int loadNumber)
        {
            int startNumber = 1;
            int endNumber = inputNumber;

            GetStartAndEndNumber(inputNumber, loadNumber, out startNumber, out endNumber);

            if (startNumber == 0 && endNumber == 0) return null;

            StringBuilder strOdds = new StringBuilder();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if ((i % 2) != 1)
                {
                    strOdds.Append(i.ToString() + " ");
                }
            }

            return strOdds;
        }

        public static StringBuilder GetEvensSequence(int inputNumber, int loadNumber)
        {
            int startNumber = 1;
            int endNumber = inputNumber;

            GetStartAndEndNumber(inputNumber, loadNumber, out startNumber, out endNumber);

            if (startNumber == 0 && endNumber == 0) return null;

            StringBuilder strEvens = new StringBuilder();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if ((i % 2) != 0)
                {
                    strEvens.Append(i.ToString() + " ");
                }
            }

            return strEvens;
        }

        public static StringBuilder GetZCESequence(int inputNumber, int loadNumber)
        {
            int startNumber = 1;
            int endNumber = inputNumber;

            GetStartAndEndNumber(inputNumber, loadNumber, out startNumber, out endNumber);

            if (startNumber == 0 && endNumber == 0) return null;

            StringBuilder strZCE = new StringBuilder();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    strZCE.Append("Z ");
                else if (i % 3 == 0)
                    strZCE.Append("C ");
                else if (i % 5 == 0)
                    strZCE.Append("E ");
                else
                    strZCE.Append(i.ToString() + " ");
            }

            return strZCE;
        }

        public static StringBuilder GetFibonacciSequence(int inputNumber)
        {
            StringBuilder strFibo = new StringBuilder();
            BigInteger previousprevious = 1;
            BigInteger previous = 1;
            BigInteger currentfibo = 2;

            strFibo.Append("0 1 1 ");

            while (currentfibo <= inputNumber)
            {
                strFibo.Append(currentfibo + " ");

                previousprevious = previous;
                previous = currentfibo;

                //get next fibo
                currentfibo = previousprevious + previous;
            }
            return strFibo;
        }
    }
}