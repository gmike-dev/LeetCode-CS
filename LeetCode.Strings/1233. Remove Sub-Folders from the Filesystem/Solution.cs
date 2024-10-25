namespace LeetCode.Strings._1233._Remove_Sub_Folders_from_the_Filesystem;

public class Solution
{
  public IList<string> RemoveSubfolders(string[] folders)
  {
    var root = new Folder("/");
    foreach (var path in folders)
    {
      var current = root;
      var names = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
      foreach (var name in names)
      {
        if (current.Path != null)
          break;
        var subFolder = current.SubFolders.FirstOrDefault(f => f.Name == name);
        if (subFolder == null)
        {
          subFolder = new Folder(name);
          current.SubFolders.Add(subFolder);
        }
        current = subFolder;
      }
      current.Path ??= path;
      current.SubFolders.Clear();
    }

    var result = new List<string>();
    Dfs(root);
    return result;

    void Dfs(Folder folder)
    {
      if (folder.Path != null)
      {
        result.Add(folder.Path);
      }
      else
      {
        foreach (var subFolder in folder.SubFolders)
          Dfs(subFolder);
      }
    }
  }

  private class Folder(string name)
  {
    public string Name { get; } = name;
    public string Path { get; set; }
    public List<Folder> SubFolders { get; } = [];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" }, new[] { "/a", "/c/d", "/c/f" })]
  [TestCase(new[] { "/a", "/a/b/c", "/a/b/d" }, new[] { "/a" })]
  [TestCase(new[] { "/a/b/c", "/a/b/ca", "/a/b/d" }, new[] { "/a/b/c", "/a/b/ca", "/a/b/d" })]
  public void Test(string[] folder, string[] expected)
  {
    new Solution().RemoveSubfolders(folder).Should().BeEquivalentTo(expected);
  }
}
