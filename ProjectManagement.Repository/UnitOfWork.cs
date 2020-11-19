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
            _db = db;
            _mapper = mapper;

            Registration = new RegistrationRepository(_db, _mapper);
        }

        public void Dispose()
        {
            _db.Dispose();
        }


        public IRegistrationRepository Registration { get; }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}