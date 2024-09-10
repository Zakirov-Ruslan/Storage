using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;

namespace Storage.Operations
{
    public class PalletOperations
    {
        public static void WritePalletsLastExpirationDate(List<Pallet> pallets, int count)
        {
            var latestExpirationDatePallets = pallets.OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate)).Take(count).OrderBy(p => p.Size);

            Console.WriteLine("\n-------------------------------- LAST EXPIRATION DATE -------------------------------");
            foreach (var pallet in latestExpirationDatePallets)
            {
                Console.WriteLine($"{pallet}, Last Exppiration date: {pallet.Boxes.Max(b => b.ExpirationDate).ToShortDateString()}");
            }
        }

        public static void WritePalletsGroupedByExpirationDate(List<Pallet> pallets)
        {
            var groupedPallets = pallets.GroupBy(p => p.ExpirationDate).OrderBy(p => p.Key);
            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"------------------------------------ {group.Key.ToShortDateString()} -------------------------------------");
                var sortedByWeight = group.OrderBy(p => p.Weight);
                foreach (var pallet in sortedByWeight)
                {
                    Console.WriteLine(pallet);
                }
            }
        }

        public static List<Pallet> GeneratePallets()
        {
            Random random = new Random();

            List<Pallet> pallets = new List<Pallet>();
            for (int i = 1; i <= 300; i++)
            {
                List<Box> boxes = new List<Box>();

                for (int j = 1; j <= random.Next(3, 10); j++)
                {
                    Box box = new Box(
                        id: j + (i - 1) * 5,
                        width: random.Next(5, 20),
                        height: random.Next(5, 20),
                        depth: random.Next(5, 20),
                        weight: random.Next(10, 30),
                        productionDate: null,
                        expirationDate: DateTime.Parse($"{random.Next(1, 28)}.{random.Next(1, 12)}.{random.Next(2024, 2025)} 0:00:00")
                    );
                    boxes.Add(box);
                }

                Pallet pallet = new Pallet(
                    id: i,
                    width: random.Next(20, 40),
                    height: random.Next(20, 40),
                    depth: random.Next(20, 40),
                    boxes: boxes
                );

                pallets.Add(pallet);
            }

            return pallets;
        }
    }
}
