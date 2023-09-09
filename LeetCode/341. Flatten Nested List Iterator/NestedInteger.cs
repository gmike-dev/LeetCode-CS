using System.Collections.Generic;

namespace LeetCode._341._Flatten_Nested_List_Iterator;

public class NestedInteger
{
  private readonly int _value;
  private readonly IList<NestedInteger> _list;

  public bool IsInteger() => _list is null;
  public int GetInteger() => _value;
  public IList<NestedInteger> GetList() => _list;

  public NestedInteger(int value) => _value = value;
  public NestedInteger(IList<NestedInteger> list) => _list = list;
}