using System;
using System.Collections.Generic;
using System.Linq;

namespace T._12
{
    class Dwarf
    {
        public Dwarf(string name, string hatColor, int physicsPoints)
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.PhysicsPoints = physicsPoints;
        }

        public string Name { get; set; }

        public string HatColor { get; set; }

        public int PhysicsPoints { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Peter <:> Red <:> 2000
            // Once upon a time
            List<Dwarf> dwarfs = new List<Dwarf>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] dwarfData = input
                    .Split("<:>", StringSplitOptions.RemoveEmptyEntries);

                string name = dwarfData[0];
                string hatColor = dwarfData[1];
                int physicsPoints = int.Parse(dwarfData[2]);

                Dwarf currDwarf = new Dwarf(name, hatColor, physicsPoints);

                if (dwarfs.Any(d => d.Name == name && d.HatColor == hatColor))
                {
                    Dwarf dwarfFromList = dwarfs.Find(d => d.Name == name && d.HatColor == hatColor);

                    if (currDwarf.PhysicsPoints > dwarfFromList.PhysicsPoints)
                    {
                        dwarfFromList.PhysicsPoints = physicsPoints;
                    }
                }
                else
                {
                    dwarfs.Add(currDwarf);
                }
            }

            foreach (Dwarf dwarf in dwarfs.OrderByDescending(d => d.PhysicsPoints))
            {
                Console.WriteLine($"({dwarf.HatColor.Trim()}) {dwarf.Name.Trim()} <-> {dwarf.PhysicsPoints}");
            }
        }
    }
}
