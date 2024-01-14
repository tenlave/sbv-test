// See https://aka.ms/new-console-template for more information

#region declare arguments

using HotelBooking;

var rooms = new List<Room>
{
    new()
    {
        Type = "Single",
        NumberOfSleep = 1,
        NumberOfRoom = 4,
        Price = 30
    },
    new()
    {
        Type = "Double",
        NumberOfSleep = 2,
        NumberOfRoom = 3,
        Price = 50
    },
    new()
    {
        Type = "Family",
        NumberOfSleep = 4,
        NumberOfRoom = 1,
        Price = 85
    }
};
const int numberOfGuest = 3;

#endregion

Console.WriteLine(Algorithm.HotelBooking(rooms, numberOfGuest));