using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Models;

public partial class EmpDbContext : DbContext
{
    public EmpDbContext(DbContextOptions<EmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

   
}
