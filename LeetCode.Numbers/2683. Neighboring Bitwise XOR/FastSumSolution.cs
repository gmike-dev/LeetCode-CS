using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace LeetCode.Numbers._2683._Neighboring_Bitwise_XOR;

public class FastSumSolution
{
  public bool DoesValidArrayExist(int[] derived)
  {
    return SumIntrinsics(derived) % 2 == 0;
  }

  public static int SumIntrinsics(ReadOnlySpan<int> a)
  {
    var vectors = MemoryMarshal.Cast<int, Vector256<int>>(a);
    var acc = Vector256<int>.Zero;
    foreach (var v in vectors)
      acc = Avx2.Add(acc, v);
    var acc2 = Sse2.Add(acc.GetLower(), acc.GetUpper());
    var result = 0;
    for (var i = 0; i < 4; i++)
      result += acc2.GetElement(i);
    for (var i = vectors.Length * Vector256<int>.Count; i < a.Length; i++)
      result += a[i];
    return result;
  }
}

[TestFixture]
public class FastSumSolutionTests
{
  [TestCase(new[] { 1, 1, 0 }, true)]
  [TestCase(new[] { 1, 1 }, true)]
  [TestCase(new[] { 1, 0 }, false)]
  [TestCase(new[] { 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0 }, true)]
  public void Test(int[] derived, bool expected)
  {
    new FastSumSolution().DoesValidArrayExist(derived).Should().Be(expected);
  }

  [Test]
  public void Test1()
  {
    FastSumSolution.SumIntrinsics([1, 2, 3, 4, 5]).Should().Be(15);
    FastSumSolution.SumIntrinsics([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]).Should().Be(55);
    FastSumSolution.SumIntrinsics([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]).Should()
      .Be(210);
  }
}
