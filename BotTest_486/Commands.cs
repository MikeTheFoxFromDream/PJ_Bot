using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTest_486
{
    class Commands
    {

        public static string Roll(string message)
        {
            string result = "";
            var rn = new Random();
            message = message.Replace("!roll ".ToLower(), "");
            string text = "";
            int numDice = 0;
            int numSide = 0;
            try
            {
                foreach (char i in message)
                {
                    if (i == 'd')
                        break;
                    else
                    {
                        text += i;
                    }   
                }

                numDice = int.Parse(text);
                if (numDice > 125)
                    return "Kámo tolik kostek tu nemám";
                text += 'd';
                message = message.Replace(text, "");
                text = "";


                foreach (char i in message)
                {
                    if (i == ' ')
                        break;
                    else
                    {
                        text += i;
                    }
                }

                numSide = int.Parse(text);
                if (numSide > 100)
                    return "Tak takový kostky mi neprodá ani Pepa, a to je co říct";

                while (numDice != 0)
                {
                    result += rn.Next(1, numSide + 1) + ", ";
                    numDice--;
                }

                result = result.Remove(result.Length - 2);
                return result;
            }
            catch
            {
                return("Co to meleš!");
            }
        }
    }
}
