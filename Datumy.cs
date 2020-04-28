using System;

namespace Cz.Nones
{
    public class Datumy
    {
        /// <summary>
        /// Ověří, zda-li na vstupu bylo zadáno validní datum
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeDatum(string vstup)
        {
            try
            {
                DateTime dt;
                DateTime.TryParse(vstup, out dt);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}