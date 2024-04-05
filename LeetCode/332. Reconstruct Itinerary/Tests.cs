namespace LeetCode._332._Reconstruct_Itinerary;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .FindItinerary(new IList<string>[]
      {
        new[] { "MUC", "LHR" },
        new[] { "JFK", "MUC" },
        new[] { "SFO", "SJC" },
        new[] { "LHR", "SFO" }
      })
      .Should()
      .BeEquivalentTo(new[]
      {
        "JFK", "MUC", "LHR", "SFO", "SJC"
      }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .FindItinerary(new IList<string>[]
      {
        new[] { "JFK", "SFO" },
        new[] { "JFK", "ATL" },
        new[] { "SFO", "ATL" },
        new[] { "ATL", "JFK" },
        new[] { "ATL", "SFO" }
      })
      .Should()
      .BeEquivalentTo(new[]
      {
        "JFK", "ATL", "JFK", "SFO", "ATL", "SFO"
      }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .FindItinerary(new IList<string>[]
      {
        new[] { "JFK", "KUL" },
        new[] { "JFK", "NRT" },
        new[] { "NRT", "JFK" }
      })
      .Should()
      .BeEquivalentTo(new[]
      {
        "JFK", "NRT", "JFK", "KUL"
      }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new Solution()
      .FindItinerary(new IList<string>[]
      {
        new[] { "AXA", "EZE" }, new[] { "EZE", "AUA" }, new[] { "ADL", "JFK" }, new[] { "ADL", "TIA" },
        new[] { "AUA", "AXA" }, new[] { "EZE", "TIA" }, new[] { "EZE", "TIA" }, new[] { "AXA", "EZE" },
        new[] { "EZE", "ADL" }, new[] { "ANU", "EZE" }, new[] { "TIA", "EZE" }, new[] { "JFK", "ADL" },
        new[] { "AUA", "JFK" }, new[] { "JFK", "EZE" }, new[] { "EZE", "ANU" }, new[] { "ADL", "AUA" },
        new[] { "ANU", "AXA" }, new[] { "AXA", "ADL" }, new[] { "AUA", "JFK" }, new[] { "EZE", "ADL" },
        new[] { "ANU", "TIA" }, new[] { "AUA", "JFK" }, new[] { "TIA", "JFK" }, new[] { "EZE", "AUA" },
        new[] { "AXA", "EZE" }, new[] { "AUA", "ANU" }, new[] { "ADL", "AXA" }, new[] { "EZE", "ADL" },
        new[] { "AUA", "ANU" }, new[] { "AXA", "EZE" }, new[] { "TIA", "AUA" }, new[] { "AXA", "EZE" },
        new[] { "AUA", "SYD" }, new[] { "ADL", "JFK" }, new[] { "EZE", "AUA" }, new[] { "ADL", "ANU" },
        new[] { "AUA", "TIA" }, new[] { "ADL", "EZE" }, new[] { "TIA", "JFK" }, new[] { "AXA", "ANU" },
        new[] { "JFK", "AXA" }, new[] { "JFK", "ADL" }, new[] { "ADL", "EZE" }, new[] { "AXA", "TIA" },
        new[] { "JFK", "AUA" }, new[] { "ADL", "EZE" }, new[] { "JFK", "ADL" }, new[] { "ADL", "AXA" },
        new[] { "TIA", "AUA" }, new[] { "AXA", "JFK" }, new[] { "ADL", "AUA" }, new[] { "TIA", "JFK" },
        new[] { "JFK", "ADL" }, new[] { "JFK", "ADL" }, new[] { "ANU", "AXA" }, new[] { "TIA", "AXA" },
        new[] { "EZE", "JFK" }, new[] { "EZE", "AXA" }, new[] { "ADL", "TIA" }, new[] { "JFK", "AUA" },
        new[] { "TIA", "EZE" }, new[] { "EZE", "ADL" }, new[] { "JFK", "ANU" }, new[] { "TIA", "AUA" },
        new[] { "EZE", "ADL" }, new[] { "ADL", "JFK" }, new[] { "ANU", "AXA" }, new[] { "AUA", "AXA" },
        new[] { "ANU", "EZE" }, new[] { "ADL", "AXA" }, new[] { "ANU", "AXA" }, new[] { "TIA", "ADL" },
        new[] { "JFK", "ADL" }, new[] { "JFK", "TIA" }, new[] { "AUA", "ADL" }, new[] { "AUA", "TIA" },
        new[] { "TIA", "JFK" }, new[] { "EZE", "JFK" }, new[] { "AUA", "ADL" }, new[] { "ADL", "AUA" },
        new[] { "EZE", "ANU" }, new[] { "ADL", "ANU" }, new[] { "AUA", "AXA" }, new[] { "AXA", "TIA" },
        new[] { "AXA", "TIA" }, new[] { "ADL", "AXA" }, new[] { "EZE", "AXA" }, new[] { "AXA", "JFK" },
        new[] { "JFK", "AUA" }, new[] { "ANU", "ADL" }, new[] { "AXA", "TIA" }, new[] { "ANU", "AUA" },
        new[] { "JFK", "EZE" }, new[] { "AXA", "ADL" }, new[] { "TIA", "EZE" }, new[] { "JFK", "AXA" },
        new[] { "AXA", "ADL" }, new[] { "EZE", "AUA" }, new[] { "AXA", "ANU" }, new[] { "ADL", "EZE" },
        new[] { "AUA", "EZE" }
      })
      .Should()
      .BeEquivalentTo(new[]
      {
        "JFK", "ADL", "ANU", "ADL", "ANU", "AUA", "ADL", "AUA", "ADL", "AUA", "ANU", "AXA", "ADL", "AUA", "ANU", "AXA",
        "ADL", "AXA", "ADL", "AXA", "ANU", "AXA", "ANU", "AXA", "EZE", "ADL", "AXA", "EZE", "ADL", "AXA", "EZE", "ADL",
        "EZE", "ADL", "EZE", "ADL", "EZE", "ANU", "EZE", "ANU", "EZE", "AUA", "AXA", "EZE", "AUA", "AXA", "EZE", "AUA",
        "AXA", "JFK", "ADL", "EZE", "AUA", "EZE", "AXA", "JFK", "ADL", "JFK", "ADL", "JFK", "ADL", "JFK", "ADL", "TIA",
        "ADL", "TIA", "AUA", "JFK", "ANU", "TIA", "AUA", "JFK", "AUA", "JFK", "AUA", "TIA", "AUA", "TIA", "AXA", "TIA",
        "EZE", "AXA", "TIA", "EZE", "JFK", "AXA", "TIA", "EZE", "JFK", "AXA", "TIA", "JFK", "EZE", "TIA", "JFK", "EZE",
        "TIA", "JFK", "TIA", "JFK", "AUA", "SYD"
      }, o => o.WithStrictOrdering());
  }
}
