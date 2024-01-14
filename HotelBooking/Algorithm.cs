namespace HotelBooking;

public static class Algorithm
{
    public static string HotelBooking(IEnumerable<Room> inputRooms, int inputNumberOfGuest)
    {
        var sortedRooms = inputRooms.OrderBy(r => r.AvgPricePerPerson);
        var solution = BacktrackingCheckValidReservation(sortedRooms, inputNumberOfGuest, new Stack<Room>());

        if (solution is null)
        {
            return "No option";
        }

        var roomList = string.Join(", ", solution.Select(r => r.Type));
        var totalPrice = solution.Sum(r => r.Price);

        return roomList + " - $" + totalPrice;
    }

    private static Stack<Room>? BacktrackingCheckValidReservation(IEnumerable<Room> rooms, int numberOfGuest, Stack<Room> solution) {
        // base case where all the guest are already allocated
        if (numberOfGuest == 0) {
            return solution;
        }

        // loop through all the room to try fit guest into
        foreach (var room in rooms.Where(r => r.NumberOfSleep <= numberOfGuest && r.NumberOfRoom > 0))
        {
            // if there is an available room for guest, allocate the guests to that room
            numberOfGuest -= room.NumberOfSleep;
            room.NumberOfRoom--;
            solution.Push(room);

            // try to find a solution to fit remaining guest into remaining room. 
            if (BacktrackingCheckValidReservation(rooms, numberOfGuest, solution) is not null) {
                return solution;
            } 
                
            // if no solution available, backtrack to previous state
            numberOfGuest += room.NumberOfSleep;
            room.NumberOfRoom++;
            solution.Pop();
        }
        
        // no solution
        return null;
    }
}