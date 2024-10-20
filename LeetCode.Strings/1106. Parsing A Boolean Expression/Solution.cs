namespace LeetCode.Strings._1106._Parsing_A_Boolean_Expression;

public class Solution
{
  public bool ParseBoolExpr(ReadOnlySpan<char> expr)
  {
    return expr[0] switch
    {
      'f' => false,
      't' => true,
      '!' => !ParseBoolExpr(expr[2..^1]),
      '&' => ParseBoolExprList(expr[2..^1]).Aggregate((x, y) => x && y),
      '|' => ParseBoolExprList(expr[2..^1]).Aggregate((x, y) => x || y),
      _ => throw new InvalidOperationException()
    };
  }

  private List<bool> ParseBoolExprList(ReadOnlySpan<char> expr)
  {
    var result = new List<bool>();
    var commaPos = -1;
    var bracketsBalance = 0;
    for (var i = 0; i < expr.Length; i++)
    {
      if (expr[i] == '(')
        bracketsBalance++;
      else if (expr[i] == ')')
        bracketsBalance--;
      else if (expr[i] == ',' && bracketsBalance == 0)
      {
        result.Add(ParseBoolExpr(expr.Slice(commaPos + 1, i - commaPos - 1)));
        commaPos = i;
      }
    }
    result.Add(ParseBoolExpr(expr.Slice(commaPos + 1)));
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("&(|(f))", false)]
  [TestCase("|(f,f,f,t)", true)]
  [TestCase("!(&(f,t))", true)]
  [TestCase("&(t,t,t)", true)]
  [TestCase("&(t)", true)]
  public void Test(string expression, bool expected)
  {
    new Solution().ParseBoolExpr(expression).Should().Be(expected);
  }
}
