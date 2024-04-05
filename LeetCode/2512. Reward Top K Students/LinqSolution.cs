namespace LeetCode._2512._Reward_Top_K_Students;

public class LinqSolution
{
  public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report,
    int[] student_id, int k)
  {
    var points = new Dictionary<string, int>();
    foreach (var word in positive_feedback)
      points[word] = 3;
    foreach (var word in negative_feedback)
      points[word] = -1;
    return report
      .Select((rep, i) => new
      {
        Points = rep.Split().Sum(w => points.GetValueOrDefault(w, 0)),
        Id = student_id[i]
      })
      .OrderByDescending(r => r.Points)
      .ThenBy(r => r.Id)
      .Select(r => r.Id)
      .Take(k)
      .ToArray();
  }
}
