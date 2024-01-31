using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._725._Split_Linked_List_in_Parts;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    var result = new Solution().SplitListToParts(list, 5);
    result.Should().BeEquivalentTo(new ListNode[]
    {
      new(1), new(2), new(3), null, null
    });
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1,
      new ListNode(2,
        new ListNode(3,
          new ListNode(4,
            new ListNode(5,
              new ListNode(6,
                new ListNode(7,
                  new ListNode(8,
                    new ListNode(9,
                      new ListNode(10))))))))));
    var result = new Solution().SplitListToParts(list, 3);
    result.Should().BeEquivalentTo(new ListNode[]
    {
      new(1, new ListNode(2, new ListNode(3, new ListNode(4)))),
      new(5, new ListNode(6, new ListNode(7))),
      new(8, new ListNode(9, new ListNode(10)))
    });
  }

  [Test]
  public void Test3()
  {
    var result = new Solution().SplitListToParts(null, 3);
    result.Should().BeEquivalentTo(new ListNode[]
    {
      null, null, null
    });
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    var result = new Solution().SplitListToParts(list, 1);
    result.Should().BeEquivalentTo(new ListNode[]
    {
      new(1, new ListNode(2, new ListNode(3)))
    });
  }

  [Test]
  public void Test5()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    var result = new Solution().SplitListToParts(list, 3);
    result.Should().BeEquivalentTo(new ListNode[]
    {
      new(1), new(2), new(3)
    });
  }
}