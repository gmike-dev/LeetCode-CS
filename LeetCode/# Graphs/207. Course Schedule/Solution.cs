namespace LeetCode.__Graphs._207._Course_Schedule;

public class Solution
{
  public bool CanFinish(int numCourses, int[][] prerequisites)
  {
    var next = new List<int>[numCourses];
    foreach (var p in prerequisites)
      (next[p[1]] ??= new List<int>()).Add(p[0]);
    var color = new int[numCourses];
    return !Enumerable.Range(0, numCourses).Any(IsCycle);

    bool IsCycle(int v)
    {
      if (color[v] == 0)
      {
        color[v] = 1;
        if (next[v]?.Any(IsCycle) == true)
          return true;
        color[v] = 2;
      }
      return color[v] == 1;
    }
  }
}
