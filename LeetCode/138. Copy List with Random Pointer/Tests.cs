namespace LeetCode._138._Copy_List_with_Random_Pointer;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list = new List<Node> { new(0), new(1), new(2), new(3) };
    list[2].random = list[0];
    list[1].random = list[3];
    new Solution().CopyRandomList(list[0]).Should().NotBeSameAs(list[0]).And.BeEquivalentTo(list[0]);
  }

  [Test]
  public void Test2()
  {
    new Solution().CopyRandomList(null).Should().BeNull();
  }

  [Test]
  public void Test3()
  {
    var list = new List<Node> { new(0) };
    list[0].random = list[0];
    var result = new Solution().CopyRandomList(list[0]);
    result.Should().NotBeSameAs(list[0]);
    result.random.Should().BeSameAs(result);
  }
}
