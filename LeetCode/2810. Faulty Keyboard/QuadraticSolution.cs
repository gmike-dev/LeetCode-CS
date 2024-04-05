namespace LeetCode._2810._Faulty_Keyboard;

public class QuadraticSolution
{
  public string FinalString(string s)
  {
    var a = new char[s.Length];
    var len = 0;
    foreach (var c in s)
    {
      if (c is 'i')
        a.AsSpan(0, len).Reverse();
      else
        a[len++] = c;
    }
    return new string(a.AsSpan(0, len));
  }
}
