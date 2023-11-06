using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1845._Seat_Reservation_Manager;

[TestFixture]
public class Tests
{
  [Test]
  public void Test()
  {
    var seatManager = new SeatManager(5);
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