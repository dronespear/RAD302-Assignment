using RAD302Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Assignment.DAL
{
    public class PeopleIndexRepositorty : IPeopleIndexRepository, IDisposable
    {
        InfomationContext context;

        public PeopleIndexRepositorty(InfomationContext context)
        {
            this.context = context;
        }

        public List<PeopleIndex> GetAllPeopleIndex()
        {
            return context.People.ToList();
        }

        public PeopleIndex GetPeopleIndexByID(int peopleIndexID)
        {
            return context.People.Find(peopleIndexID);
        }

        public void InsertPeopleIndex(PeopleIndex peopleIndex)
        {
            context.People.Add(peopleIndex);
        }

        public void UpdatePeopleIndex(PeopleIndex peopleIndex)
        {
            context.Entry(peopleIndex).State = EntityState.Modified;
        }

        public void DeletePeopleIndex(int peopleIndexID)
        {
            var peopleInd = context.People.Find(peopleIndexID);
            context.People.Remove(peopleInd);

            //or context.People.Remove(context.People.Find(peopleIndexID));
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
