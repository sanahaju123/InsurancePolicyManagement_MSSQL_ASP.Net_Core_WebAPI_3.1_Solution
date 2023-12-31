using InsurancePolicyManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePolicyManagement.DataLayer
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    }

}