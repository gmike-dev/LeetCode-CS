namespace LeetCode._341._Flatten_Nested_List_Iterator;

public class NestedIterator
{
  private readonly IEnumerator<int> _enumerator;
  private bool _hasNext;

  public NestedIterator(IList<NestedInteger> nestedList)
  {
    _enumerator = Iterate(nestedList).GetEnumerator();
    _hasNext = _enumerator.MoveNext();
  }

  public bool HasNext()
  {
    return _hasNext;
  }

  public int Next()
  {
    var result = _enumerator.Current;
    _hasNext = _enumerator.MoveNext();
    return result;
  }

  private static IEnumerable<int> Iterate(IEnumerable<NestedInteger> list)
  {
    foreach (var item in list)
    {
      if (item.IsInteger())
      {
        yield return item.GetInteger();
      }
      else
      {
        foreach (var nestedInt in Iterate(item.GetList()))
          yield return nestedInt;
      }
    }
  }
}
