using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NumericSequenceCalculator.Models;

namespace NumericSequenceCalculator.Controllers
{
    public class HomeController : Controller
    {
        public int MAX_INPUT = 100000;
        public int MAX_INIT_LOAD_NUMBER = 1000000;

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Calculate()
        {
            HomeModel model = new HomeModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Calculate(HomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.Result = await GetAllSequences(model.InputNumber);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        private async Task<ResultModel> GetAllSequences(int inputNumber, int loadNumber = 1)
        {
            ResultModel model = new ResultModel();
            int startNumber = 1;
            int endNumber = inputNumber;

            if (inputNumber <= MAX_INPUT)
            {
                if (loadNumber > 1)
                    return model;
            }
            else
            {
                startNumber = (MAX_INPUT * (loadNumber - 1)) + 1;
                endNumber = (loadNumber) * MAX_INPUT;

                if (endNumber > inputNumber) endNumber = inputNumber;
            }

            StringBuilder str = new StringBuilder();
            StringBuilder strEvens = new StringBuilder();
            StringBuilder strOdds = new StringBuilder();
            StringBuilder strZCE = new StringBuilder();
            StringBuilder strFibo = new StringBuilder();

            for (int i = startNumber; i <= endNumber; i++)
            {
                str.Append(i + " ");

                if ((i % 2) != 1)
                {
                    strOdds.Append(i.ToString() + " ");
                }
                else
                {
                    strEvens.Append(i.ToString() + " ");
                }

                //SCE
                if (i % 3 == 0 && i % 5 == 0)
                    strZCE.Append("Z ");
                else if (i % 3 == 0)
                    strZCE.Append("C ");
                else if (i % 5 == 0)
                    strZCE.Append("E ");
                else
                    strZCE.Append(i.ToString() + " ");
            }

            strFibo = SequenceCalculator.GetFibonacciSequence(inputNumber);
            
            model.Sequence = SequenceModel(SequenceType.Normal, str, loadNumber, inputNumber);
            model.OddsSequence = SequenceModel(SequenceType.Odds, strOdds, loadNumber, inputNumber);
            model.EvensSequence = SequenceModel(SequenceType.Evens, strEvens, loadNumber, inputNumber);
            model.ZceSequence = SequenceModel(SequenceType.ZCE, strZCE, loadNumber, inputNumber);
            model.FibonacciSequence = SequenceModel(SequenceType.Fibonacci, strFibo, loadNumber, inputNumber);

            return model;
        }

        public async Task<ActionResult> Sequence(int inputNumber, int loadNumber)
        {
            StringBuilder str = SequenceCalculator.GetSequence(inputNumber, loadNumber);
            SequenceModel model = SequenceModel(SequenceType.Normal, str, loadNumber, inputNumber);
            return PartialView("_Result", model);
        }

        public async Task<ActionResult> OddsSequence(int inputNumber, int loadNumber)
        {
            StringBuilder str = SequenceCalculator.GetOddsSequence(inputNumber, loadNumber);
            SequenceModel model = SequenceModel(SequenceType.Odds, str, loadNumber, inputNumber);
            return PartialView("_Result", model);
        }

        public async Task<ActionResult> EvensSequence(int inputNumber, int loadNumber)
        {
            StringBuilder str = SequenceCalculator.GetEvensSequence(inputNumber, loadNumber);
            SequenceModel model = SequenceModel(SequenceType.Evens, str, loadNumber, inputNumber);
            return PartialView("_Result", model);
        }

        public async Task<ActionResult> ZCESequence(int inputNumber, int loadNumber)
        {
            StringBuilder str = SequenceCalculator.GetZCESequence(inputNumber, loadNumber);
            SequenceModel model = SequenceModel(SequenceType.ZCE, str, loadNumber, inputNumber);
            return PartialView("_Result", model);
        }

        public SequenceModel SequenceModel(SequenceType type, StringBuilder str, int loadNumber, int inputNumber)
        {
            SequenceModel model = new SequenceModel();
            
            if (str != null)
            {
                model.Str = str;
                model.NextSequenceUrl = NextSequenceUrl(type, loadNumber + 1, inputNumber);
                model.IsMoreResult = true;
            }
            else
            {
                model.IsMoreResult = false;
            }

            return model;
        }

        private string NextSequenceUrl(SequenceType type, int nextLoadNumber, int inputNumber)
        {
            string url = string.Empty;

            switch (type)
            {
                case SequenceType.Evens:
                    url = String.Format("/Home/EvensSequence/?loadNumber={0}&inputNumber={1}", nextLoadNumber, inputNumber);
                    break;
                case SequenceType.Odds:
                    url = String.Format("/Home/OddsSequence/?loadNumber={0}&inputNumber={1}", nextLoadNumber, inputNumber);
                    break;
                case SequenceType.ZCE:
                    url = String.Format("/Home/ZCESequence/?loadNumber={0}&inputNumber={1}", nextLoadNumber, inputNumber);
                    break;
                case SequenceType.Fibonacci:
                    url = "";
                    break;
                default:
                    url = String.Format("/Home/Sequence/?loadNumber={0}&inputNumber={1}", nextLoadNumber, inputNumber);
                    break;
            }
            return url;
        }

        public enum SequenceType
        {
            Normal,
            Evens,
            Odds,
            ZCE,
            Fibonacci
        }
    }
}