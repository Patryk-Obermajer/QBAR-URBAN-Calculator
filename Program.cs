using System;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace URBAN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("eat shit");

            var Constant = 0.00108;
            var SAAR = 1071;
            var SOIL = 0.3;
            var AREA = 1;
            var URBAN = 0.75; 
            var ICPSudS = Constant * Math.Pow(0.5, 0.89) * Math.Pow(SAAR, 1.17) * Math.Pow(SOIL, 2.17) * AREA / 50;
            var IH124 = Constant * Math.Pow(AREA / 100, 0.89) * Math.Pow(SAAR, 1.17) * Math.Pow(SOIL, 2.17);
            double NC;
            double QBARrural;
            double QBARurban;

            if (AREA >= 50)
            {
                QBARrural = IH124;
            }
            else
            {
                QBARrural = ICPSudS;
            }
            Console.WriteLine("SAAR = " + SAAR.ToString() + "\n" + "SOIL = " + SOIL.ToString() + "\n" + "area = " + AREA.ToString());
            Console.WriteLine("QBARrural = " + Math.Round(QBARrural * 1000, 2).ToString() + " l/s");
            
            double CWI;
            double CWIforSAARbelow995 = -6.0380588E-48 * Math.Pow(SAAR, 16) + 2.02514675E-43 * Math.Pow(SAAR, 15) - 3.13271064E-39 * Math.Pow(SAAR, 14) + 2.96383534E-35 * Math.Pow(SAAR, 13) - 1.9174005E-31 * Math.Pow(SAAR, 12) + 8.98319358E-28 * Math.Pow(SAAR, 11) - 3.14882113E-24 * Math.Pow(SAAR, 10) + 8.41169641E-21 * Math.Pow(SAAR, 9) - 1.72807826E-17 * Math.Pow(SAAR, 8) + 2.73471462E-14 * Math.Pow(SAAR, 7) - 0.0000000000331672534 * Math.Pow(SAAR, 6) + 0.0000000304467281 * Math.Pow(SAAR, 5) - 0.0000206975641 * Math.Pow(SAAR, 4) + 0.0100531998 * Math.Pow(SAAR, 3) - 3.28498121 * Math.Pow(SAAR, 2) + 644.669275 * Math.Pow(SAAR, 1) - 57196.4723;
            double CWIforSAARabove995 = -2.64371417E-19 * Math.Pow(SAAR, 6) + 3.92517715E-15 * Math.Pow(SAAR, 5) - 0.000000000023862192 * Math.Pow(SAAR, 4) + 0.0000000756830579 * Math.Pow(SAAR, 3) - 0.000131392881 * Math.Pow(SAAR, 2) + 0.120063871 * Math.Pow(SAAR, 1) + 78.1999461;
            if (SAAR <= 995)
            {
                CWI = CWIforSAARbelow995;
            }
            else
            {
                CWI = CWIforSAARabove995;
            }

            if (SAAR <= 1100)
            {
                NC = 0.92 - 0.00024 * SAAR;
            }
            else
            {
                NC = 0.74 - 0.000082 * SAAR;
            }

            double CIND = 102.4 * SOIL + 0.28 * (CWI - 125);

            Console.WriteLine(CWI.ToString());
            Console.WriteLine(CIND.ToString());

            QBARurban = Math.Pow((1+URBAN),(2*NC)) * (1+URBAN*((21/CIND)-0.3))*QBARrural*1000;

            Console.WriteLine("QBARurban = " + QBARurban.ToString());


        }
    }
}
