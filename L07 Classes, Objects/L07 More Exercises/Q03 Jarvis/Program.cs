using System;
using System.Collections.Generic;
using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            long maximumEnergyCapacity = long.Parse(Console.ReadLine());
            var jarvis = new Jarvis();
            jarvis.EnergyConsumption = maximumEnergyCapacity;
            jarvis.listOfArms = new List<Arm>();
            jarvis.listOfLegs = new List<Leg>();
            jarvis.listOfTorso = new List<Torso>();
            jarvis.listOfHeads = new List<Head>();

            var input = Console.ReadLine();
            while (input != "Assemble!")
            {
                var inputTokens = input.Split(' ').ToArray();
                string component = inputTokens[0];

                switch (component)
                {
                    case "Leg":
                        var leg = new Leg();
                        leg.EnergyConsumption = int.Parse(inputTokens[1]);
                        leg.Strength = int.Parse(inputTokens[2]);
                        leg.Speed = int.Parse(inputTokens[3]);
                        jarvis.listOfLegs.Add(leg);
                        break;

                    case "Arm":
                        var arm = new Arm();
                        arm.EnergyConsumption = int.Parse(inputTokens[1]);
                        arm.ReachDistance = int.Parse(inputTokens[2]);
                        arm.FingerCount = int.Parse(inputTokens[3]);
                        jarvis.listOfArms.Add(arm);
                        break;

                    case "Head":
                        var head = new Head();
                        head.EnergyConsumption = int.Parse(inputTokens[1]);
                        head.IQ = int.Parse(inputTokens[2]);
                        head.SkinMaterial = inputTokens[3];
                        jarvis.listOfHeads.Add(head);
                        break;

                    case "Torso":
                        var torso = new Torso();
                        torso.EnergyConsumption = int.Parse(inputTokens[1]);
                        torso.ProcessorSize = double.Parse(inputTokens[2]);
                        torso.Material = inputTokens[3];
                        jarvis.listOfTorso.Add(torso);
                        break;
                }
                input = Console.ReadLine();
            }

            // checking if parts are enough
            bool headIsThere = jarvis.listOfHeads.Count > 0;
            bool torsoIsThere = jarvis.listOfTorso.Count > 0;
            bool twoArms = jarvis.listOfArms.Count > 1;
            bool twoLegs = jarvis.listOfLegs.Count > 1;
            bool weNeedMoreParts = !(headIsThere && torsoIsThere && twoArms && twoLegs);
            if (weNeedMoreParts == true)
            {
                Console.WriteLine("We need more parts!");
                Environment.Exit(0);
            }

            // Choosing the best components
            var theHead = jarvis.listOfHeads.OrderBy(x => x.EnergyConsumption).First();
            var theTorso = jarvis.listOfTorso.OrderBy(x => x.EnergyConsumption).First();
            var arrayOfLegs = jarvis.listOfLegs.OrderBy(x => x.EnergyConsumption).Take(2).ToArray();
            var arrayOfArms = jarvis.listOfArms.OrderBy(x => x.EnergyConsumption).Take(2).ToArray();

            // checking if enough Energy
            long totalComponentEnergy = 0;
            totalComponentEnergy += theHead.EnergyConsumption;
            totalComponentEnergy += theTorso.EnergyConsumption;
            for (int leg = 0; leg < 2; leg++)
            {
                totalComponentEnergy += arrayOfLegs[leg].EnergyConsumption;
            }
            for (int arm = 0; arm < 2; arm++)
            {
                totalComponentEnergy += arrayOfArms[arm].EnergyConsumption;
            }

            bool notEnoughEnergy = jarvis.EnergyConsumption < totalComponentEnergy;
            if (notEnoughEnergy == true)
            {
                Console.WriteLine("We need more power!");
                Environment.Exit(0);
            }

            // if enough parts and enough energy this is output:
            Console.WriteLine("Jarvis:");

            Console.WriteLine("#Head:");
            Console.WriteLine($"###Energy consumption: {theHead.EnergyConsumption}");
            Console.WriteLine($"###IQ: {theHead.IQ}");
            Console.WriteLine($"###Skin material: {theHead.SkinMaterial}");

            Console.WriteLine("#Torso: ");
            Console.WriteLine($"###Energy consumption: {theTorso.EnergyConsumption}");
            Console.WriteLine($"###Processor size: {theTorso.ProcessorSize:f1}");
            Console.WriteLine($"###Corpus material: {theTorso.Material}");

            arrayOfArms.OrderBy(x => x.EnergyConsumption); // maybe do arrayOfArms = arrayOfArms.....
            Console.WriteLine("#Arm: ");
            Console.WriteLine($"###Energy consumption: {arrayOfArms[0].EnergyConsumption}");
            Console.WriteLine($"###Reach: {arrayOfArms[0].ReachDistance}");
            Console.WriteLine($"###Fingers: {arrayOfArms[0].FingerCount}");

            Console.WriteLine("#Arm: ");
            Console.WriteLine($"###Energy consumption: {arrayOfArms[1].EnergyConsumption}");
            Console.WriteLine($"###Reach: {arrayOfArms[1].ReachDistance}");
            Console.WriteLine($"###Fingers: {arrayOfArms[1].FingerCount}");

            arrayOfLegs.OrderBy(x => x.EnergyConsumption);
            Console.WriteLine("#Leg: ");
            Console.WriteLine($"###Energy consumption: {arrayOfLegs[0].EnergyConsumption}");
            Console.WriteLine($"###Strength: {arrayOfLegs[0].Strength}");
            Console.WriteLine($"###Speed: {arrayOfLegs[0].Speed}");

            Console.WriteLine("#Leg: ");
            Console.WriteLine($"###Energy consumption: {arrayOfLegs[1].EnergyConsumption}");
            Console.WriteLine($"###Strength: {arrayOfLegs[1].Strength}");
            Console.WriteLine($"###Speed: {arrayOfLegs[1].Speed}");
        }
    }
