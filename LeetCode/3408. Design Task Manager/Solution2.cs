using System.IO;
using LeetCode.Common;

namespace LeetCode._3408._Design_Task_Manager;

public class TaskManager2
{
  private const int MaxTaskId = 100000;

  private readonly int[] taskUserId;
  private readonly int[] taskPriority;
  private readonly PriorityQueue<int, (int Priority, int Id)> taskQueue;

  public TaskManager2(IList<IList<int>> tasks)
  {
    taskUserId = new int[MaxTaskId + 1];
    taskPriority = new int[MaxTaskId + 1];
    taskQueue = new PriorityQueue<int, (int Priority, int Id)>(tasks.Count);
    Array.Fill(taskUserId, -1);
    Array.Fill(taskPriority, -1);
    foreach (var task in tasks)
      Add(task[0], task[1], task[2]);
  }

  public void Add(int userId, int taskId, int priority)
  {
    taskUserId[taskId] = userId;
    taskPriority[taskId] = priority;
    taskQueue.Enqueue(taskId, (-priority, -taskId));
  }

  public void Edit(int taskId, int newPriority)
  {
    taskPriority[taskId] = newPriority;
    taskQueue.Enqueue(taskId, (-newPriority, -taskId));
  }

  public void Rmv(int taskId)
  {
    taskPriority[taskId] = -1;
    taskUserId[taskId] = -1;
  }

  public int ExecTop()
  {
    while (taskQueue.TryDequeue(out var taskId, out var item))
    {
      if (taskPriority[taskId] == -item.Priority)
      {
        var userId = taskUserId[taskId];
        Rmv(taskId);
        return userId;
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
