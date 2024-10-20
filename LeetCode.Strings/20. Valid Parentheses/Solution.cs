namespace LeetCode.Strings._20._Valid_Parentheses;

public class Solution
{
  public bool IsValid(string s)
  {
    var stack = new Stack<char>();
    for (var i = 0; i < s.Length; i++)
    {
      if (s[i] is '(' or '[' or '{')
        stack.Push(s[i]);
      else if (stack.Count == 0 || stack.Pop() != s[i] switch { ')' => '(', ']' => '[', _ => '{' })
        return false;
    }
    return stack.Count == 0;
  }
}
