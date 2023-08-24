using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._68._Text_Justification;

public class Solution
{
  public IList<string> FullJustify(string[] words, int maxWidth)
  {
    var result = new List<string>();
    var lineWords = new List<string>();
    var lineLength = 0;
    foreach (var word in words)
    {
      if (lineWords.Count == 0)
      {
        lineWords.Add(word);
        lineLength = word.Length;
      }
      else if (lineLength + 1 + word.Length <= maxWidth)
      {
        lineWords.Add(word);
        lineLength += 1 + word.Length;
      }
      else
      {
        result.Add(JustifyLine(lineWords, maxWidth, false));
        lineWords.Clear();
        lineWords.Add(word);
        lineLength = word.Length;
      }
    }
    if (lineWords.Count > 0)
      result.Add(JustifyLine(lineWords, maxWidth, true));
    return result;
  }

  private static string JustifyLine(List<string> words, int totalWidth, bool lastLine)
  {
    if (words.Count == 1 || lastLine)
      return string.Join(" ", words).PadRight(totalWidth);

    var totalSpaces = totalWidth - words.Sum(w => w.Length);
    var delimitersLeft = words.Count - 1;
    var result = new StringBuilder(totalWidth);
    result.Append(words[0]);
    for (var i = 1; i < words.Count; i++)
    {
      var spaces = (totalSpaces + delimitersLeft - 1) / delimitersLeft;
      result.Append(new string(' ', spaces));
      result.Append(words[i]);
      totalSpaces -= spaces;
      delimitersLeft--;
    }
    return result.ToString();
  }
}