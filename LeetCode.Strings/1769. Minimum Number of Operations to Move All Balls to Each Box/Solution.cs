namespace LeetCode.Strings._1769._Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box;

public class Solution
{
  public int[] MinOperations(string boxes)
  {
    var n = boxes.Length;
    int countLeft = 0, countRight = 0, sumLeft = 0, sumRight = 0;
    for (var i = 0; i < n; i++)
    {
      if (boxes[i] == '1')
      {
        countRight++;
        sumRight += i;
      }
    }
    var ans = new int[n];
    for (var i = 0; i < n; i++)
    {
      ans[i] = sumLeft + sumRight;
      if (boxes[i] == '1')
      {
        countRight--;
        countLeft++;
      }
      sumLeft += countLeft;
      sumRight -= countRight;
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("110", new[] { 1, 1, 3 })]
  [TestCase("001011", new[] { 11, 8, 5, 4, 3, 4 })]
  [TestCase("0", new[] { 0 })]
  [TestCase("1", new[] { 0 })]
  [TestCase("10", new[] { 0, 1 })]
  [TestCase("01", new[] { 1, 0 })]
  [TestCase("11", new[] { 1, 1 })]
  public void Test(string boxes, int[] expected)
  {
    new Solution().MinOperations(boxes).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
