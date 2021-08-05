using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Refactor for readability.
namespace STG
{
    public class InputStringParser
    {
        /// <summary>
        /// Converts a properly formatted string into a series of inputs.
        /// </summary>
        /// <param name="inputStr">
        /// An input string in a parseable format.
        /// Directions are "NESW" or "UDLR".
        /// Actions are "XYZ".
        /// Durations are integers representing number of ticks.
        /// Combinations are enclosed in curly brackets {}.
        /// No action is "-"
        /// Example string: "U-L2D3-R4-{ULX2}{UL3}"
        /// </param>
        /// <returns>
        /// A list containing the parsed inputs.
        /// </returns>
        public List<Input> Parse(string inputStr)
        {
            Dictionary<char, Direction> charToDir = new Dictionary<char, Direction>()
            {
                {'U', Direction.N},
                {'N', Direction.N},
                {'R', Direction.E},
                {'E', Direction.E},
                {'D', Direction.S},
                {'S', Direction.S},
                {'L', Direction.W},
                {'W', Direction.W},
            };

            List<Input> parsed = new List<Input>();
            int i = 0;
            while(i < inputStr.Length)
            {
                string thisInput;
                char startChar = inputStr[i];
                int startIndex = i;
                if (startChar == '{')
                {
                    while (i + 1 < inputStr.Length && inputStr[i + 1] != '}')
                    {
                        i++;
                    }
                    thisInput = inputStr.Substring(startIndex + 1, i - startIndex);
                    i++; // trailing '}'
                } else
                {
                    while (i + 1 < inputStr.Length && Char.IsNumber(inputStr[i + 1]))
                    {
                        i++;
                    }
                    thisInput = inputStr.Substring(startIndex, i + 1 - startIndex);
                }

                int lettersEnd = thisInput.Length - 1;
                while(lettersEnd > 0 && Char.IsNumber(thisInput[lettersEnd]))
                {
                    lettersEnd--;
                }
                int repeat = 1;
                if (lettersEnd < thisInput.Length - 1) {
                    repeat = Int32.Parse(thisInput.Substring(lettersEnd + 1));
                }
                for (int j = 0; j < repeat; j++)
                {
                    Input input = new Input();
                    foreach (char letter in thisInput.ToUpper().Substring(0, lettersEnd + 1))
                    {
                        if (charToDir.ContainsKey(letter))
                        {
                            if (input.Primary == Direction.Undefined)
                            {
                                input.Primary = charToDir[letter];
                            }
                            else
                            {
                                input.Secondary = charToDir[letter];
                            }
                        }
                        else if ("XYZ".Contains(letter))
                        {
                            input.Action = "XYZ".IndexOf(letter) + 1;
                        }
                        else if (letter != '-')
                        {
                            throw new ArgumentException(String.Format("Char {0} is invalid for input parsing.", letter));
                        }
                    }
                    parsed.Add(input);
                }
                i++;
            }
            return parsed;
        }
    }
}