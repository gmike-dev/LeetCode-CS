namespace LeetCode._844._Backspace_String_Compare;

public class BuildStringSolution
{
  public bool BackspaceCompare(string s, string t)
  {
    return Print(s).SequenceEqual(Print(t));
  }

  private static ReadOnlySpan<char> Print(string s)
  {
    var a = new char[s.Length];
    var i = 0;
    foreach (var c in s)
    {
      if (c == '#')
      {
        i = Math.Max(0, i - 1);
      }
      else
      {
        a[i] = c;
        i++;
      }
    }
    return a.AsSpan(0, i);
  }
}
