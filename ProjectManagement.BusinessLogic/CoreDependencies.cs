using AutoMapper;
using ProjectManagement.Repository;

namespace ProjectManagement.BusinessLogic
{
    public class CoreDependencies
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _db;
        public CoreDependencies(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;
        }
    }
}