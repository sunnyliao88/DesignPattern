using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DesignPattern.Web.DataModels;
using DesignPattern.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DesignPattern.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using DesignPattern.Web.Extensions;
using System.Diagnostics;

namespace DesignPattern.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork<EmployeeDbContext> _employeeDbUnitOfWork;
        private readonly IUnitOfWork<ProductDbContext> _productDbUnitOfWork;

        public EmployeeController(IUnitOfWork<EmployeeDbContext> employeeDbUnitOfWork, IUnitOfWork<ProductDbContext> productDbUnitOfWork)
        {
            _employeeDbUnitOfWork = employeeDbUnitOfWork;
            _productDbUnitOfWork = productDbUnitOfWork;
        }
        public IActionResult Index()
        {
            var model = _employeeDbUnitOfWork.GetGenericRepository<Employee>().Get();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            model.Employee = _employeeDbUnitOfWork.GetGenericRepository<Employee>().Get().Where(e => e.EmployeeID == id).FirstOrDefault();
            model.Products = _employeeDbUnitOfWork.GetGenericRepository<Product>().Get();
            model.Sales = _employeeDbUnitOfWork.GetGenericRepository<Sale>().Get().GetTotalSalesByEmployeeId(id);

            return View(model);
        }

        public async Task<IActionResult> Sell(int id, int productID)
        {
            EmployeeDetailsVM model = new EmployeeDetailsVM();
            try
            {
                model.Employee = _employeeDbUnitOfWork.GetGenericRepository<Employee>().Get().Where(e => e.EmployeeID == id).FirstOrDefault();

                Sale sale = new Sale
                {
                    ProductID = productID,
                    EmployeeID = id,
                    SaleData = DateTime.Now,
                    Count = 1
                };
                _employeeDbUnitOfWork.CreateTransaction();

                await _employeeDbUnitOfWork.GetGenericRepository<Sale>().Insert(sale);
                model.Sales = _employeeDbUnitOfWork.GetGenericRepository<Sale>().Get().GetTotalSalesByEmployeeId(id);

                Product product = _employeeDbUnitOfWork.GetGenericRepository<Product>().Get().Where(e => e.ProductID == productID).FirstOrDefault();
                product.Stock--;
                _employeeDbUnitOfWork.GetGenericRepository<Product>().Update(product);
                model.Products = _employeeDbUnitOfWork.GetGenericRepository<Product>().Get();
               
                _employeeDbUnitOfWork.Commit();

                //test
                var productsInproductDb = _productDbUnitOfWork.GetGenericRepository<Product>().Get();
                foreach (var p in productsInproductDb)
                { Debug.WriteLine("p--" + p.Name); }
                var productsInemployeeDb = _employeeDbUnitOfWork.GetGenericRepository<Product>().Get();
                foreach (var p in productsInemployeeDb)
                { Debug.WriteLine("e--" + p.Name); }
            }
            catch (Exception err)
            {
                _employeeDbUnitOfWork.Rollback();
            }

            return View("Details", model);
        }

    }
}
