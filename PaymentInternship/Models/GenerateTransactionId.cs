using System.Text;

namespace PaymentInternship.Models
{
    public class GenerateTransactionId
    {
        public string TransactionId { get; set; }
        public GenerateTransactionId()
        {
            TransactionId = getRandomid();
        }
        private string getRandomid()
        {
            int length = 10;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            string result = "";

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
                result = str_build.ToString();

            }
            return result.ToLower();

        }
    }
   
}
