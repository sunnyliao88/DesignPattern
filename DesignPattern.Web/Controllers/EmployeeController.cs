using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DesignPattern.Web.DataModels;
using DesignPattern.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace DesignPattern.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly ISaleRepository _saleRepository;

        public EmployeeController(IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Product> productRepository,
            ISaleRepository saleRepository
            )
        {
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }
        public IActionResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            model.Employee = await _employeeRepository.GetById(id);
            model.Products = _productRepository.GetAll();
            model.Sales = _saleRepository.GetTotalSalesByEmployeeId(id);
            return View(model);
        }

        public async Task<IActionResult> Sell(int id, int productID)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();

            model.Employee = await _employeeRepository.GetById(id);

            Sale sale = new Sale
            {
                ProductID = productID,
                EmployeeID = id,
                SaleData = DateTime.Now,
                Count = 1
            };
            await _saleRepository.Insert(sale);
            model.Sales = _saleRepository.GetTotalSalesByEmployeeId(id);

            Product product = await _productRepository.GetById(productID);
            product.Stock--;
            await _productRepository.Update(product);
            model.Products = _productRepository.GetAll();

            return View("Details", model);
        }

    }
}
