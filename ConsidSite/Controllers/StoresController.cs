using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidSite.Models;
using ConsidSite.Models.Services;
using ConsidSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConsidSite.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresService _storesService;
        private readonly ICompaniesService _companiesService;
        private readonly AppSecrets _appConfig;

        public StoresController(IStoresService storesService, ICompaniesService companiesService, IOptions<AppSecrets> optionsAccessor)
        {
            _storesService = storesService;
            _companiesService = companiesService;

            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }
            _appConfig = optionsAccessor.Value;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            StoreIndexViewModel stores = new StoreIndexViewModel();
            stores.StoreList = await _storesService.All();

            return View(stores);
        }

        public async Task<IActionResult> Create()
        {
            CreateStoreViewModel ccvm = new CreateStoreViewModel();

            ccvm.CompanyList = await _companiesService.All();

            ViewBag.API_Key = _appConfig.GoogleAPIkey;

            return View(ccvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStoreViewModel createStoreViewModel)
        {
            Companies company = await _companiesService.FindBy(createStoreViewModel.Company.Id);

            createStoreViewModel.CompanyId = company.Id;

            if (ModelState.IsValid)
            {
                await _storesService.Add(createStoreViewModel);

                return RedirectToAction(nameof(Index));
            }

            createStoreViewModel.CompanyList = await _companiesService.All();

            return View(createStoreViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Stores store = await _storesService.FindBy(id);

            CreateStoreViewModel ccvm = new CreateStoreViewModel(store);

            ccvm.CompanyList = await _companiesService.All();

            if (store == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(ccvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CreateStoreViewModel createStoreViewModel)
        {
            Companies company = await _companiesService.FindBy(createStoreViewModel.Company.Id);

            createStoreViewModel.CompanyId = company.Id;

            if (ModelState.IsValid)
            {
                if (await _storesService.Edit(id, createStoreViewModel) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Failed to edit");
            }

            return View(createStoreViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            Stores store = await _storesService.FindBy(id);

            if (store == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Guid deleteId)
        {
            if (id == deleteId)
            {
                if (await _storesService.Remove(id))
                {
                    return RedirectToAction(nameof(Index));
                }
                    ModelState.AddModelError("System", "Failed to delete");
            }

            Stores store = await _storesService.FindBy(id);

            return View(store);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            Stores store = await _storesService.FindBy(id);

            if (store == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.API_Key = _appConfig.GoogleAPIkey;

            return View(store);
        }
    }
}
