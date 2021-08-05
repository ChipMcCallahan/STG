using System.Collections.Generic;

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
        internal List<Input> Parse(string inputStr)
        {
            return new List<Input>();
        }
    }
}