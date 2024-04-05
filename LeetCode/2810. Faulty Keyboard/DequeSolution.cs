namespace LeetCode._2810._Faulty_Keyboard;

public class DequeSolution
{
  public string FinalString(string s)
  {
    var deque = new LinkedList<char>();
    var reverse = false;
    foreach (var c in s)
    {
      if (c is 'i')
        reverse = !reverse;
      else if (reverse)
        deque.AddFirst(c);
      else
        deque.AddLast(c);
    }
    var ch = deque.ToArray();
    if (reverse)
      ch.AsSpan().Reverse();
    return new string(ch);
  }
}
