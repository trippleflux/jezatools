using System;

namespace Library
{
    public class tbLibrary
    {
        #region enum

        public enum Tasks
        {
            BuildResources = 1,
            BuildResourcesNoCrop = 2,
            WoodLand = 3,
            ClayPit = 4,
            IronMine = 5,
            CropLand = 6,
            BuildingId = 7
        }

        public enum Priority
        {
            VeryHigh = 5,
            High = 4,
            Medium = 3,
            Low = 2,
            VeryLow = 1,
        }

        #endregion

        /// <summary>
        /// Return only numbers from string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Parsed string</returns>
        /// 
        public static string GetOnlyNumbers(string input)
        {
            String a = "";
            for (int c = 0; c < input.Length; c++)
            {
                if (IsNumber(input[c]))
                {
                    a += input[c];
                }
            }

            return a;
        }

        /// <summary>
        /// Checks if specified character is number.
        /// </summary>
        /// <param name="c"><see cref="char"/></param>
        /// <returns><c>true</c> if character is number</returns>
        /// 
        private static bool IsNumber(char c)
        {
            return char.IsNumber(c);
        }
    }
}