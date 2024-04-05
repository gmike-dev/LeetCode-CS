namespace LeetCode._332._Reconstruct_Itinerary;

public class Solution
{
  public IList<string> FindItinerary(IList<IList<string>> tickets)
  {
    var flights = new Dictionary<string, List<string>>();
    foreach (var ticket in tickets)
    {
      var (departure, arrival) = (ticket[0], ticket[1]);
      if (flights.TryGetValue(departure, out var arrivals))
        arrivals.Add(arrival);
      else
        flights[departure] = new List<string> { arrival };
    }

    foreach (var arrivals in flights.Values)
      arrivals.Sort((x, y) => string.CompareOrdinal(y, x));

    Stack<string> itinerary = new();

    void Dfs(string airport)
    {
      if (flights.TryGetValue(airport, out var arrivals))
      {
        while (arrivals.Count > 0)
        {
          var next = arrivals[^1];
          arrivals.RemoveAt(arrivals.Count - 1);
          Dfs(next);
        }
      }
      itinerary.Push(airport);
    }

    Dfs("JFK");
    return itinerary.ToArray();
  }
}
