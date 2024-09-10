using Storage.Entities;
using Storage.Operations;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Pallet> pallets = PalletOperations.GeneratePallets();
        PalletOperations.WritePalletsGroupedByExpirationDate(pallets);
        PalletOperations.WritePalletsLastExpirationDate(pallets, 3);

        Console.ReadLine();
    }

}