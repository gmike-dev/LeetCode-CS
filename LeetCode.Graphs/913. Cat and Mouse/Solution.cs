using LeetCode.Common;

namespace LeetCode.Graphs._913._Cat_and_Mouse;

/// <summary>
/// https://leetcode.com/problems/cat-and-mouse/
/// </summary>
public class Solution
{
  private enum Result
  {
    Unknown = 0,
    MouseWin = 1,
    CatWin = 2
  }

  /// <param name="Mouse">Mouse position</param>
  /// <param name="Cat">Cat position</param>
  /// <param name="Turn">0 = mouse turn, 1 = cat turn</param>
  private record struct State(int Mouse, int Cat, int Turn);

  public int CatMouseGame(int[][] graph)
  {
    int n = graph.Length;

    // Результаты для всех состояний
    Result[,,] results = new Result[n, n, 2];

    // Счетчик "детей" для каждого состояния (сколько возможных ходов)
    int[,,] childCount = new int[n, n, 2];
    for (int mouse = 0; mouse < n; mouse++)
    {
      for (int cat = 0; cat < n; cat++)
      {
        childCount[mouse, cat, 0] = graph[mouse].Length;
        childCount[mouse, cat, 1] = graph[cat].Length;
      }
    }
    // Особый случай: кот не может оставаться на месте в узле 0
    for (int mouse = 0; mouse < n; mouse++)
    {
      for (int cat = 0; cat < n; cat++)
      {
        foreach (int nextCat in graph[cat])
        {
          if (nextCat == 0)
          {
            childCount[mouse, cat, 1]--;
          }
        }
      }
    }

    Queue<State> queue = new Queue<State>();

    // Добавляем терминальные состояния
    // 1. Мышь в норе -> победа мыши
    for (int cat = 1; cat < n; cat++)
    {
      results[0, cat, 0] = Result.MouseWin;
      results[0, cat, 1] = Result.MouseWin;
      queue.Enqueue(new State(0, cat, 0));
      queue.Enqueue(new State(0, cat, 1));
    }
    // 2. Кот и мышь в одной позиции -> победа кота
    for (int node = 1; node < n; node++)
    {
      results[node, node, 0] = Result.CatWin;
      results[node, node, 1] = Result.CatWin;
      queue.Enqueue(new State(node, node, 0));
      queue.Enqueue(new State(node, node, 1));
    }

    // BFS распространение результатов
    while (queue.Count > 0)
    {
      State current = queue.Dequeue();
      Result currentResult = results[current.Mouse, current.Cat, current.Turn];

      // Получаем предыдущие состояния
      List<State> previousStates = GetPreviousStates(current, graph);

      foreach (State prev in previousStates)
      {
        if (results[prev.Mouse, prev.Cat, prev.Turn] != Result.Unknown)
        {
          continue;
        }

        // Если предыдущее состояние ведет к победе мыши или кота
        if ((prev.Turn == 0 && currentResult == Result.MouseWin) ||
            (prev.Turn == 1 && currentResult == Result.CatWin))
        {
          results[prev.Mouse, prev.Cat, prev.Turn] = currentResult;
          queue.Enqueue(prev);
        }
        else
        {
          // Уменьшаем счетчик возможных ходов
          childCount[prev.Mouse, prev.Cat, prev.Turn]--;

          // Если все ходы ведут к победе противника
          if (childCount[prev.Mouse, prev.Cat, prev.Turn] == 0)
          {
            results[prev.Mouse, prev.Cat, prev.Turn] =
              prev.Turn == 0 ? Result.CatWin : Result.MouseWin;
            queue.Enqueue(prev);
          }
        }
      }
    }

    // Возвращаем результат для начального состояния
    return (int)results[1, 2, 0];
  }

  private List<State> GetPreviousStates(State current, int[][] graph)
  {
    List<State> prevStates = [];

    if (current.Turn == 0)
    {
      // Был ход мыши, значит предыдущий ход кота
      foreach (int prevCat in graph[current.Cat])
      {
        // Кот не может заходить в узел 0
        if (prevCat != 0)
        {
          prevStates.Add(new State(current.Mouse, prevCat, 1));
        }
      }
    }
    else
    {
      // Был ход кота, значит предыдущий ход мыши
      foreach (int prevMouse in graph[current.Mouse])
      {
        prevStates.Add(new State(prevMouse, current.Cat, 0));
      }
    }

    return prevStates;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[2,5],[3],[0,4,5],[1,4,5],[2,3],[0,2,3]]", 0)]
  [TestCase("[[1,3],[0],[3],[0,2]]", 1)]
  public void Test(string graph, int expected)
  {
    new Solution().CatMouseGame(graph.Array2()).Should().Be(expected);
  }
}
