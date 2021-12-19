using DTOLibrary.THPT;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAOLibrary.Repository.THPT
{
    public interface IThptDataRepository
    {
        public Task<ThptData> GetTHPTData(string code, int year);
        public List<Quotes> GetQuotes();
        public ScheduleJson GetSchedule();
    }
}
