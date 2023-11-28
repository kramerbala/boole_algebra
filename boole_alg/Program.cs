namespace boole_alg
{
    class Program
    {
        public static void Main()
        {
            var gateInput = Console.ReadLine().Split(' ');

            List<string[]> vars = new List<string[]>();

            var read = 0;
            
            while(read != gateInput.Length-1)
            {
            
                var input = Console.ReadLine();

                if (input != null && (input.ToLower() == "exit"))
                {
                    read = 0;
                }
                else
                {
                    if (input != null)
                    {
                        var inputData = new string[(input.Length - 2) / 2];

                        var op = input[..1];

                        for (int k = 1; k < gateInput.Length; k++)
                        {
                            if (op == gateInput[k])
                            {
                                for (int i = 0; i < inputData.Length; i++)
                                {
                                    var startIndex = 2 + (i) * 2;
                                    if (startIndex < input.Length)
                                    {

                                        string tmp = input.Substring(startIndex, 1)+","+input.Substring(startIndex + 1, 1);
                                        double level = double.Parse(tmp);
                                        string rel;

                                        if (level is <= 0.8 and >= 0)
                                        {
                                            rel = "0";
                                        }
                                        else if(level is <= 5 and >= 2.7)
                                        {
                                            rel = "1";
                                        }
                                        else
                                        {
                                            rel = "E";
                                        }
                                
                                        inputData[i] = rel;   
                                    }
                                }
            
                                vars.Add(inputData);
                                read++;
                            }

                        }
                    }
                }
            }

            var report = GetOutput(vars, gateInput);
        
            Console.WriteLine(report);
        
        }

        private static string GetOutput(List<string[]> vars, string[] gateInput)
        {
            var res = "";

            var gate = gateInput[0];

            switch (gate)
            {
                case "AND":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == vars[1][i] && vars[0][i] == "1")
                        {
                            res += "1";
                        }
                        else if (vars[0][i] != "E" && vars[1][i] != "E")
                        {
                            res += "0";
                        }
                        else
                        {
                            res += "E";
                        }
                    }
                    break;
                case "OR":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] == "1" || vars[1][i] == "1")
                        {
                            res += "1";
                        }
                        else if (vars[0][i] == "0" && vars[1][i] == "0")
                        {
                            res += "0";
                        }
                        else
                        {
                            res += "E";
                        }
                    }
                    break;
                case "NOT":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] == "1")
                        {
                            res += "0";
                        }
                        else if (vars[0][i] == "0")
                        {
                            res += "1";
                        }
                        else
                        {
                            res += "E";
                        }
                    }
                    break;
                case "NAND":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] != vars[1][i])
                        {
                            res += "1";
                        }
                        else if (vars[0][i] == vars[1][i] && vars[0][i] == "0")
                        {
                            res += "1";
                        }
                        else
                        {
                            res += "0";
                        }
                    }
                    break;
                case "NOR":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] == vars[1][i] && vars[0][i] == "0")
                        {
                            res += "1";
                        }
                        else
                        {
                            res += "0";
                        }
                    }
                    break;
                case "XOR":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] != vars[1][i])
                        {
                            res += "1";
                        }
                        else
                        {
                            res += "0";
                        }
                    }
                    break;
                case "XNOR":
                    for (var i = 0; i < vars[0].Length; i++)
                    {
                        if (vars[0][i] == "E" || vars[1][i] == "E")
                        {
                            res += "E";
                        }
                        else if (vars[0][i] == vars[1][i])
                        {
                            res += "1";
                        }
                        else
                        {
                            res += "0";
                        }
                    }
                    break;
            }

            return res;
        }
    
    }   
}