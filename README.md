# C# Coding Assesment
```
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
```
# Explanation of the Code:
### 1. Keypad Mapping:

  - The Keypad array maps each digit (0-9) to its corresponding letters. For example, 2 maps to "ABC", 3 maps to "DEF", and so on.

### 2. Processing the Input:

  The method processes the input string character by character.

  - If the character is #, it stops processing and returns the result.

  - If the character is *, it removes the last character from the result (backspace).

  - If the character is a space, it is treated as a pause and ignored.

  - If the character is a digit, it counts the number of consecutive presses and determines the corresponding letter based on the number of presses.

### 3. Handling Consecutive Presses:

- For consecutive presses of the same digit, the method calculates the corresponding letter by using the modulo operation (%) to cycle through the letters.

### 3. Edge Cases:

- The method handles edge cases such as multiple backspaces, long sequences of the same button, and invalid characters.

## 4. Test Cases:

  The Main method includes test cases to demonstrate the functionality of the OldPhonePad method.

  Example Outputs:

  `OldPhonePad("33#") returns "E"`

  `OldPhonePad("227*#") returns "B"`

  `OldPhonePad("4433555 555666#") returns "HELLO"`

  `OldPhonePad("8 88777444666*664#") returns "TURING"`

