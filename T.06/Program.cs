using System;
using System.Text;

namespace T._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                switch (letter)
                {
                    case 'A': sb.Append(".-"); break;
                    case 'B': sb.Append("-..."); break;
                    case 'C': sb.Append("-.-."); break;
                    case 'D': sb.Append("-.."); break;
                    case 'E': sb.Append("."); break;
                    case 'F': sb.Append("..-."); break;
                    case 'G': sb.Append("--."); break;
                    case 'H': sb.Append("...."); break;
                    case 'I': sb.Append(".."); break;
                    case 'J': sb.Append(".---"); break;
                    case 'K': sb.Append("-.-"); break;
                    case 'L': sb.Append(".-.."); break;
                    case 'M': sb.Append("--"); break;
                    case 'N': sb.Append("-."); break;
                    case 'O': sb.Append("--.-"); break;
                    case 'P': sb.Append(".--."); break;
                    case 'Q': sb.Append("--.-"); break;
                    case 'R': sb.Append(".-."); break;
                    case 'S': sb.Append("..."); break;
                    case 'T': sb.Append("-"); break;
                    case 'U': sb.Append("..--"); break;
                    case 'V': sb.Append("...-"); break;
                    case 'W': sb.Append(".--"); break;
                    case 'X': sb.Append("-.."); break;
                    case 'Y': sb.Append("-.--"); break;
                    case 'Z': sb.Append("--.."); break;
                    default: sb.Append("/"); break;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
