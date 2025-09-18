using System.IO;
using LeetCode.Common;

namespace LeetCode._3408._Design_Task_Manager;

public class TaskManager
{
  private readonly Dictionary<int, int> taskUserId;
  private readonly Dictionary<int, int> taskPriority;
  private readonly PriorityQueue<int, (int Priority, int Id)> taskQueue;

  public TaskManager(IList<IList<int>> tasks)
  {
    taskUserId = new Dictionary<int, int>(tasks.Count);
    taskPriority = new Dictionary<int, int>(tasks.Count);
    taskQueue = new PriorityQueue<int, (int Priority, int Id)>(
      tasks.Count, Comparer<(int Priority, int Id)>.Create((x, y) => y.CompareTo(x)));
    foreach (var task in tasks)
      Add(task[0], task[1], task[2]);
  }

  public void Add(int userId, int taskId, int priority)
  {
    taskUserId[taskId] = userId;
    taskPriority[taskId] = priority;
    taskQueue.Enqueue(taskId, (priority, taskId));
  }

  public void Edit(int taskId, int newPriority)
  {
    taskPriority[taskId] = newPriority;
    taskQueue.Enqueue(taskId, (newPriority, taskId));
  }

  public void Rmv(int taskId)
  {
    taskPriority.Remove(taskId);
    taskUserId.Remove(taskId);
  }

  public int ExecTop()
  {
    while (taskQueue.TryDequeue(out var taskId, out var task))
    {
      if (taskPriority.TryGetValue(taskId, out var actualPriority) && actualPriority == task.Priority)
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
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var taskManager = new TaskManager([[1, 101, 10], [2, 102, 20], [3, 103, 15]]);
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
    var taskManager = new TaskManager([[1, 101, 8], [2, 102, 20], [3, 103, 5]]);
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
    var taskManager = new TaskManager(tasks);
    for (var i = 0; i < tasks.Count * 2; i++)
      taskManager.ExecTop();
  }
}
