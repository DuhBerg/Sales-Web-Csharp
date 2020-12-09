using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() ||
               _context.Seller.Any() ||
               _context.SalesRecord.Any())
            {
                return; //BANCO DE DADOS JÁ POPULADO
            }


            Department d1 = new Department(1, "Computer");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "João", "jao@gmail.com", new DateTime(1990, 4, 20), 1000.0, d1);
            Seller s2 = new Seller(2, "marcos", "jcelso@gmail.com", new DateTime(1990, 1, 2), 1030.0, d2);
            Seller s3 = new Seller(3, "berg", "berg@gmail.com", new DateTime(2002, 2, 26), 1040.0, d3);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 9, 20), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020, 9, 20), 12000.0, SaleStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2020, 9, 20), 13000.0, SaleStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2020, 9, 20), 141000.0, SaleStatus.Billed, s1);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2020, 9, 20), 1111000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3);

            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5);

            _context.SaveChanges();

        }
    }
}
