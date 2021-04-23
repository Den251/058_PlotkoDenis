using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApp.Controllers
{
    public class ProductsController : Controller
    {
        private ProductReader reader;

        // ВНИМАНИЕ.
        // Каждый запрос обрабатывает новый экземпляр контроллера.
        // Конструктор будет вызываться перед вызовом метода List и метода Details
        // После обработки запроса, экземпляр контроллера будет удален из памяти
        public ProductsController()
        {
            reader = new ProductReader();
        }

        public IActionResult List(string category)
        {
            List<Product> products = reader.ReadFromFile();
            if (category != null)
            {
                List<Product> returnedProducts = new List<Product>();

                foreach (var product in products)
                {
                    if (product.Category == category)
                        returnedProducts.Add(product);
                }

                return View(returnedProducts);

            }
            else
            {
                return View(products);
            }


        }

        // Products/Details/1
        public IActionResult Details(int category)
        {
            List<Product> products = reader.ReadFromFile();
            Product product = products.FirstOrDefault(x => x.Id == category);

            if (product != null)
            {
                // Возврат представления с именем Details и передача представлению экземпляра product
                // В представление доступ к экземпляру можно получить через свойство представления Model
                return View(product);
            }
            else
            {
                // Возврат ошибки 404
                return NotFound();
            }
        }
        
        
    }
}