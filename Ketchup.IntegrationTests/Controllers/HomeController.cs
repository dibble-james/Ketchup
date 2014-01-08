// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.IntegrationTests.Controllers
{
    using System;
    using System.Web.Mvc;

    using Ketchup.Api;
    using Ketchup.Model;
    using Ketchup.Model.Product;

    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;

        public HomeController(IProductManager productManager)
        {
            this._productManager = productManager;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult AddProductAttributeType(ProductAttributeType productAttributeType)
        {
            this._productManager.CreateAttributeType(
                productAttributeType.Name,
                productAttributeType.DisplayName,
                productAttributeType.ValidationRegularExpression);

            return this.RedirectToAction("Index", "Home");
        }
    }
}