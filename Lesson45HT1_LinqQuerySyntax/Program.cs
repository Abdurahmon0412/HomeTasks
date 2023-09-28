//- o'sha querydan berilgan userni Id si bo'yicha sotib olingan barcha product nomlarini distinct qilib chiqaring
using Lesson45HT1_LinqQuerySyntax.Models;
using System.Text.Json;

var random = new Random();


var users = new List<User>
{
    new User("MuhammadQodir"),
    new User("Boynazar"),
    new User("Asadbek")
};

var orders = new List<Order>
{
    new Order(2500,users[random.Next(3)].Id),
    new Order(5614, users[random.Next(3)].Id),
    new Order(15334152, users[random.Next(3)].Id),
    new Order(5958790, users[random.Next(3)].Id),
    new Order(54015040, users[random.Next(3)].Id),
    new Order(814104, users[random.Next(3)].Id),
    new Order(84984, users[random.Next(3)].Id),
};

var products = new List<Product>
{
    new Product("Cola", 110002),
    new Product("Pepsi", 699529),
    new Product("RC", 8920),
    new Product("Fanta ", 65015),
    new Product("Hyderolify", 8901),
    new Product("Asy", 890),
    new Product("suv", 9084965),
};

var orderProducts = new List<OrderProduct>
{
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,98),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,9858),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,4151),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,84904),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,15601),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,18018541),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,4804),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,48418141),
    new OrderProduct(products[random.Next(products.Count)].Id, orders[random.Next(orders.Count)].Id,405418),
};

var userId = users[random.Next(3)].Id;

var result =
    from user in users
    join order in orders on user.Id equals order.UserId
    join orderProduct in orderProducts on order.Id equals orderProduct.OrderId
    join product in products on orderProduct.ProductId equals product.Id
    where user.Id == userId
    select product.Name;

var distictResult = result.ToList().Distinct().ToList();
distictResult.ForEach(Console.WriteLine);
