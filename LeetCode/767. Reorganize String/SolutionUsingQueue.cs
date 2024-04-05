namespace LeetCode._767._Reorganize_String;

public class SolutionUsingQueue
{
  public string ReorganizeString(string s)
  {
    var count = new int[26];
    foreach (var c in s)
      count[c - 'a']++;

    var q = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
    for (var i = 0; i < 26; i++)
      if (count[i] > 0)
        q.Enqueue((char)('a' + i), count[i]);

    var result = new StringBuilder();

    while (q.Count > 1)
    {
      var c1 = q.Dequeue();
      var c2 = q.Dequeue();
      result.Append(c1);
      result.Append(c2);
      if (--count[c1 - 'a'] > 0)
        q.Enqueue(c1, count[c1 - 'a']);
      if (--count[c2 - 'a'] > 0)
        q.Enqueue(c2, count[c2 - 'a']);
    }

    if (q.Count == 0)
      return result.ToString();

    var last = q.Dequeue();
    if (count[last - 'a'] > 1)
      return "";

    if (result.Length > 0 && result[^1] == last)
      return "";

    result.Append(last);
    return result.ToString();
  }
}
