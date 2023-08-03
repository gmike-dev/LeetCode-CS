using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._17._Letter_Combinations_of_a_Phone_Number;

public class Solution
{
  public IList<string> LetterCombinations(string digits)
  {
    if (digits.Length == 0)
      return Array.Empty<string>();
    return new LetterCombinationGenerator(digits).Generate().ToArray();
  }

  private class LetterCombinationGenerator
  {
    private static readonly string[] Letters =
    {
      "", "abc", "def",
      "ghi", "jkl", "mno",
      "pqrs", "tuv", "wxyz"
    };
    
    private readonly string _digits;
    private readonly char[] _buffer;

    public IEnumerable<string> Generate()
    {
      return Generate(0);
    }
    
    private IEnumerable<string> Generate(int i)
    {
      foreach (var d in Letters[_digits[i] - '1'])
      {
        _buffer[i] = d;
        if (i + 1 < _digits.Length)
        {
          foreach (var s in Generate(i + 1))
            yield return s;
        }
        else
        {
          yield return new string(_buffer);
        }
      }
    }
    
    public LetterCombinationGenerator(string digits)
    {
      _digits = digits;
      _buffer = new char[_digits.Length];
    }
  }
}