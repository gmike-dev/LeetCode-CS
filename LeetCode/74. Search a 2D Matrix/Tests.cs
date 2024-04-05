namespace LeetCode._74._Search_a_2D_Matrix;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1, 3, 5, 7 },
      new[] { 10, 11, 16, 20 },
      new[] { 23, 30, 34, 60 }
    }, 3).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1, 3, 5, 7 },
      new[] { 10, 11, 16, 20 },
      new[] { 23, 30, 34, 60 }
    }, 13).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1 },
      new[] { 3 }
    }, 0).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1 },
      new[] { 3 }
    }, 1).Should().BeTrue();
  }

  [Test]
  public void Test5()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1 },
      new[] { 3 }
    }, 3).Should().BeTrue();
  }


  [Test]
  public void Test6()
  {
    new Solution().SearchMatrix(new[]
    {
      new[] { 1, 3, 5, 7 },
      new[] { 10, 11, 16, 20 },
      new[] { 23, 30, 34, 50 }
    }, 11).Should().BeTrue();
  }
}
