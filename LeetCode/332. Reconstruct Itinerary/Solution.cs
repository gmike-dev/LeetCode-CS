using System.Collections.Generic;

namespace LeetCode._332._Reconstruct_Itinerary;

public class Solution
{
  private Dictionary<string, List<(string, int)>> _flights = new();
  private bool[] _used;
  private int _ticketsUsed;
  private readonly List<string> _itinerary = new();
  private int _ticketsCount;

  public IList<string> FindItinerary(IList<IList<string>> tickets)
  {
    _ticketsCount = tickets.Count;
    _used = new bool[_ticketsCount];

    _flights = new Dictionary<string, List<(string, int)>>();
    for (var i = 0; i < _ticketsCount; i++)
    {
      var (departure, arrival) = (tickets[i][0], tickets[i][1]);
      if (_flights.TryGetValue(departure, out var arrivals))
        arrivals.Add((arrival, i));
      else
        _flights[departure] = new List<(string, int)> { (arrival, i) };
    }

    foreach (var arrivals in _flights.Values)
      arrivals.Sort();

    _itinerary.Add("JFK");
    return Dfs("JFK") ? _itinerary : null;
  }

  private bool Dfs(string departure)
  {
    var arrivals = _flights.GetValueOrDefault(departure);
    if (arrivals != null)
    {
      foreach (var (arrival, ticket) in arrivals)
      {
        if (_used[ticket])
          continue;

        _used[ticket] = true;
        _ticketsUsed++;
        _itinerary.Add(arrival);

        if (_ticketsUsed == _ticketsCount || Dfs(arrival))
          return true;

        _itinerary.RemoveAt(_itinerary.Count - 1);
        _used[ticket] = false;
        _ticketsUsed--;
      }
    }
    return false;
  }
}