using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheDrawOfNumbersEasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var randomNumber = new Random();
            var index = 1;

            var theNumberDrawn = randomNumber.Next(0, 100);

            try
            {
                Console.WriteLine("Wylosowana została liczbę od 1 do 100, spróbuj ją odgadnąć:");

                var yourNumber = CheckInt(0, 100);

                while (yourNumber != theNumberDrawn)
                {
                    if (yourNumber < theNumberDrawn)
                    {
                        Console.WriteLine("Twoja liczba jest mniejsza. Podaj inną.!");
                    }
                    else
                    {
                        Console.WriteLine("Twoja liczba jest większa. Podaj inną.!");
                    }
                    index++;
                    yourNumber = CheckInt(0, 100);
                }
                Console.WriteLine($"Brawo ! Trafiłeś ! Wygrana.! za {index} razem. Koniec gry. Naciśnij Enter.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        private static int CheckInt(int minValues, int maxvalue)
        {
            var input = IsNotEmpty();

            var permissibleValuesForInputInt = "1234567890";

            foreach (var sign in input)
            {
                if (!permissibleValuesForInputInt.Contains(sign))
                {
                    throw new Exception("Wprowadzane dane muszą składać się wyłącznie z cyfr.! Naciśnij Enter.");
                }
            }

            if (!int.TryParse(input, out int inputInt))
            {
                throw new Exception("Podana wartość jest nieprawidłowa.! Naciśnij Enter.");
            }

            if (inputInt < minValues | inputInt > maxvalue)
            {
                throw new Exception($"Podano liczbę z poza zakresu: {minValues} - {maxvalue}.! Naciśnij Enter.");
            }
            return inputInt;
        }
        private static string IsNotEmpty()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Nie podano odpowiedzi.! Naciśnij Enter.");
            }
            return input;
        }
    }
}
