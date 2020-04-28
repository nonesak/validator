using System;

namespace Cz.Nones
{
    public class Stringy
    {
        /// <summary>
        /// Vrátí ze vstupního stringu zadaný počet znaků zleva
        /// </summary>
        /// <param name="vstup"></param>
        /// <param name="delka"></param>
        /// <returns></returns>
        public static string Left(string vstup, int delka)
        {
            if (String.IsNullOrEmpty(vstup))
            {
                return "";
            }
            else if (vstup.Length < delka)
            {
                return vstup.Substring(0, vstup.Length);
            }
            else
            {
                return vstup.Substring(0, delka);
            }
        }

        /// <summary>
        /// Vrátí ze vstupního stringu zadaný počet znaků zprava
        /// </summary>
        /// <param name="vstup"></param>
        /// <param name="delka"></param>
        /// <returns></returns>
        public static string Right(string vstup, int delka)
        {
            if (String.IsNullOrEmpty(vstup))
            {
                return "";
            }
            else if (vstup.Length < delka)
            {
                return vstup.Substring(0, vstup.Length);
            }
            else
            {
                return vstup.Substring(vstup.Length - delka, delka);
            }
        }
    }
}
