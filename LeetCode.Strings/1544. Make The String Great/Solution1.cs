namespace LeetCode.Strings._1544._Make_The_String_Great;

/// <summary>
/// https://leetcode.com/problems/make-the-string-great/
/// </summary>
public class Solution1
{
  public string MakeGood(string s)
  {
    var stack = new Stack<char>();
    foreach (var c in s)
    {
      if (stack.TryPeek(out var prev) &&
          char.ToLower(prev) == char.ToLower(c) &&
          char.IsLower(prev) != char.IsLower(c))
      {
        stack.Pop();
      }
      else
      {
        stack.Push(c);
      }
    }
    return new string(stack.Reverse().ToArray());
  }
}
