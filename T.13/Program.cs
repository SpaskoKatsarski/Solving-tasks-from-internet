using System;
using System.Collections.Generic;
using System.Linq;

namespace T._13
{
    class Dragon
    {
        public Dragon(string dragonName, int health, int damage, int armor)
        {
            this.DragonName = dragonName;
            this.Health = health;
            this.Damage = damage;
            this.Armor = armor;
        }
        public string DragonName { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int DefaultHealth = 250;
            const int DefaultDamage = 45;
            const int DefaultArmor = 10;

            Dictionary<string, List<Dragon>> typeWithItsDragons = new Dictionary<string, List<Dragon>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                //{type} {name} {damage} {health} {armor}
                string[] dragonInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = dragonInfo[0];
                string name = dragonInfo[1];

                string testDamage = dragonInfo[2];
                string testHealth = dragonInfo[3];
                string testArmor = dragonInfo[4];

                int damage;
                int health;
                int armor;

                if (string.IsNullOrEmpty(testDamage))
                {
                    damage = DefaultDamage;
                }
                else
                {
                    damage = int.Parse(testDamage);
                }

                if (string.IsNullOrEmpty(testHealth))
                {
                    health = DefaultHealth;
                }
                else
                {
                    health = int.Parse(testHealth);
                }

                if (string.IsNullOrEmpty(testArmor))
                {
                    armor = DefaultArmor;
                }
                else
                {
                    armor = int.Parse(testArmor);
                }


                if (typeWithItsDragons.ContainsKey(type))
                {
                    if (typeWithItsDragons[type].Any(x => x.DragonName == name))
                    {
                        Dragon currDragon = typeWithItsDragons[type].Find(d => d.DragonName == name);

                        currDragon.Damage = damage;
                        currDragon.Health = health;
                        currDragon.Armor = armor;
                    }
                }
                else
                {
                    typeWithItsDragons.Add(type, new List<Dragon>{ new (name, health, damage, armor) });
                }
            }

            foreach (var kvp in typeWithItsDragons)
            {
                Console.WriteLine(kvp.Key);

                foreach (var dragon in kvp.Value)
                {
                    Console.WriteLine(dragon.DragonName);
                }
            }
        }
    }
}
