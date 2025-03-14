using System;
using System.Text;

public class OldPhonePad
{
    private static string OldPhonePad(string input)
    {
        string[] Keypad = {
            "",     // 0
            "",     // 1
            "ABC",  // 2
            "DEF",  // 3
            "GHI",  // 4
            "JKL",  // 5
            "MNO",  // 6
            "PQRS", // 7
            "TUV",  // 8
            "WXYZ"  // 9
        };

        StringBuilder result = new StringBuilder();
        int n = input.Length;
        int i = 0;

        while (i < n)
        {
            char currentChar = input[i];

            if (currentChar == '#')
            {
                break;
            }
            else if (currentChar == '*')
            {
                if (result.Length > 0)
                {
                    result.Length--;
                }
                i++;
            }
            else if (currentChar == ' ')
            {
                i++;
            }
            else if (char.IsDigit(currentChar))
            {
                int digit = currentChar - '0';
                string letters = Keypad[digit];
                int pressCount = 0;

                while (i < n && input[i] == currentChar)
                {
                    pressCount++;
                    i++;
                }

                int letterIndex = (pressCount - 1) % letters.Length;
                result.Append(letters[letterIndex]);
            }
            else
            {
                i++;
            }
        }

        return result.ToString();
    }

    // Test cases
    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad("33#")); // Output: E
        Console.WriteLine(OldPhonePad("227*#")); // Output: B
        Console.WriteLine(OldPhonePad("4433555 555666#")); // Output: HELLO
        Console.WriteLine(OldPhonePad("8 88777444666*664#")); // Output: TURING
    }
}