namespace LeetCode.Strings._1769._Minimum_Number_of_Operations_to_Move_All_Balls_to_Each_Box;

public class OnePassSolution
{
  public int[] MinOperations(string boxes)
  {
    var n = boxes.Length;
    int countLeft = 0, countRight = 0, sumLeft = 0, sumRight = 0;
    var ans = new int[n];
    for (int i = 0, j = n - 1; i < n; i++, j--)
    {
      ans[i] += sumLeft;
      countLeft += boxes[i] - '0';
      sumLeft += countLeft;

      ans[j] += sumRight;
      countRight += boxes[j] - '0';
      sumRight += countRight;
    }
    return ans;
  }
}

[TestFixture]
public class OnePassSolutionTests
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
    new OnePassSolution().MinOperations(boxes).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
