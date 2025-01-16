namespace LeetCode.Numbers._2425._Bitwise_XOR_of_All_Pairings;

public class VectorSolution
{
  public int XorAllNums(int[] nums1, int[] nums2)
  {
    var xor1 = 0;
    if (nums2.Length % 2 != 0)
      xor1 = FastXorArray(nums1);
    var xor2 = 0;
    if (nums1.Length % 2 != 0)
      xor2 = FastXorArray(nums2);
    return xor1 ^ xor2;
  }

  private static int FastXorArray(int[] a)
  {
    var blockSize = Vector<int>.Count;
    var blockCount = a.Length / blockSize;
    var v = new Vector<int>();
    for (var i = 0; i < blockCount; i++)
      v ^= new Vector<int>(a, i * blockSize);
    var result = 0;
    for (var i = 0; i < blockSize; i++)
      result ^= v[i];
    for (var i = blockSize * blockCount; i < a.Length; i++)
      result ^= a[i];
    return result;
  }
}

[TestFixture]
public class VectorSolutionTests
{
  [TestCase(new[] { 2, 1, 3 }, new[] { 10, 2, 5, 0 }, 13)]
  [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 0)]
  [TestCase(new[] { 8, 6, 29, 2, 26, 16, 15, 29 }, new[] { 24, 12, 12 }, 9)]
  [TestCase(new[] { 8, 6, 29, 2, 26, 16, 15, 29, 19, 1, 2, 3, 4, 5, 6, 7, 8 },
    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }, 19)]
  public void Test(int[] nums1, int[] nums2, int expected)
  {
    new VectorSolution().XorAllNums(nums1, nums2).Should().Be(expected);
  }
}
