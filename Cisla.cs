using System;

namespace Cz.Nones
{
    public class Cisla
    {
        /// <summary>
        /// Určí, zda zadané číslo je sudé
        /// </summary>
        /// <param name="cislo"></param>
        /// <returns></returns>
        public static bool JeSude(int cislo)
        {
            return cislo % 2 == 0;
        }

        /// <summary>
        /// Určí, zda zadané číslo je celé
        /// </summary>
        /// <param name="cislo"></param>
        /// <returns></returns>
        public static bool JeCele(double cislo)
        {
            double desCast = Math.Floor(cislo) - cislo;

            if (desCast == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Vypočte faktoriál z čísla do 20
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Faktorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Zadané číslo musí být kladné!");
            }
            if (n > 20)
            {
                throw new ArgumentException("Zadané číslo nesmí být větší než 20!");
            }
            long vysledek = 1;
            for (int x = 2; x <= n; x++)
            {
                vysledek *= x;
            }
            return vysledek;
        }

        /// <summary>
        /// Výpočte aritmetický průměr z čísel uložených v poli vstupních hodnot
        /// </summary>
        /// <param name="cisla"></param>
        /// <returns></returns>
        public static double AritmetickyPrumer(int[] cisla)
        {
            double hodnota = 0;
            foreach (int c in cisla)
            {
                hodnota += c;
            }
            hodnota /= cisla.Length;
            return hodnota;
        }

        /// <summary>
        /// Zjistí, zda-li zadané číslo je/není prvočíslem
        /// </summary>
        /// <param name="cislo"></param>
        /// <returns></returns>
        public static bool JePrvoCislo(int cislo)
        {
            if (cislo < 2) return false;
            if (cislo == 2) return true;
            if (cislo % 2 == 0) return false;
            
            int max = (int) Math.Sqrt(cislo);

            for (int i = 3; i <= max; i += 2)
            {
                if (cislo % i == 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}