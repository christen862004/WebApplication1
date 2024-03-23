using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHubContext<ProductHub> productHubContext;
       
        ITIContext context = new ITIContext();

        public ProductController
            (IHubContext<ProductHub> productHubContext)
        {
            this.productHubContext = productHubContext;
        }
        public IActionResult Index()
        {

            return View(context.Product.ToList());
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveNew(Product newProduct)
        {
            context.Add(newProduct);

            context.SaveChanges();
            //Notify Online ProductHub Client
            productHubContext.Clients
                .All.SendAsync("AddProductNotify", new {Id=newProduct.Id,Name=newProduct.Name});
            //productHubContext.Clients
            //  .All.SendAsync("AddProductNotify", newProduct.Id,newProduct.Name);
            //productHubContext.Clients
            //  .All.SendAsync("AddProductNotify", newProduct);
            //Servialiation to Json
            return RedirectToAction("Index");

        }
    }
}
