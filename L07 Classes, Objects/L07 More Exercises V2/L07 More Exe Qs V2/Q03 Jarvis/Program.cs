using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //the question:
        #region
        //Every kid’s dream is to have its own personal robot to be their butler and/or slave.
        //Until now, we could not build a fully functional robot, but we can write a program, which simulates what it would be like to build. 
        //Let’s call him a code name – Jarvis.

        //Our robot will consist of 6 components – 2 arms, 2 legs, torso and a head.
        //Make classes for these components and your robot should have fields for each of the components.
        //Each component has different properties:
        //  •	Arms have:
        //        o   Energy consumption(integer)
        //        o   Arm reach distance(integer)
        //        o   Count of fingers(integer)
        //  •	Legs have:
        //        o   Energy consumption(integer)
        //        o   Strength(integer)
        //        o   Speed(integer)
        //  •	Torso has:
        //        o   Energy consumption(integer)
        //        o   Processor size in centimeters(double)
        //        o   Housing material(string)
        //  •	Head has:
        //        o   Energy consumption(integer)
        //        o   IQ(integer)
        //        o   Skin material(string)

        //On the first line, you will receive the maximum energy capacity of the robot.
        //Until you receive the command “Assemble!”, you will continuously receive lines with data for different components in format:
        //{ typeOfComponent} { energyConsumption}{ property1}{ property2}

        //The properties will always be given in the same order as they are described above.
        //If you receive a component which is more energy efficient than previous one – you should delete the old component
        //and replace it with the new one.
        //When both of the components consume more energy than the one, which you try to add  remove the one, which is added first.
        #endregion

        var robot = new Robot();
        var arms = new List<Arm>();
        robot.Arms = arms;
        var legs = new List<Leg>();
        robot.Legs = legs;

        long maxCapacity = long.Parse(Console.ReadLine());
        robot.Capacity = maxCapacity;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Assemble")
            {
                break;
            }

            var inputTokens = input.Split(' ').ToArray();

            switch (inputTokens[0])
            {
                case "Head":
                    var head = new Head()
                    {
                        Energy = int.Parse(inputTokens[1]),
                        IQ = int.Parse(inputTokens[2]),
                        Material = inputTokens[3]
                    };

                    bool missingHead = robot.Head == null;
                    if (missingHead)
                    {
                        robot.Head = head;
                    }
                    else//compare to current head if more E efficient
                    {
                        bool moreEfficient = robot.Head.Energy > head.Energy;
                        if (moreEfficient)
                        {
                            robot.Head = head;
                        }
                    }
                    break;

                case "Torso":
                    var torso = new Torso()
                    {
                        Energy = int.Parse(inputTokens[1]),
                        Size = double.Parse(inputTokens[2]),
                        Material = inputTokens[3]
                    };
                    bool missingTorso = robot.Torso == null;
                    if (missingTorso)
                    {
                        robot.Torso = torso;
                    }
                    else
                    {
                        bool moreEfficient = robot.Torso.Energy > torso.Energy;
                        if (moreEfficient)
                        {
                            robot.Torso = torso;
                        }
                    }
                    break;

                case "Arm":
                    var arm = new Arm()
                    {
                        Energy = int.Parse(inputTokens[1]),
                        Reach = int.Parse(inputTokens[2]),
                        Fingers = int.Parse(inputTokens[3])
                    };

                    bool notEnoughArms = robot.Arms.Count() < 2;
                    if (notEnoughArms)
                    {
                        robot.Arms.Add(arm);
                    }
                    else
                    {
                        bool bothAreLessEfficient = robot.Arms.All(x => x.Energy > arm.Energy);
                        if (bothAreLessEfficient)
                        {
                            robot.Arms[0] = arm;
                        }

                        var worseArm = robot.Arms.OrderByDescending(x => x.Energy).First(); // return less efficient arm
                        bool oneIsLessEfficient = worseArm.Energy > arm.Energy;
                        if (oneIsLessEfficient) //find the only less effiecnt one
                        {
                            var newArms = robot.Arms.Single(x => { x.Energy = worseArm.Energy; return arm; });
                            robot.Arms = newArms.ToList();
                        }
                    }

                    break;
                case "Leg":
                    //
                    break;
                default:
                    break;
            }
        }
    }
}