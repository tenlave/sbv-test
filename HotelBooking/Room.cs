namespace HotelBooking;

public class Room
{
    public string Type { get; set; }
    public int NumberOfSleep { get; set; }
    public int NumberOfRoom { get; set; }
    public int Price { get; set; }

    public double AvgPricePerPerson => Price / (double)NumberOfSleep;
}