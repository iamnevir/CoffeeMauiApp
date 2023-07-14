using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMauiApp.Models;

public class Coffee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Rate { get; set; }

    public string With { get; set; }
    public string  Image { get; set; }

}
public class Category
{
    public string Name { get; set; }
    public int Id { get; set; }
}