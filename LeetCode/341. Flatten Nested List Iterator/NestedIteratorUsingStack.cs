namespace LeetCode._341._Flatten_Nested_List_Iterator;

public class NestedIteratorUsingStack
{
  private readonly Stack<(IList<NestedInteger> list, int pos)> _states = new();
  private NestedInteger _currentItem;

  public NestedIteratorUsingStack(IList<NestedInteger> nestedList)
  {
    if (nestedList.Count > 0)
    {
      _states.Push((nestedList, 0));
      _currentItem = FindNextIntItem();
    }
  }

  public bool HasNext() => _currentItem != null;

  public int Next()
  {
    var result = _currentItem.GetInteger();
    _currentItem = FindNextIntItem();
    return result;
  }

  private NestedInteger FindNextIntItem()
  {
    while (_states.TryPop(out var state))
    {
      if (state.pos >= state.list.Count)
        continue;
      _states.Push((state.list, state.pos + 1));
      var item = state.list[state.pos];
      if (item.IsInteger())
        return item;
      _states.Push((item.GetList(), 0));
    }
    return null;
  }
}
