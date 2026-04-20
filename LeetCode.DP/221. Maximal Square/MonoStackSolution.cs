namespace LeetCode.DP._221._Maximal_Square;

public class MonoStackSolution
{
  public int MaximalSquare(char[][] matrix)
  {
    int m = matrix.Length;
    int n = matrix[0].Length;
    int ans = 0;
    int[] colOnes = new int[n];
    for (int i = 0; i < m; i++)
    {
      Stack<(int Index, int Ones)> monoStack = new();
      for (int j = 0; j < n; j++)
      {
        if (matrix[i][j] == '0')
        {
          monoStack.Clear();
          colOnes[j] = 0;
        }
        else
        {
          int index = j;
          colOnes[j]++;
          while (monoStack.Count > 0 && monoStack.Peek().Ones >= colOnes[j])
          {
            index = monoStack.Pop().Index;
          }
          monoStack.Push((index, colOnes[j]));

          foreach ((int k, int ones) in monoStack)
          {
            ans = Math.Max(ans, Math.Min(ones, j - k + 1));
          }
        }
      }
    }
    return ans * ans;
  }
}

[TestFixture]
public class MonoStackSolutionTests
{
  [Test]
  public void Test1()
  {
    new MonoStackSolution().MaximalSquare([
      ['1', '0', '1', '0', '0'],
      ['1', '0', '1', '1', '1'],
      ['1', '1', '1', '1', '1'],
      ['1', '0', '0', '1', '0']
    ]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new MonoStackSolution().MaximalSquare([
      ['0', '1'],
      ['1', '0']
    ]).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new MonoStackSolution().MaximalSquare([['0']]).Should().Be(0);
  }
}
