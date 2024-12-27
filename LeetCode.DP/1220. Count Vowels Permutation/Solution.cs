namespace LeetCode._1220._Count_Vowels_Permutation;

public class Solution
{
  public int CountVowelPermutation(int n)
  {
    const int m = 5;
    var ind = new Dictionary<int, int>(m) { ['a'] = 0, ['e'] = 1, ['i'] = 2, ['o'] = 3, ['u'] = 4 };
    var dp1 = new int[m];
    var dp2 = new int[m];
    Array.Fill(dp1, 1);
    const int mod = (int)1e9 + 7;
    for (var len = 2; len <= n; len++)
    {
      dp2[ind['a']] = dp1[ind['e']];
      dp2[ind['e']] = (dp1[ind['a']] + dp1[ind['i']]) % mod;
      dp2[ind['i']] = ((dp1[ind['a']] + dp1[ind['e']]) % mod +
                        (dp1[ind['o']] + dp1[ind['u']]) % mod) % mod;
      dp2[ind['o']] = (dp1[ind['i']] + dp1[ind['u']]) % mod;
      dp2[ind['u']] = dp1[ind['a']];

      (dp2, dp1) = (dp1, dp2);
    }
    var ans = 0;
    foreach (var x in dp1)
      ans = (ans + x) % mod;
    return ans;
  }
}
