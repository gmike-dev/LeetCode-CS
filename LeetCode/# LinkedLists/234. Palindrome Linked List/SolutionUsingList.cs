namespace LeetCode.__LinkedLists._234._Palindrome_Linked_List;

public class SolutionUsingList
{
  public bool IsPalindrome(ListNode head)
  {
    var list = new List<int>();
    for (var node = head; node != null; node = node.next)
      list.Add(node.val);
    for (var i = 0; i + i < list.Count; i++)
    {
      if (list[i] != list[^(i + 1)])
        return false;
    }
    return true;
  }
}

[TestFixture]
public class SolutionUsingListTests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
    new SolutionUsingList().IsPalindrome(list).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2));
    new SolutionUsingList().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1, new ListNode(0, new ListNode(0)));
    new SolutionUsingList().IsPalindrome(list).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1);
    new SolutionUsingList().IsPalindrome(list).Should().BeTrue();
  }
}
