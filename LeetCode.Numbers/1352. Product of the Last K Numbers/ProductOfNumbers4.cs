namespace LeetCode.Numbers._1352._Product_of_the_Last_K_Numbers;

public class ProductOfNumbers4
{
  private readonly List<int> prefixProduct = [1];

  public void Add(int num)
  {
    if (num == 0)
    {
      prefixProduct.Clear();
      prefixProduct.Add(1);
    }
    else
    {
      prefixProduct.Add(prefixProduct[^1] * num);
    }
  }

  public int GetProduct(int k)
  {
    if (k >= prefixProduct.Count)
      return 0;
    return prefixProduct[^1] / prefixProduct[^(k + 1)];
  }
}

[TestFixture]
public class ProductOfNumbers4Tests
{
  [Test]
  public void Test1()
  {
    var productOfNumbers = new ProductOfNumbers4();
    productOfNumbers.Add(3); // [3]
    productOfNumbers.Add(0); // [3,0]
    productOfNumbers.Add(0); // [3,0]
    productOfNumbers.Add(2); // [3,0,2]
    productOfNumbers.Add(5); // [3,0,2,5]
    productOfNumbers.Add(4); // [3,0,2,5,4]
    productOfNumbers.GetProduct(2).Should().Be(20); // return 20. The product of the last 2 numbers is 5 * 4 = 20
    productOfNumbers.GetProduct(3).Should().Be(40); // return 40. The product of the last 3 numbers is 2 * 5 * 4 = 40
    productOfNumbers.GetProduct(4).Should().Be(0); // return 0. The product of the last 4 numbers is 0 * 2 * 5 * 4 = 0
    productOfNumbers.Add(8); // [3,0,2,5,4,8]
    productOfNumbers.GetProduct(2).Should().Be(32); // return 32. The product of the last 2 numbers is 4 * 8 = 32
  }

  [Test]
  public void Test2()
  {
    var productOfNumbers = new ProductOfNumbers4();
    productOfNumbers.Add(7);
    productOfNumbers.GetProduct(1).Should().Be(7);
    productOfNumbers.GetProduct(1).Should().Be(7);
    productOfNumbers.Add(4);
    productOfNumbers.Add(5);
    productOfNumbers.GetProduct(3).Should().Be(140);
    productOfNumbers.Add(4);
    productOfNumbers.GetProduct(4).Should().Be(560);
    productOfNumbers.Add(3);
    productOfNumbers.GetProduct(4).Should().Be(240);
    productOfNumbers.Add(8);
    productOfNumbers.GetProduct(1).Should().Be(8);
    productOfNumbers.GetProduct(6).Should().Be(13440);
    productOfNumbers.Add(2);
    productOfNumbers.GetProduct(3).Should().Be(48);
  }
}
