using PointOfSales;

internal class Program
{
    private static void Main(string[] args)
    {
        ScaningABar scaningABar =new ScaningABar("23456");
        string reslut =scaningABar.GetTheBarCodeScaned();
        Console.WriteLine(reslut);
    }
}