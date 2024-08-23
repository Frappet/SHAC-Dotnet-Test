// Models/Customer.cs
namespace customerTest.Models
{
  public class Customer
  {
    public string Id { get; set; } = Guid.NewGuid().ToString(); // Gen id uniqe
    public string Name { get; set; }
  }
}
