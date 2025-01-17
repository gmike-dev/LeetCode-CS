using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace LeetCode.Numbers._2683._Neighboring_Bitwise_XOR;

public class FastSumSolution
{
  public bool DoesValidArrayExist(int[] derived)
  {
    return FastSumArray(derived) % 2 == 0;
  }

  private static unsafe int FastSumArray(int[] a)
  {
    var v = Vector256<int>.Zero;
    var blockSize = Vector256<int>.Count;
    var blockCount = a.Length / blockSize;
    fixed (int* p = &a[0])
    {
      for (int i = 0; i < blockCount; i++)
        v = Avx2.Add(v, Avx.LoadVector256(p + i * blockSize));
    }
    var temp = stackalloc int[blockSize];
    Avx.Store(temp, v);
    var result = 0;
    for (var i = 0; i < blockSize; i++)
      result ^= temp[i];
    for (var i = blockSize * blockCount; i < a.Length; i++)
      result ^= a[i];
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
}
