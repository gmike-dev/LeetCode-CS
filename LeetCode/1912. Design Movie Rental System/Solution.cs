namespace LeetCode._1912._Design_Movie_Rental_System;

public class MovieRentingSystem
{
  private readonly Dictionary<int, SortedSet<(int price, int shop)>> unrented = new();
  private readonly SortedSet<(int price, int shop, int movie)> rented = new();
  private readonly Dictionary<(int shop, int movie), int> moviePrice = new();

  public MovieRentingSystem(int n, int[][] entries)
  {
    foreach (var entry in entries)
    {
      var (shop, movie, price) = (entry[0], entry[1], entry[2]);
      if (unrented.TryGetValue(movie, out var set))
        set.Add((price, shop));
      else
        unrented[movie] = [(price, shop)];
      moviePrice[(shop, movie)] = price;
    }
  }

  public IList<int> Search(int movie)
  {
    if (!unrented.TryGetValue(movie, out var shops))
      return [];
    return shops.Take(5).Select(item => item.shop).ToArray();
  }

  public void Rent(int shop, int movie)
  {
    var price = moviePrice[(shop, movie)];
    rented.Add((price, shop, movie));
    unrented[movie].Remove((price, shop));
  }

  public void Drop(int shop, int movie)
  {
    var price = moviePrice[(shop, movie)];
    rented.Remove((price, shop, movie));
    unrented[movie].Add((price, shop));
  }

  public IList<IList<int>> Report()
  {
    return rented.Take(5).Select(m => new[] { m.shop, m.movie }).ToArray();
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var movieRentingSystem =
      new MovieRentingSystem(3, [[0, 1, 5], [0, 2, 6], [0, 3, 7], [1, 1, 4], [1, 2, 7], [2, 1, 5]]);
    movieRentingSystem.Search(1).Should().BeEquivalentTo([1, 0, 2], o => o.WithStrictOrdering());
    movieRentingSystem.Rent(0, 1);
    movieRentingSystem.Rent(1, 2);
    movieRentingSystem.Report().Should().BeEquivalentTo(new int[][] { [0, 1], [1, 2] });
    movieRentingSystem.Drop(1, 2);
    movieRentingSystem.Search(2).Should().BeEquivalentTo([0, 1]);
  }
}
