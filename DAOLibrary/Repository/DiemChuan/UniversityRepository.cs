using DAOLibrary.DataAccess.DiemChuan;
using DTOLibrary.CrawlDiemChuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.Repository.DiemChuan
{
    public class UniversityRepository : IUniversityRepository
    {
        public List<University> GetUniversities()
            => UniversityDAO.Instance.GetUniversities();
    }
}
