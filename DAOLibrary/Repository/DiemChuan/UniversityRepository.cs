using DAOLibrary.DataAccess.DiemChuan;
using DTOLibrary.CrawlDiemChuan;
using System.Collections.Generic;

namespace DAOLibrary.Repository.DiemChuan
{
    public class UniversityRepository : IUniversityRepository
    {
        public List<University> GetUniversities()
            => UniversityDAO.Instance.GetUniversities();
    }
}
