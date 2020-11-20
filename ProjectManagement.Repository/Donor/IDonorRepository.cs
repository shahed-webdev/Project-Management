using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Repository
{
    public interface IDonorRepository
    {
        void Add(DonorAddModel model);
        bool IsExistEmail(string email);
        List<DonorViewModel> List();
        List<DDL> Ddl();
        Task<ICollection<DonorViewModel>> SearchAsync(string key);

    }
}