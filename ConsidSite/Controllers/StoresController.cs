using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidSite.Models.Services;
using ConsidSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsidSite.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresService _storesService;
        private readonly ICompaniesService _companiesService;

        public StoresController(IStoresService storesService, ICompaniesService companiesService)
        {
            _storesService = storesService;
            _companiesService = companiesService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            StoreIndexViewModel stores = new StoreIndexViewModel();
            stores.StoreList = _storesService.All();

            return View(stores);
        }

        public IActionResult Create()
        {
            CreateStoreViewModel ccvm = new CreateStoreViewModel();

            ccvm.CompanyList = _companiesService.All();

            return View(ccvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStoreViewModel createStoreViewModel)
        {
            Companies company = _companiesService.FindBy(createStoreViewModel.Company.Id);

            createStoreViewModel.CompanyId = company.Id;

            if (ModelState.IsValid)
            {
                _storesService.Add(createStoreViewModel);

                return RedirectToAction(nameof(Index));
            }

            createStoreViewModel.CompanyList = _companiesService.All();

            return View(createStoreViewModel);
        }
    }
}
