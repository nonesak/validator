using System;

namespace Cz.Nones
{
    public class ValidaceVstupu
    {
        /// <summary>
        /// Metoda ověřuje, zda-li vložený znak je číslo
        /// </summary>
        /// <param name="znak"></param>
        /// <returns></returns>
        private static bool JeZnakCislo(char znak)
        {
            return (znak >= '0' && znak <= '9');
        }

        /// <summary>
        /// Test, zda-li znak je písmeno bez diakritiky
        /// </summary>
        /// <param name="znak"></param>
        /// <returns></returns>
        private static bool JeZnakPismenoBD(char znak)
        {
            return ((znak >= 'a' && znak <= 'z') ||
                    (znak >= 'A' && znak <= 'Z'));
        }

        /// <summary>
        /// Test, zda-li znak je písmeno s diakritikou
        /// </summary>
        /// <param name="znak"></param>
        /// <returns></returns>
        private static bool JeZnakPismenoSD(char znak)
        {
            string sDiakritikou = "áčďéěíňóřšťúůýžÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ";

            return (sDiakritikou.IndexOf(znak) > -1);
        }

        /// <summary>
        /// Test, zda-li znak je speciální znak
        /// </summary>
        /// <param name="znak"></param>
        /// <param name="seznamZnaku"></param>
        /// <returns></returns>
        private static bool JeZnakZeSeznamu(char znak)
        {
            string specialZnak = "+-*/";

            return (specialZnak.IndexOf(znak) > -1);
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec obsahuje pouze číslice
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeCislo(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            bool vyhodnoceni = false;

            foreach (char aktZnak in vstup)
            {
                vyhodnoceni = JeZnakCislo(aktZnak);

                if (vyhodnoceni == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec obsahuje pouze písmena bez diakritiky
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JePismenoBD(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            bool vyhodnoceni = false;

            foreach (char aktZnak in vstup)
            {
                vyhodnoceni = JeZnakPismenoBD(aktZnak);

                if (vyhodnoceni == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec obsahuje pouze písmena s diakritikou
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JePismenoSD(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            bool vyhodnoceni = false;

            foreach (char aktZnak in vstup)
            {
                vyhodnoceni = JeZnakPismenoSD(aktZnak);

                if (vyhodnoceni == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec obsahuje pouze písmena 
        /// ze speciálního seznamu (+-*/)
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeZeSeznamu(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            bool vyhodnoceni = false;

            foreach (char aktZnak in vstup)
            {
                vyhodnoceni = JeZnakZeSeznamu(aktZnak);

                if (vyhodnoceni == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ověří, zda-li na vstupu je zadáno platné rodné číslo
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeRodneCislo(string vstup)
        {
            // 0. ošetření null nebo prázdného vstupu
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            // 1. z RČ odstraním případné lomítko
            vstup = vstup.Replace("/","");

            // 2. RČ obsahuje pouze číslice
            if (!JeCislo(vstup))
            {
                return false;
            }

            // 3. Délka RČ je 9 nebo 10 znaků
            if (!(vstup.Length == 9 || vstup.Length == 10))
            {
                return false;
            }

            // 4. RČ je rozloženo na ROK, MĚSÍC, DEN a KONCOVKU dle masky RRMMDDKKK(K)
            string rr = Stringy.Left(vstup, 2);
            string mm = vstup.Substring(2, 2);
            string dd = vstup.Substring(4, 2);
            string kk = (vstup.Length == 9) ? Stringy.Right(vstup, 3) : Stringy.Right(vstup, 4);

            // 5. Nulová koncovka u devítimístných RČ je nepřípustná (např. 400223/000)
            if (vstup.Length == 9 && Stringy.Right(vstup,3) == "000")
            {
                return false;
            }

            // 6. Kontrola roku, měsíce, dne
            // 6.1 Rok musí být v rozsahu 0 - 99
            if (!(Convert.ToInt16(rr) >= 0 && Convert.ToInt16(rr) <= 99))
            {
                return false;
            }
            
            // Určení skutečného roku narození
            string rrrr = "";

            if (kk.Length == 3)
            {
                if (Convert.ToInt16(rr) > 53 )
                {
                    rrrr = "18" + rr;
                }
                else
                {
                    rrrr = "19" + rr;
                }
            }

            if (kk.Length == 4)
            {
                if (Convert.ToInt16(rr) > 53)
                {
                    rrrr = "19" + rr;
                }
                else
                {
                    rrrr = "20" + rr;
                }
            }
            
            // 6.2 Měsíc musí být v rozsahu 1 - 12
            int mesic = Convert.ToInt16(mm);
            
            if (mesic > 70)
            {
                mesic -= 70;
            }

            if (mesic > 50)
            {
                mesic -= 50;
            }

            if (mesic > 20)
            {
                mesic -= 20;
            }

            if (!(mesic > 0 && mesic <=12))
            {
                return false;
            }

            mm = Stringy.Right("00" + mesic.ToString(), 2);

            // 6.3 Počet dnů musí být ve správném rozsahu dle měsíce
            int den = Convert.ToInt16(dd);

            if ((mesic == 1 || mesic == 3 || mesic == 5 || mesic == 7 ||
                mesic == 8 || mesic == 10 || mesic == 12) &&
                (den > 31))
            {
                return false;
            }

            if ((mesic == 4 || mesic == 6 || mesic == 9 || mesic == 11) &&
                (den > 30))
            {
                return false;
            }

            if (mesic == 2 && DateTime.IsLeapYear(Convert.ToInt32(rrrr)) && den > 29)
            {
                return false;
            }

            if (mesic == 2 && !DateTime.IsLeapYear(Convert.ToInt32(rrrr)) && den > 28)
            {
                return false;
            }

            // 6.4 Ověření formátu data
            if (!Datumy.JeDatum(dd + "." + mm + "." + rrrr))
            {
                return false;
            }

            // 7. Pokud je RČ 10-ti místné, musí být beze zbytku dělitelné 11 (modulo 11)
            if (kk.Length == 4 && Convert.ToInt64(vstup) % 11 != 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ověří, zda-li na vstupu je zadáno platné IČ
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeIC(string vstup)
        {
            // 0. ošetření null nebo prázdného vstupu
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            int m = 0;

            if (vstup.Length != 8)
            {
                return false;
            }

            for (int i = 0; i < vstup.Length - 1; i++)
            {
                int c = Convert.ToInt32(vstup[i].ToString());
                m += c * (8 - i);
            }

            int zbytek = m % 11;
            int poslCislo = Convert.ToInt32(vstup[7].ToString());

            if ((zbytek == 0 || zbytek == 10) && poslCislo == 1)
            {
                return true;
            }
            if (zbytek == 1 && poslCislo == 0)
            {
                return true;
            }
            if (poslCislo == 11 - zbytek)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ověří, zda-li na vstupu je zadáno platné spojovací číslo SIPO
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeSIPO(string vstup)
        {
            // 0. ošetření null nebo prázdného vstupu
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            // 1. Spojovací číslo SIPO obsahuje pouze číslice
            if (!JeCislo(vstup))
            {
                return false;
            }

            // 2. Délka spojovacího čísla SIPO je 10 znaků
            if (!(vstup.Length == 10))
            {
                return false;
            }

            // 3. Výpočet
            int[] pole = new int[vstup.Length];

            for (int i = 0; i < vstup.Length; i++)
            {
                pole[i] = Convert.ToInt16(vstup.Substring(i, 1));
            }

            int m = (3 * pole[0]) +
                    (7 * pole[1]) +
                    (3 * pole[2]) +
                    (1 * pole[3]) +
                    (7 * pole[4]) +
                    (3 * pole[5]) +
                    (1 * pole[6]) +
                    (7 * pole[7]) +
                    (3 * pole[8]);

            int pcv = Convert.ToInt16(Stringy.Right(m.ToString(), 1));
            int kontrcis;

            if (pcv == 0)
            {
                kontrcis = 0;
            }
            else
            {
                kontrcis = 10 - pcv;
            }

            if (kontrcis == pole[9])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ověří, zda-li na vstupu je zadáno platné číslo bankovního účtu
        /// včetně předčíslí, pokud je zadáno
        /// </summary>
        /// <param name="predcisli"></param>
        /// <param name="cislouctu"></param>
        /// <returns></returns>
        public static bool JeBankUcet(string predcisli, string cislouctu)
        {
            // 0. ošetření null nebo prázdného vstupu
            if (predcisli == null || cislouctu == null || cislouctu.Trim().Length == 0)
            {
                return false;
            }

            // 1. číslo účtu obsahuje pouze číslice
            // předčíslí účtu (pokud je zadáno), obsahuje pouze číslice
            if (!JeCislo(cislouctu))
            {
                return false;
            }

            if (predcisli.Trim().Length > 0 && !JeCislo(predcisli))
            {
                return false;
            }

            // 2. délka čísla účtu je max. 10 znaků
            // délka předčíslí účtu (pokud je zadáno) je max. 6 znaků
            if (cislouctu.Length > 10)
            {
                return false;
            }

            if (predcisli.Trim().Length > 0 && predcisli.Length > 6)
            {
                return false;
            }

            // 3. Výpočet
            int[] polecislouctu = new int[10];
            
            cislouctu = Stringy.Right("0000000000" + cislouctu, 10);

            for (int i = 0; i < 10; i++)
            {
                polecislouctu[i] = Convert.ToInt16(cislouctu.Substring(i, 1));
            }

            int m = (6 * polecislouctu[0]) +
                    (3 * polecislouctu[1]) +
                    (7 * polecislouctu[2]) +
                    (9 * polecislouctu[3]) +
                    (10 * polecislouctu[4]) +
                    (5 * polecislouctu[5]) +
                    (8 * polecislouctu[6]) +
                    (4 * polecislouctu[7]) +
                    (2 * polecislouctu[8]) +
                    (1 * polecislouctu[9]);

            if (m % 11 != 0)
            {
                return false;
            }

            if (predcisli.Trim().Length > 0)
            {
                int[] polepredcisli = new int[6];

                predcisli = Stringy.Right("000000" + predcisli, 6);

                for (int i = 0; i < 6; i++)
                {
                    polepredcisli[i] = Convert.ToInt16(predcisli.Substring(i, 1));
                }

                int n = (10 * polepredcisli[0]) +
                        (5 * polepredcisli[1]) +
                        (8 * polepredcisli[2]) +
                        (4 * polepredcisli[3]) +
                        (2 * polepredcisli[4]) +
                        (1 * polepredcisli[5]);

                if (n % 11 != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec je IPv4 adresa v korektním formátu
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeIPv4Adresa(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            System.Text.RegularExpressions.Regex regexIP = new System.Text.RegularExpressions.Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");

            if (regexIP.Match(vstup).Success)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec je IPv4/IPv6 adresa v korektním formátu
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeIPAdresa(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            System.Net.IPAddress address;

            if (System.Net.IPAddress.TryParse(vstup, out address))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Test, zda-li vstupní řetězec je MAC adresa v korektním formátu
        /// </summary>
        /// <param name="vstup"></param>
        /// <returns></returns>
        public static bool JeMACAdresa(string vstup)
        {
            if (vstup == null || vstup.Trim().Length == 0)
            {
                return false;
            }

            System.Text.RegularExpressions.Regex regexMAC1 = new System.Text.RegularExpressions.Regex(@"^([0-9A-Fa-f]{2}[:-]){5}[0-9A-Fa-f]{2}$");
            System.Text.RegularExpressions.Regex regexMAC = new System.Text.RegularExpressions.Regex(@"^[0-9A-Fa-f]{12}|([0-9A-Fa-f]{2}-){5}[0-9A-Fa-f]{2}|([0-9A-Fa-f]{2}:){5}[0-9A-Fa-f]{2}$");

            //^ - begin of the string
            //[0-9A-Fa-f] - any hexadecimal digit
            //{2} - repeating 2 times
            //[:-] - : or -
            //{5} - repeating 5 times
            //[0-9A-Fa-f]{2} - 2 hexadecimal digits
            //$ - end of the string


            if (regexMAC.Match(vstup).Success)
            {
                return true;
            }

            return false;
        }
    }
}