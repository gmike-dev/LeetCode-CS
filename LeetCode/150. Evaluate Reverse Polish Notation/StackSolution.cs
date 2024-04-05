namespace LeetCode._150._Evaluate_Reverse_Polish_Notation;

public class StackSolution
{
  public int EvalRPN(string[] tokens)
  {
    var s = new Stack<int>();
    foreach (var token in tokens)
    {
      if ("+-*/".Contains(token))
      {
        var right = s.Pop();
        var left = s.Pop();
        s.Push(token switch
        {
          "+" => left + right,
          "-" => left - right,
          "*" => left * right,
          _ => left / right
        });
      }
      else
      {
        s.Push(int.Parse(token));
      }
    }
    return s.Peek();
  }
}
