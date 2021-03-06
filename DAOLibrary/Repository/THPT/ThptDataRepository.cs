using DAOLibrary.DataAccess.THPT;
using DTOLibrary.THPT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAOLibrary.Repository.THPT
{
    public class ThptDataRepository : IThptDataRepository
    {
        public async Task<ThptData> GetTHPTData(string code, int year)
            => await ThptDataDAO.Instance.GetThptData(code, year);

        public List<Quotes> GetQuotes() => ThptDataDAO.Instance.GetQuotes();
        public ScheduleJson GetSchedule() => ThptDataDAO.Instance.GetSchedule();
    }
}
