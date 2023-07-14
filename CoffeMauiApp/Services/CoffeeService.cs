using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMauiApp.Services;

public class CoffeeService
{
    private static List<Coffee> _coffees = new()
    {
        new Coffee()
        {
            Id = 1,
            Name = "Cappuccino",
            With = "With Oat Milk",
            Price = "4.20",
            Rate = "4.5",
            Description = "A cappuccino is a coffee-based drink made primarily espresso and milk",
            Image = "coffe1"
        },
        new Coffee()
        {
            Id = 2,
            Name = "Cappuccino",
            With = "With Chocolate",
            Price = "3.14",
            Rate = "4.2",
            Description = "A cappuccino is a coffee-based drink made primarily espresso and milk",
            Image = "coffe2"
        },
    };
    private static List<Category> _categories = new()
    {
        new Category() {Name = "Cappuccino", Id=1},
        new Category() {Name = "Espresso",Id=2},
        new Category() {Name = "Latte",Id=3},
        new Category() {Name = "Flat White",Id=4},
    };

    public static List<Coffee> GetCoffees() => _coffees;
    public static List<Category> GetCategories() => _categories;
    public static Coffee GetCoffeesById(int? id)
    {
        if (id != null)
        {
            return _coffees.Where(c => c.Id == id).FirstOrDefault();
        }
        return null;
    }
}
