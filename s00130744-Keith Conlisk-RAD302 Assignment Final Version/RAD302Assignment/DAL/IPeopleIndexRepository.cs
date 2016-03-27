using RAD302Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Assignment.DAL
{
    public interface IPeopleIndexRepository : IDisposable
    {
        List<PeopleIndex> GetAllPeopleIndex();
        PeopleIndex GetPeopleIndexByID(int peopleIndexID);

        void InsertPeopleIndex(PeopleIndex peopleIndex);
        void UpdatePeopleIndex(PeopleIndex peopleIndex);
        void DeletePeopleIndex(int peopleIndexID);

        void save();

    }
}
