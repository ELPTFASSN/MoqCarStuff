namespace CarStuff
{
    public interface IDriver
    {
        string CarColor { get; }
        string TireOption { get; }
        bool PurchasedSportsPackage { get; }

        int Drive();
    }
}