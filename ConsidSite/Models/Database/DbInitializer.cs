using System;
using System.Linq;
using ConsidSite.Models.Services;
using ConsidSite.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ConsidSite.Models.Database
{
    public class DbInitializer
    {
        internal static void Initialize(ConsidDBContext considDBContext)
        {
            considDBContext.Database.Migrate();

            if (considDBContext.Companies.Any())
            {
                return;
            }
            else
            {
                Companies companyOne = new Companies()
                {
                    Name = "CompanyOne",
                    OrganizationNumber = 1000000000,
                    Notes = null
                };

                Companies companyTwo = new Companies()
                {
                    Name = "CompanyTwo",
                    OrganizationNumber = 2000000000,
                    Notes = null
                };

                considDBContext.Companies.Add(companyOne);
                considDBContext.SaveChanges();

                considDBContext.Companies.Add(companyTwo);
                considDBContext.SaveChanges();

                if (considDBContext.Stores.Any())
                {
                    return;
                }
                else
                {
                    Companies firstCompany = considDBContext.Companies.First(n => n.Name == companyOne.Name);

                    Companies secondCompany = considDBContext.Companies.First(n => n.Name == companyTwo.Name);

                    Stores storeOne = new Stores()
                    {
                        CompanyId = firstCompany.Id,
                        Name = "StoreOne",
                        Address = "AddressOne",
                        City = "CityOne",
                        Zip = "ZipOne",
                        Country = "CountryOne",
                        Longitude = null,
                        Latitude = null
                    };

                    considDBContext.Stores.Add(storeOne);
                    considDBContext.SaveChanges();

                    Stores storeTwo = new Stores()
                    {
                        CompanyId = secondCompany.Id,
                        Name = "StoreTwo",
                        Address = "AddressTwo",
                        City = "CityTwo",
                        Zip = "ZipTwo",
                        Country = "CountryTwo",
                        Longitude = null,
                        Latitude = null
                    };

                    considDBContext.Stores.Add(storeTwo);
                    considDBContext.SaveChanges();
                }
            }
        }
    }
}
