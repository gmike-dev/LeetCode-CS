namespace LeetCode._1845._Seat_Reservation_Manager.PriorityQueue;

public class SeatManager
{
  readonly PriorityQueue<int, int> unreserved = new();
  private int next = 1;

  public SeatManager(int n)
  {
  }

  public int Reserve()
  {
    return unreserved.Count != 0 ? unreserved.Dequeue() : next++;
  }

  public void Unreserve(int seatNumber)
  {
    unreserved.Enqueue(seatNumber, seatNumber);
  }
}
