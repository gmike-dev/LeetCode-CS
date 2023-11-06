using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1845._Seat_Reservation_Manager;

[TestFixture]
public class Tests
{
  [Test]
  public void SortedSetTest()
  {
    var seatManager = new SortedSet.SeatManager(5);
    seatManager.Reserve().Should().Be(1);
    seatManager.Reserve().Should().Be(2);
    seatManager.Unreserve(2);
    seatManager.Reserve().Should().Be(2);
    seatManager.Reserve().Should().Be(3);
    seatManager.Reserve().Should().Be(4);
    seatManager.Reserve().Should().Be(5);
    seatManager.Unreserve(5);
    seatManager.Reserve().Should().Be(5);
  }
  
  [Test]
  public void PriorityQueueTest()
  {
    var seatManager = new PriorityQueue.SeatManager(5);
    seatManager.Reserve().Should().Be(1);
    seatManager.Reserve().Should().Be(2);
    seatManager.Unreserve(2);
    seatManager.Reserve().Should().Be(2);
    seatManager.Reserve().Should().Be(3);
    seatManager.Reserve().Should().Be(4);
    seatManager.Reserve().Should().Be(5);
    seatManager.Unreserve(5);
    seatManager.Reserve().Should().Be(5);
  }
}