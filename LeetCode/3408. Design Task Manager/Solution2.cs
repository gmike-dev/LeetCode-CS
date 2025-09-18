using System.IO;
using LeetCode.Common;

namespace LeetCode._3408._Design_Task_Manager;

public class TaskManager2
{
  private const int MaxTaskId = 100000;

  private readonly int[] taskUserId = new int[MaxTaskId + 1];
  private readonly long[] taskPriority = new long[MaxTaskId + 1];
  private readonly PriorityQueue<int, long> taskQueue = new(2 * MaxTaskId);

  public TaskManager2(IList<IList<int>> tasks)
  {
    Array.Fill(taskPriority, -1);
    foreach (var task in tasks)
      Add(task[0], task[1], task[2]);
  }

  private static long Priority(int priority, int taskId)
  {
    return -(((long)priority << 30) | (uint)taskId);
  }

  public void Add(int userId, int taskId, int priority)
  {
    var p = Priority(priority, taskId);
    taskUserId[taskId] = userId;
    taskPriority[taskId] = p;
    taskQueue.Enqueue(taskId, p);
  }

  public void Edit(int taskId, int newPriority)
  {
    var p = Priority(newPriority, taskId);
    taskPriority[taskId] = p;
    taskQueue.Enqueue(taskId, p);
  }

  public void Rmv(int taskId)
  {
    taskPriority[taskId] = -1;
  }

  public int ExecTop()
  {
    while (taskQueue.TryDequeue(out var taskId, out var priority))
    {
      if (taskPriority[taskId] == priority)
      {
        Rmv(taskId);
        return taskUserId[taskId];
      }
    }
    return -1;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    var taskManager = new TaskManager2([[1, 101, 10], [2, 102, 20], [3, 103, 15]]);
    taskManager.Add(4, 104, 5);
    taskManager.Edit(102, 8);
    taskManager.ExecTop().Should().Be(3);
    taskManager.Rmv(101);
    taskManager.Add(5, 105, 15);
    taskManager.ExecTop().Should().Be(5);
  }

  [Test]
  public void Test2()
  {
    var taskManager = new TaskManager2([[1, 101, 8], [2, 102, 20], [3, 103, 5]]);
    taskManager.Add(4, 104, 5);
    taskManager.Edit(102, 9);
    taskManager.ExecTop().Should().Be(2);
    taskManager.Rmv(101);
    taskManager.Add(50, 101, 8);
    taskManager.ExecTop().Should().Be(50);
  }

  [Test]
  public void LargeExecTopTest()
  {
    using var input = new StreamReader(@"3408. Design Task Manager/LargeExecTopTestData.txt");
    IList<IList<int>> tasks = input.ReadLine().Array2();
    var taskManager = new TaskManager2(tasks);
    for (var i = 0; i < tasks.Count * 2; i++)
      taskManager.ExecTop();
  }
}
