namespace LeetCode._2512._Reward_Top_K_Students;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new LinqSolution().TopStudents(
        new[] { "smart", "brilliant", "studious" },
        new[] { "not" },
        new[] { "this student is studious", "the student is smart" },
        new[] { 1, 2 }, 2)
      .Should()
      .BeEquivalentTo(new[] { 1, 2 }, o => o.WithStrictOrdering());
    new QueueSolution().TopStudents(
        new[] { "smart", "brilliant", "studious" },
        new[] { "not" },
        new[] { "this student is studious", "the student is smart" },
        new[] { 1, 2 }, 2)
      .Should()
      .BeEquivalentTo(new[] { 1, 2 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new LinqSolution().TopStudents(
        new[] { "smart", "brilliant", "studious" },
        new[] { "not" },
        new[] { "this student is not studious", "the student is smart" },
        new[] { 1, 2 }, 2)
      .Should()
      .BeEquivalentTo(new[] { 2, 1 }, o => o.WithStrictOrdering());
    new QueueSolution().TopStudents(
        new[] { "smart", "brilliant", "studious" },
        new[] { "not" },
        new[] { "this student is not studious", "the student is smart" },
        new[] { 1, 2 }, 2)
      .Should()
      .BeEquivalentTo(new[] { 2, 1 }, o => o.WithStrictOrdering());
  }
}
