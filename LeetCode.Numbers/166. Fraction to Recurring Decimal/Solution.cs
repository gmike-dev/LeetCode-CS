namespace LeetCode.Numbers._166._Fraction_to_Recurring_Decimal;

public class Solution
{
  public string FractionToDecimal(int numerator, int denominator)
  {
    if (numerator == 0)
      return "0";

    var result = new StringBuilder();
    if ((numerator > 0) != (denominator > 0))
      result.Append('-');
    var num = Math.Abs((long)numerator);
    var denom = Math.Abs((long)denominator);
    result.Append(num / denom);
    var rem = num % denom;
    if (rem == 0)
      return result.ToString();

    result.Append('.');
    var reminders = new Dictionary<long, int>();
    while (rem != 0)
    {
      if (reminders.TryGetValue(rem, out var repeatingPos))
      {
        result.Insert(repeatingPos, '(');
        result.Append(')');
        break;
      }
      reminders[rem] = result.Length;

      rem *= 10;
      result.Append(rem / denom);
      rem %= denom;
    }
    return result.ToString();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(4, 33, "0.(12)")]
  [TestCase(4, 333, "0.(012)")]
  [TestCase(1, 6, "0.1(6)")]
  [TestCase(7, -12, "-0.58(3)")]
  [TestCase(0, 3, "0")]
  [TestCase(0, -3, "0")]
  [TestCase(1, 214748364,
    "0.00(000000465661289042462740251655654056577585848337359161441621040707904997124914069194026549138227660723878669455195477065427143370461252966751355553982241280310754777158628319049732085502639731402098131932683780538602845887105337854867197032523144157689601770377165713821223802198558308923834223016478952081795603341592860749337303449725)")]
  [TestCase(1, 60, "0.01(6)")]
  [TestCase(1, 600, "0.001(6)")]
  [TestCase(1, 180, "0.00(5)")]
  [TestCase(1, 999, "0.(001)")]
  [TestCase(-1, -2147483648, "0.0000000004656612873077392578125")]
  public void Test(int numerator, int denominator, string expected)
  {
    new Solution().FractionToDecimal(numerator, denominator).Should().Be(expected);
  }
}
