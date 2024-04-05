namespace LeetCode._1282._Group_the_People;

public class Solution
{
  public IList<IList<int>> GroupThePeople(int[] groupSizes)
  {
    var n = groupSizes.Length;
    var peoplesByGroupSize = new List<int>[n + 1];
    var result = new List<IList<int>>();
    for (var i = 0; i < n; i++)
    {
      var size = groupSizes[i];
      (peoplesByGroupSize[size] ??= new List<int>(size)).Add(i);
      if (peoplesByGroupSize[size].Count == size)
      {
        result.Add(peoplesByGroupSize[size]);
        peoplesByGroupSize[size] = null;
      }
    }
    return result;
  }
}
