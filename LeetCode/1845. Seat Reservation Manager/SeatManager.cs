using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1845._Seat_Reservation_Manager;

public class SeatManager
{
  readonly SortedSet<int> unreserved = new();
  private int next = 1;

  public SeatManager(int n)
  {
  }

  public int Reserve()
  {
    if (unreserved.Count == 0)
      return next++;

    var result = unreserved.Min;
    unreserved.Remove(result);
    return result;
  }

  public void Unreserve(int seatNumber)
  {
    unreserved.Add(seatNumber);
  }
}