using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }


        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}