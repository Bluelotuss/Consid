using System;
using System.Linq;
using System.Threading.Tasks;
using ConsidSite.Models.Services;
using ConsidSite.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
                    Name = "Consid",
                    OrganizationNumber = 1000000000,
                    Notes = null
                };

                Companies companyTwo = new Companies()
                {
                    Name = "Ikea",
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
                    Companies firstCompany = considDBContext.Companies.FirstAsync(n => n.Name == companyOne.Name).Result;

                    Companies secondCompany = considDBContext.Companies.FirstAsync(n => n.Name == companyTwo.Name).Result;

                    Stores storeOne = new Stores()
                    {
                        CompanyId = firstCompany.Id,
                        Name = "Consid Ljungby",
                        Address = "Stationsgatan 2",
                        City = "Ljungby",
                        Zip = "34160",
                        Country = "Sweden",
                        Longitude = "13.9333705",
                        Latitude = "56.8322943"
                    };

                    considDBContext.Stores.Add(storeOne);
                    considDBContext.SaveChanges();

                    Stores storeTwo = new Stores()
                    {
                        CompanyId = secondCompany.Id,
                        Name = "Ikea Älmhult",
                        Address = "Handelsvägen 4",
                        City = "Älmhult",
                        Zip = "34333",
                        Country = "Sweden",
                        Longitude = "14.1627694",
                        Latitude = "56.5501213"
                    };

                    considDBContext.Stores.Add(storeTwo);
                    considDBContext.SaveChanges();
                }
            }
        }
    }
}
