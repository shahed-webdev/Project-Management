using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.BusinessLogic
{
    public interface IDonorCore
    {
        DbResponse Add(DonorAddModel model);
        DbResponse<List<DonorViewModel>> List();
        DbResponse<List<DDL>> Ddl();
        Task<DbResponse<ICollection<DonorViewModel>>> SearchAsync(string key);
    }
}