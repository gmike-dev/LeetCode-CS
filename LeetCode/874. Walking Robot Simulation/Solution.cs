namespace LeetCode._874._Walking_Robot_Simulation;

public class Solution
{
  public int RobotSim(int[] commands, int[][] obstacles)
  {
    var obstaclesSet = obstacles.Select(o => (o[0], o[1])).ToHashSet();
    var dx = new[] { 0, 1, 0, -1 };
    var dy = new[] { 1, 0, -1, 0 };
    int dir = 0, posX = 0, posY = 0, maxDistance = 0;
    foreach (var command in commands)
    {
      if (command == -2)
      {
        dir = (dir + 3) % 4;
      }
      else if (command == -1)
      {
        dir = (dir + 1) % 4;
      }
      else
      {
        for (var i = 0; i < command; i++)
        {
          var next = (posX + dx[dir], posY + dy[dir]);
          if (obstaclesSet.Contains(next))
            break;
          (posX, posY) = next;
        }
        maxDistance = int.Max(maxDistance, posX * posX + posY * posY);
      }
    }
    return maxDistance;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().RobotSim([4, -1, 3], []).Should().Be(25);
  }

  [Test]
  public void Test2()
  {
    new Solution().RobotSim([4, -1, 4, -2, 4], [[2, 4]]).Should().Be(65);
  }

  [Test]
  public void Test3()
  {
    new Solution().RobotSim([6, -1, -1, 6], []).Should().Be(36);
  }
}
