using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.Repository
{
    public interface IDonorRepository
    {
        void Add(DonorAddModel model);
        void Delete(int donorId);
        bool IsRelatedDataExist(int donorId);
        void Edit(DonorViewModel model);
        bool IsNull(int donorId);
        bool IsExistEmail(string email);
        bool IsExistEmail(string email, int updateId);
        List<DonorViewModel> List();
        List<DDL> Ddl();
        Task<ICollection<DonorViewModel>> SearchAsync(string key);

    }
}