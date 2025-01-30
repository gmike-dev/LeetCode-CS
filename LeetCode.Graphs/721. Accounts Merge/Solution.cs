namespace LeetCode.Graphs._721._Accounts_Merge;

public class Solution
{
  public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
  {
    var uf = new UnionFind(accounts.Count);
    var emailMainAccount = new Dictionary<string, int>();
    for (var i = 0; i < accounts.Count; i++)
    {
      var account = accounts[i];
      foreach (var email in account.Skip(1))
      {
        if (emailMainAccount.TryGetValue(email, out var mainAcc))
          uf.Union(mainAcc, i);
        else
          emailMainAccount[email] = i;
      }
    }
    var mergedAccounts = new Dictionary<int, List<string>>();
    foreach (var (email, acc) in emailMainAccount)
    {
      var mainAcc = uf.Find(acc);
      if (mergedAccounts.TryGetValue(mainAcc, out var list))
        list.Add(email);
      else
        mergedAccounts[mainAcc] = [email];
    }
    foreach (var list in mergedAccounts.Values)
      list.Sort(StringComparer.Ordinal);
    var result = new List<IList<string>>(mergedAccounts.Count);
    foreach (var (acc, emails) in mergedAccounts)
      result.Add([accounts[acc][0], ..emails]);
    return result;
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    public int Find(int x)
    {
      while (parent[x] != x)
      {
        parent[x] = parent[parent[x]];
        x = parent[x];
      }
      return x;
    }

    public void Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x == y)
        return;
      if (size[x] < size[y])
        (x, y) = (y, x);
      parent[y] = x;
      size[x] += size[y];
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .AccountsMerge([
        ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["John", "johnsmith@mail.com", "john00@mail.com"],
        ["Mary", "mary@mail.com"], ["John", "johnnybravo@mail.com"]
      ]).Should().BeEquivalentTo(
        (IList<IList<string>>)
        [
          ["John", "john00@mail.com", "john_newyork@mail.com", "johnsmith@mail.com"], ["Mary", "mary@mail.com"],
          ["John", "johnnybravo@mail.com"]
        ]);
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .AccountsMerge([
        ["Gabe", "Gabe0@m.co", "Gabe3@m.co", "Gabe1@m.co"], ["Kevin", "Kevin3@m.co", "Kevin5@m.co", "Kevin0@m.co"],
        ["Ethan", "Ethan5@m.co", "Ethan4@m.co", "Ethan0@m.co"], ["Hanzo", "Hanzo3@m.co", "Hanzo1@m.co", "Hanzo0@m.co"],
        ["Fern", "Fern5@m.co", "Fern1@m.co", "Fern0@m.co"]
      ]).Should().BeEquivalentTo(
        (IList<IList<string>>)
        [
          ["Ethan", "Ethan0@m.co", "Ethan4@m.co", "Ethan5@m.co"], ["Gabe", "Gabe0@m.co", "Gabe1@m.co", "Gabe3@m.co"],
          ["Hanzo", "Hanzo0@m.co", "Hanzo1@m.co", "Hanzo3@m.co"],
          ["Kevin", "Kevin0@m.co", "Kevin3@m.co", "Kevin5@m.co"], ["Fern", "Fern0@m.co", "Fern1@m.co", "Fern5@m.co"]
        ]);
  }
}
