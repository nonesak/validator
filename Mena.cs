using System;

namespace Cz.Nones
{
    public class Mena
    {
        /// <summary>
        /// Zaokrouhlí zadané desetinné číslo na
        /// padesátihaléř dle měnových pravidel
        /// </summary>
        /// <param name="cena"></param>
        /// <returns></returns>
        public static double ZaokrouhliCenu(double cena)
        {
            double desCast = cena - Math.Floor(cena);

            if (desCast < 0.25f)
            {
                return Math.Floor(cena);
            }
            if (desCast < 0.75f)
            {
                return Math.Floor(cena) + 0.5f;
            }
            return (float)Math.Round(cena);
        }
    }
}