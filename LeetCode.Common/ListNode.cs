// ReSharper disable InconsistentNaming

namespace LeetCode.Common;

public class ListNode(int val = 0, ListNode next = null)
{
  public int val = val;
  public ListNode next = next;

  public override string ToString()
  {
    return val.ToString();
  }

  public static ListNode FromString(string s)
  {
    s = s.Trim('[', ']');
    if (string.IsNullOrWhiteSpace(s))
      return null;
    var head = new ListNode();
    var curr = head;
    foreach (var x in s.Split(','))
      curr = curr.next = new ListNode(int.Parse(x));
    return head.next;
  }

  public static string ToString(ListNode root)
  {
    if (root is null)
      return "[]";
    var list = new List<int>();
    while (root != null)
    {
      list.Add(root.val);
      root = root.next;
    }
    return $"[{string.Join(",", list)}]";
  }
}

[TestFixture]
public class ListNodeTests
{
  [Test]
  public void FromStringTest1()
  {
    var expected = new ListNode(1, new ListNode(2, new ListNode(-3, new ListNode(3, new ListNode(1)))));
    ListNode.FromString("[1,2,-3,3,1]").Should().BeEquivalentTo(expected);
  }

  [Test]
  public void FromStringTest2()
  {
    var expected = new ListNode(1);
    ListNode.FromString("[1]").Should().BeEquivalentTo(expected);
  }

  [Test]
  public void FromStringTest_EmptyList()
  {
    ListNode.FromString("[]").Should().BeNull();
  }

  [Test]
  public void ToStringTest1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(-3, new ListNode(3, new ListNode(1)))));
    ListNode.ToString(list).Should().Be("[1,2,-3,3,1]");
  }

  [Test]
  public void ToStringTest2()
  {
    var list = new ListNode(1);
    ListNode.ToString(list).Should().Be("[1]");
  }

  [Test]
  public void ToStringTest_EmptyList()
  {
    ListNode.ToString(null).Should().Be("[]");
  }
}
