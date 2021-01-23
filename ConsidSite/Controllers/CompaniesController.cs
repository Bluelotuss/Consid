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
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        // GET: CompaniesController
        public IActionResult Index()
        {
            CompanyIndexViewModel companies = new CompanyIndexViewModel();
            companies.CompanyList = _companiesService.All();

            return View(companies);
        }

        public IActionResult Create()
        {
            CreateCompanyViewModel ccvm = new CreateCompanyViewModel();

            return View(ccvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCompanyViewModel createCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                _companiesService.Add(createCompanyViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(createCompanyViewModel);
        }

        public IActionResult Edit(Guid id)
        {
            Companies company = _companiesService.FindBy(id);

            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(new CreateCompanyViewModel(company));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CreateCompanyViewModel createCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_companiesService.Edit(id, createCompanyViewModel) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Failed to edit");
            }

            return View(createCompanyViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            Companies company = _companiesService.FindBy(id);

            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, int deleteId)  // Why deleteId?
        {

            if (_companiesService.Remove(id))
            {
                return RedirectToAction(nameof(Index));
            }
                ModelState.AddModelError("System", "Failed to delete");

            Companies company = _companiesService.FindBy(id);

            return View(company);
        }

        public ActionResult Details(Guid id)
        {
            Companies company = _companiesService.FindBy(id);

            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }
    }
}
