using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Identity.Models;

namespace TCC.Identity
{
    public class TccIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public TccIdentityDbContext(DbContextOptions<TccIdentityDbContext> options):base(options)
        {

        }
    }
}
