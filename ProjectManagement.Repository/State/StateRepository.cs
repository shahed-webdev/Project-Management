using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class StateRepository : Repository, IStateRepository
    {
        public StateRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(StateAddModel model)
        {
            var state = _mapper.Map<State>(model);
            Db.State.Add(state);
        }

        public bool IsNull(int id)
        {
            return !Db.State.Any(c => c.StateId == id);
        }

        public bool IsExist(int countryId, string state)
        {
            return Db.State.Any(c => c.CountryId == countryId && c.StateName == state);
        }

        public bool IsExist(int countryId, string state, int updateId)
        {
            return Db.State.Any(c => c.CountryId == countryId && c.StateName == state && c.StateId != updateId);
        }

        public List<StateViewModel> List(int countryId)
        {
            return Db.State
                .Where(s => s.CountryId == countryId)
                .ProjectTo<StateViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.StateName)
                .ToList();
        }

        public List<DDL> Ddl(int countryId)
        {
            return Db.State
                .Where(s => s.CountryId == countryId)
                .OrderBy(p => p.StateName)
                .Select(s => new DDL
                {
                    value = s.StateId.ToString(),
                    label = s.StateName
                })
                .ToList();
        }

        public void Edit(StateViewModel model)
        {
            var state = Db.State.Find(model.StateId);

            if (state == null) return;

            state.StateName = model.StateName;
            Db.State.Update(state);
        }
    }
}