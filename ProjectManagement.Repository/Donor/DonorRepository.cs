using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Repository
{
    public class DonorRepository : Repository, IDonorRepository
    {
        public DonorRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(DonorAddModel model)
        {
            var donor = _mapper.Map<Donor>(model);
            Db.Donor.Add(donor);
        }

        public bool IsExistEmail(string email)
        {
            return Db.Donor.Any(c => c.Email == email);
        }

        public List<DonorViewModel> List()
        {
            return Db.Donor
                .ProjectTo<DonorViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.Donor
                .OrderBy(p => p.Name)
                .Select(s => new DDL
                {
                    value = s.Name,
                    label = s.DonorId.ToString()
                })
                .ToList();
        }

        public async Task<ICollection<DonorViewModel>> SearchAsync(string key)
        {
            return await Db.Donor
                .Where(c => c.Name.Contains(key) || c.Email.Contains(key))
                .ProjectTo<DonorViewModel>(_mapper.ConfigurationProvider)
                .Take(5)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}