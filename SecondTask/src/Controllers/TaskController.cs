using Microsoft.AspNetCore.Mvc;

namespace src.Controllers{
    [ApiController]
    [Route("/")]
    public class TaskController : ControllerBase{
        private class Entity{
            public int Number {get; set;}
            public  bool Is_prime{get; set;}
            public  bool Is_perfect{get; set;}
            public List<string> Properties{get; set;} = new List<string>();
            public int Digit_sum {get; set;}
            public string Fun_fact{get; set;} = string.Empty;
        }

        private class BadResponse{
            public string Number{get; set;} = string.Empty;
            public bool Error{get; set;} = true;
        }

        [HttpGet]
        public ActionResult Bing()
        {
            return Ok("Api is active!!!");
        }

        [HttpGet("api/classify-number")]
        public ActionResult ClassifyNumber([FromQuery] string number)
        {
            var isValiidNumber = int.TryParse(number, out int parsedValue);
            if(isValiidNumber == false) 
            {
                return StatusCode(
                    400, 

                    new BadResponse(){
                    Number = "alphabet",
                    Error = true
                });
            }

            try{
                var baseUrl = "http://numbersapi.com";
                var client  = new HttpClient();

                var clientResponse = client.GetAsync($"{baseUrl}/{number}/math").Result;
                var clientResult = clientResponse.Content.ReadAsStringAsync().Result;

                var response = Operations(parsedValue);
                response.Fun_fact = clientResult;

                return Ok(response);

            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }          
        } 

        private Entity Operations(int number)
        { 
            var _isPrime = IsPrime(number);
            var _isPerfect = Isperfect(number);
            var _isEven = IsEven(number);
            var _isOdd = IsOdd(number);
            var _digitSum = SumOfEach(number);
            var _isArmstrong = IsArmstrong(number);

            List<string> items = new();

            if(_isArmstrong)
            {
                items.Add("armstrong");
            }
            if(_isOdd)
            {
                items.Add("odd");
            }else
            {
                items.Add("even");
            }

            Entity entity = new(){
                Number = number,
                Is_prime = _isPrime,
                Is_perfect = _isPerfect,
                Properties = items,
                Digit_sum = _digitSum
            };

            return entity;
        }

        private int SumOfEach(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        private bool Isperfect(int number)
        {
            int sum = 1;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum == number && number != 1;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;            
        }

        private bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private bool IsArmstrong(int number)
        {
            int sum = 0;
            int power = number.ToString().Length;
            int assigned = number;
            while (assigned != 0)
            {
                int currentNumber = assigned % 10;
                sum += (int)Math.Pow(currentNumber, power);
                assigned /= 10;
            }

            return sum == number;
        }

    }
}