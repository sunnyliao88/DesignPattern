using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPattern.Web.DataModels;
using DesignPattern.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace DesignPattern.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;   
        private readonly IGenericRepository<Product> _productRepository;    

        public EmployeeController(IEmployeeRepository repository,  IGenericRepository<Product> productRepository)
        {
            _repository = repository;        
            _productRepository = productRepository;        
        }
        public IActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            model.Employee = await _repository.GetById(id);           
            model.Products = _productRepository.GetAll();

            return View(model);
        }

        public async Task<IActionResult> Buy(int id, int productID)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            Employee employee = await _repository.GetById(id);
            //employee.ProductID = employee.ProductID ?? productID;
            //employee.Quantity = employee.Quantity.GetValueOrDefault() + 1;
            await _repository.Update(employee);
            model.Employee = employee;

            Product product = await _productRepository.GetById(productID);
            product.Stock = product.Stock.GetValueOrDefault() - 1;
            await _productRepository.Update(product);

            model.Products = _productRepository.GetAll();

            return View("Details", model);
        }
        public async Task<IActionResult> Sell(int id)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            model.Employee = await _repository.GetById(id);

            model.Products = _productRepository.GetAll();

            return View(model);
        }
    }
}
