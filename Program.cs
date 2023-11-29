namespace boole_alg
{
    class Program
    {
        public static void Main()
        {
            string[] gateInput = Console.ReadLine().Split(' '); // elso sor (logikai kapu es parameterek) beolvasasa szokozzel szeparalva egy string tombbe

            List<string[]> vars = new List<string[]>(); // string tomboket tartalmazo lista letrehozasa (ures a lista)

            int read = 0; // beolvasott sorok szamlalasa (ha az elso sorban megadott parameterek szamaval megegyezik a while alatta megall)
            
            while(read != gateInput.Length-1) // addig ciklus amig a read ereteke nem egyenlo a megadott parameterek szamaval (gateInput.Length-1 azert -1 mert az elso sorban az elso adat a logikai kapu es csak utana kovetkeznek a parameterek)
            {
            
                string input = Console.ReadLine(); // sor beolvasasa a konzolrol
                
                    if (input != null) // ha a beolvasott sor nem ures
                    {
                        string[] inputData = new string[(input.Length - 2) / 2]; // uj string tomb letrehozasa (a merete a sorban szereplo karakterek -2 / 2-vel azert -2 mert az elso ket karakter nem kell, mivel az lesz az azonosito betu illetve egy szokoz es azert /2 mert egy szampar lesz egy logikai ertek (1 vagy 0 vagy E))

                        string op = input.Substring(0, 1); // az elso karaktert elmentjuk (Substring(start, lenght))

                        for (int k = 1; k < gateInput.Length; k++) // megnezzuk hogy 7. sorban megadott parameterek kozul valamelyikkel egyezik-e a most megadott karater
                        {
                            if (op == gateInput[k]) // ha talalunk egyezest 
                            {
                                for (int i = 0; i < inputData.Length; i++) // a megadott adatokra (C 0205...) for loopban vegigfutunk
                                {
                                    int startIndex = 2 + (i) * 2; // a kezdo index a 2 + i * 2 lesz mivel az elso ket karakter nem szukseges (C ) illetve onnan kettesevel szeretnenk haladni
                                    if (startIndex < input.Length) // ha meg van karater az startIndex utan
                                    {

                                        string tmp = input.Substring(startIndex, 1)+","+input.Substring(startIndex + 1, 1); // a ket egymast koveto karatert a startIndex utan egy vesszovel osszefuzzuk
                                        double level = double.Parse(tmp); // es a vesszovel osszefuzott stringet double-be konvertáljuk
                                        string rel; // 

                                        if (level <= 0.8 && level >= 0) // ha a kapott double kielegiti a felteteleket
                                        {
                                            rel = "0"; // akkor o logikai 0 lesz 
                                        }
                                        else if(level <= 5 && level >= 2.7) // ha a kapott double kielegiti a felteteleket
                                        {
                                            rel = "1"; // akkor o logikai 1 lesz
                                        }
                                        else
                                        {
                                            rel = "E"; // akkor o ervenytelen lesz
                                        }
                                
                                        inputData[i] = rel; // a kapott erteket elmenjuk a korabban (20. sor) letrehozott tombben
                                    }
                                }
            
                                vars.Add(inputData); // a kesz tombot hozzaadjuk a listankhoz
                                read++; // mivel beolvastunk egy szukseges parametert ezert read++
                            }

                        }
                    }
                
            }

            string report = GetOutput(vars, gateInput); // stringben eltaroljuk a function visszateresi erteket
        
            Console.WriteLine(report); // kiirjuk a konzolra a stringet
        
        }

        private static string GetOutput(List<string[]> vars, string[] gateInput) // List<string[]> parameterek és string[] az elso bemeneti sor adatai
        {
            var res = ""; // letrehozzuk a kesobb visszaadando stringet

            string gate = gateInput[0]; // a kert logikai kapu

            switch (gate) // switch a kerdeses kapuhoz
            {
                case "AND":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == vars[1][i] && vars[0][i] == "1") // ha a lista egyik tombjenek az i.eleme megegyezik a lista masik tombjenek i. elemevel es az egyik == "1" akkor 
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else if (vars[0][i] != "E" && vars[1][i] != "E") // ha a lista egyik tombjenek az i.eleme  sem "E" akkor 
                        {
                            res += "0"; 
                        }
                        else // mivel nem mindketto 1 es egyik sem nem "E"
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                    }
                    break;
                case "OR":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E") // ha a lista valamelyik tombjenek az i.eleme "E" akkor
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] == "1" || vars[1][i] == "1") // ha a lista valamelyik tombjenek az i. eleme "1" akkor
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else if (vars[0][i] == "0" && vars[1][i] == "0") // ha lista mindket tombjenek az i. eleme "0" akkor
                        {
                            res += "0"; // a kimeneti ertek 0 lesz
                        }
                        else // minden egyeb esetben
                        {
                            res += "E";// a kimeneti ertek E lesz
                        }
                    }
                    break;
                case "NOT":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E")
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] == "1")
                        {
                            res += "0"; // a kimeneti ertek 0 lesz
                        }
                        else if (vars[0][i] == "0")
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else
                        {
                            res += "E";  // a kimeneti ertek E lesz
                        }
                    }
                    break;
                case "NAND":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E") // ha a lista valamelyik tombjenek az i. eleme "E" akkor
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] != vars[1][i]) // ha a lista egyik tombjenek az i. eleme nem = a lista masik tombjenek az i. elemevel akkor
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else if (vars[0][i] == vars[1][i] && vars[0][i] == "0") // ha a lista mindket tombjenek az i. eleme azonos es az egyik "0" (ha azonosak es az egyik "0" akkor a masik is) akkor
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else // minden egyeb esetben
                        {
                            res += "0";  // a kimeneti ertek 0 lesz
                        }
                    }
                    break;
                case "NOR":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E") // ha a lista valamelyik tombjenek az i. eleme "E" akkor
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] == vars[1][i] && vars[0][i] == "0") // ha a lista egyik tombejenek az i. eleme azonos a lista masik tombjenek az i. elemevel es az egyik "0" akkor 
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else // minden egyeb esetben
                        {
                            res += "0"; // a kimeneti ertek 0 lesz
                        }
                    }
                    break;
                case "XOR":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E") // ha a lista valamelyik tombjenek az i. eleme "E" akkor 
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] != vars[1][i]) // ha a lista egyik tombjenek az i. eleme nem = a lista masik tombjenek az i. elemevel akkor
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else // minden egyeb esetben
                        {
                            res += "0"; // a kimeneti ertek 0 lesz
                        }
                    }
                    break;
                case "XNOR":
                    for (int i = 0; i < vars[0].Length; i++) // vegigmegyunk a lista egyik elemen (eleg az egyik hossza mivel a listaban minden tomb ugyanolyan hossz)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E") // ha a lista egyik tombjenek az i. eleme "E" akkor
                        {
                            res += "E"; // a kimeneti ertek E lesz
                        }
                        else if (vars[0][i] == vars[1][i]) // ha a lista egyik tombjenek az i. eleme megegyezik a lista masik tombjenek az i. elemevel akkor
                        {
                            res += "1"; // a kimeneti ertek 1 lesz
                        }
                        else // minden egyeb esetben
                        {
                            res += "0"; // a kimeneti ertek 0 lesz
                        }
                    }
                    break;
            }

            return res; // a kimeneti ertek visszaadasa (a res += "" azt jelenti hogy az eddigi res-hez hozzafuz egy ujabb karaktert)
        }
    
    }   
}
