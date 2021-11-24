using DTOLibrary.THPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.Repository.THPT
{
    public interface IThptDataRepository
    {
        public Task<ThptData> GetTHPTData(string code, int year);
    }
}
