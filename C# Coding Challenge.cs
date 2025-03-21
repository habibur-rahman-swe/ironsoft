using System;
using System.Text;

public class OldPhonePad
{
    // Define the keypad mapping for digits to their corresponding letters
    private static readonly string[] Keypad = {
        "",     // 0 (not used)
        "",     // 1 (not used)
        "ABC",  // 2
        "DEF",  // 3
        "GHI",  // 4
        "JKL",  // 5
        "MNO",  // 6
        "PQRS", // 7
        "TUV",  // 8
        "WXYZ"  // 9
    };

    /// <summary>
    /// Converts a sequence of digits (with optional spaces and '*') into text using the old phone pad mapping.
    /// The input is terminated by a '#' character.
    /// </summary>
    /// <param name="input">The input string containing digits, spaces, '*', and '#'.</param>
    /// <returns>The converted text.</returns>
    /// <exception cref="ArgumentException">Thrown if the input is invalid (e.g., contains unsupported characters).</exception>
    public static string ConvertToText(string input)
    {
        // Check for null or empty input
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty.");
        }

        // StringBuilder to store the result
        StringBuilder result = new StringBuilder();

        // The length of the given input
        int n = input.Length;

        // Starting Index
        int i = 0;

        // Iterate through the input string from the starting index i = 0 to end n - 1
        while (i < n)
        {
            // character at index i
            char currentChar = input[i];

            // If the current character is '#', stop processing
            if (currentChar == '#')
            {
                break;
            }
            // If the current character is '*', handle backspace
            else if (currentChar == '*')
            {
                if (result.Length > 0)
                {
                    result.Length--; // Remove the last character
                }
                i++; // Move to the next character
            }
            // If the current character is a space, skip it
            else if (currentChar == ' ')
            {
                i++;
            }
            // If the current character is a digit, process it
            else if (char.IsDigit(currentChar))
            {
                int digit = currentChar - '0'; // Convert char to int (e.g., '2' -> 2)

                // Validate the digit (must be between 0 and 9 and have a corresponding keypad entry)
                if (digit < 0 || digit >= Keypad.Length || string.IsNullOrEmpty(Keypad[digit]))
                {
                    throw new ArgumentException($"Invalid digit '{currentChar}' in input.");
                }

                // Get the letters corresponding to the digit
                string letters = Keypad[digit];
                int pressCount = 0;

                // Count the number of consecutive presses of the same digit
                while (i < n && input[i] == currentChar)
                {
                    pressCount++;
                    i++;
                }

                // Calculate the index of the letter to append (handles wrap-around for multiple presses)
                int letterIndex = (pressCount - 1) % letters.Length;
                result.Append(letters[letterIndex]);
            }
            // If the current character is invalid, throw an exception
            else
            {
                throw new ArgumentException($"Invalid character '{currentChar}' in input.");
            }
        }

        // Return the final result
        return result.ToString();
    }
}