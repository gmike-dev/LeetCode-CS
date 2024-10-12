namespace LeetCode.Strings._1544._Make_The_String_Great;

public class Solution2
{
  public string MakeGood(string s)
  {
    var stack = new Stack<char>(s.Length);
    foreach (var c in s)
    {
      if (stack.TryPeek(out var prev) && Math.Abs(c - prev) == 'a' - 'A')
        stack.Pop();
      else
        stack.Push(c);
    }
    return new string(stack.Reverse().ToArray());
  }
}
