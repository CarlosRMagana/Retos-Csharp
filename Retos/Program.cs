using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Retos
{
    public class Program
    {
        static void Main(string[] args)
        {
            //fizzBuzz();
            //leetSpeak();
            //passwordGenerator();
            //fibonacciPrimoPar();

            //PracticeOne();
            //PracticeTwo();

            //reverseString();
            //repeatCharacter();
            //distanciaHamming();
            //countWords();
            //stringToNumber();

            //prueba();

            Console.ReadKey();
        }

        #region Reto 1

        /*
        * Escribe un programa que muestre por consola (con un print) los
        * números de 1 a 100 (ambos incluidos y con un salto de línea entre
        * cada impresión), sustituyendo los siguientes:
        * - Múltiplos de 3 por la palabra "fizz".
        * - Múltiplos de 5 por la palabra "buzz".
        * - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
        */
        static void fizzBuzz()
        {
            foreach(int number in Enumerable.Range(1, 100))
            {
                bool isMult3 = number % 3 == 0;
                bool isMult5 = number % 5 == 0;

                string result = isMult3 && isMult5 ? "fizzbuzz" :
                                  isMult3 ? "fizz" :
                                  isMult5 ? "buzz" :
                                  number.ToString();

                Console.WriteLine(result);
            }
        }
        #endregion

        #region Reto 2
        /*
         * Escribe un programa que reciba un texto y transforme lenguaje natural a
         * "lenguaje hacker" (conocido realmente como "leet" o "1337"). Este lenguaje
         *  se caracteriza por sustituir caracteres alfanuméricos.
         * - Utiliza esta tabla (https://www.gamehouse.com/blog/leet-speak-cheat-sheet/) 
         *   con el alfabeto y los números en "leet".
         *   (Usa la primera opción de cada transformación. Por ejemplo "4" para la "a")
         */

        public static void leetSpeak()
        {
            repeat:

            Console.Write("Convert string to leet alphabet: ");

            var input = Console.ReadLine();

            if (input == null || input == "")
            {
                Console.WriteLine("La cadena introducida no es correcta");
                goto repeat;
            }
            var leetAbc = new Dictionary<char, string>()
            {
                {'A', @"1"}, {'B', @"I3"}, {'C', @"["},
                {'D', @")"}, {'E', @"3"},
                {'F', @"|="},
                {'G', @"&"},
                {'H', @"#"},
                {'I', @"1"},
                {'J', @",_|"},
                {'K', @">|"},
                {'L', @"1"},
                {'M', @"/\\/\\"},
                {'N', @"^/"},
                {'O', @"0"},
                {'P', @"|*"},
                {'Q', @"(_,)"},
                {'R', @"I2"},
                {'S', @"5"},
                {'T', @"7"},
                {'U', @"(_)"},
                {'V', @"\\/"},
                {'W', @"\/\/"},
                {'X', @"><"},
                {'Y', @"j"},
                {'Z', @"2"},
                {'1', @"L"},
                {'2', @"R"},
                {'3', @"E"},
                {'4', @"A"},
                {'5', @"S"},
                {'6', @"b"},
                {'7', @"T"},
                {'8', @"B"},
                {'9', @"g"},
                {'0', @"o"},
                {' '," "}
            };

            Console.WriteLine(string.Join("", input.Select(letter => leetAbc[char.ToUpper(letter)])));
        }

        #endregion

        #region Reto 3

        /*
         * Escribe un programa que sea capaz de generar contraseñas de forma aleatoria.
         * Podrás configurar generar contraseñas con los siguientes parámetros:
         * - Longitud: Entre 8 y 16.
         * - Con o sin letras mayúsculas.
         * - Con o sin números.
         * - Con o sin símbolos.
         * (Pudiendo combinar todos estos parámetros entre ellos)
         */

        static void passwordGenerator()
        {
            repeat:

            Console.Write("¿Necesitas una contraseña? Y/N : ");
            string input = Console.ReadLine().ToLower();

            string characters = "abcdefghijklmnopqrstuvwxyz" + 
                                "0123456789" + 
                                "!@#$%^&*()=-_+`~[]{}|;:',<>?/\"\\" + 
                                "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder result = new StringBuilder();
            Random random= new Random();

            if (input == "y")
            {
                var passwordLength = new Random().Next(8, 16);

                for(int i = 0; i < passwordLength; i++)
                {
                    int index = random.Next(characters.Length);
                    result.Append(characters[index]);
                }

                Console.WriteLine($"> Tu contraseña: { result } de # { result.Length } caracteres. \n");

                goto repeat;
            }

            Console.WriteLine("Password generada.");
        }

        #endregion

        #region Reto 4

        /*
         * Escribe un programa que, dado un número, compruebe y muestre si es primo,
         * fibonacci y par.
         * Ejemplos:
         * - Con el número 2, nos dirá: "2 es primo, fibonacci y es par"
         * - Con el número 7, nos dirá: "7 es primo, no es fibonacci y es impar"
         */

        static void fibonacciPrimoPar()
        {
            var random = new Random();
            int input = Convert.ToInt32(random.Next(1, 100));

            string esFibonacci = numeroFibonacci(input) ? "es fibonacci" : "no es fibonacci";
            string esPrimo     = numeroPrimo(input) ? "es primo" : "no es primo";
            string esPar       = input % 2 == 0 ? "es par" : "no es par";

            Console.WriteLine($" # { input } { esPrimo }, { esFibonacci } y { esPar }.");

        }

        static bool numeroFibonacci(int input)
        {
            var fib = new List<int> { 0, 1 };
            while (fib.Last() < input)
            {
                var next = fib[fib.Count - 1] + fib[fib.Count - 2];
                fib.Add(next);
            }

            bool esfibonacci = fib.Contains(input);

            return esfibonacci;
        }

        static bool numeroPrimo(int input)
        {
            if (input < 2) return false;
            if (input == 2) return true;
            if (input % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(input); i += 2)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Test 1

        /*Take the following string "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert" and give each player a shirt number, starting from 1, to create a string of the form: "1. Davis, 2. Clyne, 3. Fonte" etc.*/

        static void PracticeOne()
        {
            /*string input = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            string output = "";

            string[] players = input.Trim().Split(',');

            for(int i = 0; i < players.Length; i++)
            {
                output += $"{i + 1}. {players[i]}, ";
            }*/


            //Answer

            var output = String.Join(", ", "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert"
            .Split(',')
            .Select((item, index) => index + 1 + "." + item)
            .ToArray());

            Console.WriteLine(output);
        }


        #endregion

        #region Test 2

        /*Take the following string "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988" and turn it into an IEnumerable of players in order of age(bonus to show the age in the output)*/

        static void PracticeTwo()
        {
            string players = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            var team = players.Split(';')
                              .Select(part => part.Split(','))
                              .Where(part => part.Length == 2)
                              .ToDictionary(split => split[0], split => Convert.ToDateTime(split[1]))
                              .OrderBy(kv => kv.Value);

            var RecentYear = DateTime.Today.Year;

            foreach (var player in team)
            {
                Console.WriteLine($"> Name: {player.Key}   Birthday: { player.Value.ToString("MM/dd/yyyy") }  Age: { RecentYear - player.Value.Year }");
            }
        }

        #endregion

        #region Test 3

        static void reverseString()
        {
            string input = "Texto normal de prueba.";

            var result = string.Join("", input.Reverse());    

            Console.WriteLine($"Original: {input}\nTexto invertido: {result}");
        }
        #endregion

        #region Test 4

        static void repeatCharacter()
        {
            string input = "HGNaodtfmIDJhE4zx5Eb1ZWepoS5HYNB9ntU4kS4KpgtBWGjk08setVskp7mmsMUJhEAyTAbJGTc0PuItshfZRBJCbc7Is0yQ9lCfafvbICoLXuk2iQiTi7kCR8vxrLzJ1boWxOUAxitOKHAJybiHYjXzlQZn4Yx3RHf97udD3jkHCmIjMvgMALK7NzcuqXbDJxEPeUzudHvIOPMr7NNmnAaglyJjrZUDnJcFMTvvDAjZH17filfrJXwXcbIax9CgJXAy6PMBsjSnAL8hFNeAcVoygCOufXc7wZbT4JmI0aR";

            char search = 'u';

            var output = input.ToLower()
                              .Where(letter => letter == search)
                              .Count();

            Console.WriteLine($"La letra \"{ search }\" se repite: { output } veces.");
        }
        #endregion

        #region Test 5

        static void distanciaHamming()
        {
            string opt1 = "10111011";
            string opt2 = "10010001";

            if (opt1.Length != opt2.Length)
                throw new Exception("Not similar length string.");

            var result = Enumerable.Range(0, opt1.Length)
                                   .Sum(i => opt1[i] == opt2[i]? 0: 1);

            Console.WriteLine($"La distancia es de: { result }");

        }

        #endregion

        #region Test 6

        static void countWords()
        {
            string text = "     Lorem     ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et     dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo      consequat. Duis aute          irure dolor in reprehenderit   in voluptate velit esse      cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.     ";

            var WordsInText = Regex.Replace(text, @"\s+", " ")
                                   .Trim()
                                   .Split(' ')
                                   .Count();

            Console.WriteLine(WordsInText);
        }

        #endregion

        #region Test 7

        static void stringToNumber()
        {
            string text = "1N#H4b*Y!PuivsUVKMyk2uu86xTK*QYE4RZ5ZZ%gb3ScujSmyW*FYyeXRlwGPAXJIG1drhi8WRtIni?xBtQRJaFNk?EWWz@v1YvIMiks23j7CAc5a%34USECaT4MTD*V66X2l7uZFqAg?Bz4XY#Ar3jkVZk312I%kuUqj3NsFGXl4Bv4JmXV*?IySH8FpS?bLPtoVA8qjZ5TMwZ";

            string restrict = @"[0-9]";

            var regex = new Regex(restrict);

            int result = regex.Matches(text).Count;

            Console.WriteLine($"Cantidad de digitos: { result }");
        }

        #endregion

        #region Pasantia
        static void prueba()
        {
            int[] items = { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 };

            /*var histogram = new Dictionary<int, int>();

            foreach (int item in items)
            {
                if (histogram.ContainsKey(item))
                {
                    histogram[item]++;
                }
                else
                {
                    histogram[item] = 1;
                }
            }

            foreach (KeyValuePair<int, int> pair in histogram)
            {
                Console.WriteLine($"{ pair.Key } { string.Concat(Enumerable.Repeat("*", pair.Value == 1 ? 0 : pair.Value)) }");
            }*/

            var histogram = items.GroupBy(item => item)                               
                                 .Select(number => new { Element = number.Key, Counter = number.Count() })
                                 .ToList();

            foreach(var element in histogram)
            {
                Console.WriteLine($"{element.Element} {string.Concat(Enumerable.Repeat("*", element.Counter == 1 ? 0 : element.Counter))}");
            }

        }
        #endregion
    }


}
