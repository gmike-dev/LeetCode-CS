namespace LeetCode.DP._1220._Count_Vowels_Permutation;

public class FastSolution
{
  public int CountVowelPermutation(int n)
  {
    long a = 1, e = 1, i = 1, o = 1, u = 1;
    const long mod = (long)1e9 + 7;
    for (var len = 2; len <= n; len++)
      (a, e, i, o, u) = (e, (a + i) % mod, (a + e + o + u) % mod, (i + u) % mod, a);
    return (int)((a + e + i + o + u) % mod);
  }
}
