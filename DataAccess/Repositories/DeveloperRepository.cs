using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }

        public IEnumerable<Developer> GetAll()
        {
            return _context.Developers.Include(x=> x.Projects).ToList();
            // aici as dori un include catre lista de proiecte la care developer e leader
            // cum fac asta?
        }

    }
}
