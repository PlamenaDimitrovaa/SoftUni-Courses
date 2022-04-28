using System;
using System.Collections.Generic;

namespace _07.MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var splitted = input.Split();
                string action = splitted[0];
                int id = int.Parse(splitted[1]);
                string firstName = splitted[2];
                string lastName = splitted[3];

                if (action == "Private")
                {
                    decimal salary = decimal.Parse(splitted[4]);
                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id, @private);
                }
                else if (action == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(splitted[4]);
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    for (int i = 5; i < splitted.Length; i++)
                    {
                        int inputId = int.Parse(splitted[i]);
                        IPrivate @private = soldiers[inputId] as IPrivate;
                        lieutenantGeneral.Privates.Add(@private);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (action == "Engineer")
                {
                    decimal salary = decimal.Parse(splitted[4]);
                    string corpAsString = splitted[5];

                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, result);

                    for (int i = 6; i < splitted.Length; i += 2)
                    {
                        string partName = splitted[i];
                        int hours = int.Parse(splitted[i + 1]);
                        IRepair repair = new Repair(partName, hours);
                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (action == "Commando")
                {
                    decimal salary = decimal.Parse(splitted[4]);
                    string corpAsString = splitted[5];

                    bool isValidEnum = Enum.TryParse(corpAsString, out Corps result);
                    if (!isValidEnum)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, result);
                    for (int i = 6; i < splitted.Length; i += 2)
                    {
                        string missionCode = splitted[i];
                        string missionStateAsString = splitted[i + 1];
                        bool isValidMission = Enum.TryParse(missionStateAsString, out Status status);
                        if (!isValidMission)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionCode, status);

                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);

                }
                else if (action == "Spy")
                {
                    int codeNumber = int.Parse(splitted[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine();
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
