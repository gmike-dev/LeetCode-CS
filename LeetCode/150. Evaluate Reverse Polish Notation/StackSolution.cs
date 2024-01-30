namespace LeetCode._150._Evaluate_Reverse_Polish_Notation;

public class StackSolution
{
  public int EvalRPN(string[] tokens)
  {
    return Eval(tokens.Length - 1, out _);
    
    int Eval(int pos, out int next)
    {
      if ("+-*/".Contains(tokens[pos]))
      {
        var right = Eval(pos - 1, out next);
        var left = Eval(next, out next);
        return tokens[pos] switch
        {
          "+" => left + right,
          "-" => left - right,
          "*" => left * right,
          _ => left / right
        };
      }
      next = pos - 1;
      return int.Parse(tokens[pos]);
    }
  }
}