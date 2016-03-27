using RAD302Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Assignment.DAL
{
    public interface IPersonInfoRepository : IDisposable
    {
        List<PersonInfo> GetAllPersonInfo();
        PersonInfo GetPersonInfoByID(int PersonInfoID);

        void InsertPersonInfo(PersonInfo personInfo);
        void UpdatePersonInfo(PersonInfo personInfo);
        void DeletePersonInfo(int PersonInfoID);

        void save();
    }
}
