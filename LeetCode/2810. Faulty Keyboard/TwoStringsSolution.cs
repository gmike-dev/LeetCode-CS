namespace LeetCode._2810._Faulty_Keyboard;

public class TwoStringsSolution
{
  public string FinalString(string s)
  {
    var front = new List<char>();
    var back = new List<char>();
    foreach (var c in s)
    {
      if (c is 'i')
        (front, back) = (back, front);
      else
        front.Add(c);
    }
    back.Reverse();
    back.AddRange(front);
    return new string(back.ToArray());
  }
}
