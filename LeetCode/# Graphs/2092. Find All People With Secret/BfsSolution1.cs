namespace LeetCode.__Graphs._2092._Find_All_People_With_Secret;

public class BfsSolution1
{
  public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
  {
    var secret = new HashSet<int> { 0, firstPerson };
    foreach (var meetingGroup in meetings.GroupBy(m => m[2]).OrderBy(g => g.Key))
    {
      if (!meetingGroup.Any(m => secret.Contains(m[0]) || secret.Contains(m[1])))
        continue;
      var g = MakeGraph(meetingGroup);
      var used = new HashSet<int>();
      foreach (var meeting in meetingGroup)
      {
        Bfs(g, used, meeting[0]);
        Bfs(g, used, meeting[1]);
      }
    }
    return secret.ToArray();

    void Bfs(Dictionary<int, List<int>> g, HashSet<int> used, int start)
    {
      if (used.Contains(start) || !secret.Contains(start))
        return;
      var q = new Queue<int>();
      q.Enqueue(start);
      while (q.Count != 0)
      {
        var v = q.Dequeue();
        foreach (var next in g[v])
        {
          secret.Add(next);
          if (used.Add(next))
            q.Enqueue(next);
        }
      }
    }

    Dictionary<int, List<int>> MakeGraph(IEnumerable<int[]> meetingGroup)
    {
      var g = new Dictionary<int, List<int>>();
      foreach (var meeting in meetingGroup)
      {
        var (p1, p2) = (meeting[0], meeting[1]);
        if (g.TryGetValue(p1, out var list))
          list.Add(p2);
        else
          g[p1] = new List<int> { p2 };
        if (g.TryGetValue(p2, out list))
          list.Add(p1);
        else
          g[p2] = new List<int> { p1 };
      }
      return g;
    }
  }
}

[TestFixture]
public class BfsSolution1Tests
{
  [Test]
  public void Test1()
  {
    new BfsSolution1().FindAllPeople(6, new[]
      {
        new[] { 1, 2, 5 }, new[] { 2, 3, 8 }, new[] { 1, 5, 10 }
      }, 1)
      .Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 5 });
  }

  [Test]
  public void Test2()
  {
    new BfsSolution1().FindAllPeople(4, new[]
      {
        new[] { 3, 1, 3 }, new[] { 1, 2, 2 }, new[] { 0, 3, 3 }
      }, 3)
      .Should().BeEquivalentTo(new[] { 0, 1, 3 });
  }

  [Test]
  public void Test32()
  {
    new BfsSolution1().FindAllPeople(6, new[]
      {
        new[] { 0, 2, 1 }, new[] { 1, 3, 1 }, new[] { 4, 5, 1 }
      }, 1)
      .Should().BeEquivalentTo(new[] { 0, 1, 2, 3 });
  }

  [Test]
  public void Test39()
  {
    new BfsSolution1().FindAllPeople(5, new[]
      {
        new[] { 1, 4, 3 }, new[] { 0, 4, 3 }
      }, 3)
      .Should().BeEquivalentTo(new[] { 0, 1, 3, 4 });
  }
}
