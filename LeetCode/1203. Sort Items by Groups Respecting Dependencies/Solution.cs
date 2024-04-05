namespace LeetCode._1203._Sort_Items_by_Groups_Respecting_Dependencies;

public class Solution
{
  public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
  {
    var itemGraph = new List<int>[n];
    for (var i = 0; i < n; i++)
      itemGraph[i] = new List<int>();
    var groupCount = m;
    for (var i = 0; i < n; i++)
    {
      if (group[i] == -1)
        group[i] = groupCount++;
    }
    var groupGraph = new List<int>[groupCount];
    for (var i = 0; i < groupCount; i++)
      groupGraph[i] = new List<int>();
    for (var i = 0; i < n; i++)
    {
      foreach (var before in beforeItems[i])
      {
        itemGraph[before].Add(i);
        if (group[before] != group[i])
          groupGraph[group[before]].Add(group[i]);
      }
    }
    var sortedItems = new TopologicalSorter(itemGraph).Sort();
    var sortedGroups = new TopologicalSorter(groupGraph).Sort();
    if (sortedItems is null || sortedGroups is null)
      return Array.Empty<int>();

    var sortedItemsInGroup = new List<int>[groupCount];
    foreach (var item in sortedItems)
      (sortedItemsInGroup[group[item]] ??= new List<int>()).Add(item);
    var result = new List<int>(n);
    foreach (var g in sortedGroups)
      if (sortedItemsInGroup[g] != null)
        result.AddRange(sortedItemsInGroup[g]);
    return result.ToArray();
  }

  private class TopologicalSorter
  {
    private readonly List<int>[] _graph;
    private int[] _visited;
    private Stack<int> _result;

    public List<int> Sort()
    {
      var n = _graph.Length;
      _result = new Stack<int>(n);
      _visited = new int[n];
      for (var i = 0; i < n; i++)
      {
        if (_visited[i] == 0 && !Dfs(i))
          return null;
      }
      return _result.ToList();
    }

    private bool Dfs(int from)
    {
      _visited[from] = 1;
      foreach (var next in _graph[from])
      {
        if (_visited[next] == 1 || _visited[next] == 0 && !Dfs(next))
          return false;
      }
      _result.Push(from);
      _visited[from] = 2;
      return true;
    }

    public TopologicalSorter(List<int>[] graph)
    {
      _graph = graph;
    }
  }
}
