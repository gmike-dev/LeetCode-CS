using System.Collections.Generic;
using System.Linq;

namespace LeetCode._2512._Reward_Top_K_Students;

public class QueueSolution
{
  public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report,
    int[] student_id, int k)
  {
    var points = new Dictionary<string, int>();
    foreach (var word in positive_feedback)
      points[word] = 3;
    foreach (var word in negative_feedback)
      points[word] = -1;
    var n = student_id.Length;
    var rating = new Dictionary<int, int>(n);
    for (var i = 0; i < n; i++)
      rating[student_id[i]] = report[i].Split().Sum(w => points.GetValueOrDefault(w, 0));

    var q = new PriorityQueue<int, (int, int)>(n);
    foreach (var (id, pts) in rating)
      q.Enqueue(id, (-pts, id));
    var result = new List<int>(k);
    for (var i = 0; i < k; i++)
      result.Add(q.Dequeue());
    return result;
  }
}