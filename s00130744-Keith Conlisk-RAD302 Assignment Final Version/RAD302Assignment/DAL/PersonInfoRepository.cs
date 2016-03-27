using RAD302Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAD302Assignment.DAL
{
    public class PersonInfoRepository : IPersonInfoRepository, IDisposable
    {
        InfomationContext context;

        public PersonInfoRepository(InfomationContext context)
        {
            this.context = context;
        }

        public List<PersonInfo> GetAllPersonInfo()
        {
            return context.PersonInfo.ToList();
        }

        public PersonInfo GetPersonInfoByID(int PersonInfoID)
        {
            return context.PersonInfo.Find(PersonInfoID);
        }

        public void InsertPersonInfo(PersonInfo personInfo)
        {
            context.PersonInfo.Add(personInfo);
        }

        public void UpdatePersonInfo(PersonInfo personInfo)
        {
            context.Entry(personInfo).State = EntityState.Modified;
        }

        public void DeletePersonInfo(int PersonInfoID)
        {
            var personInf = context.PersonInfo.Find(PersonInfoID);
            context.PersonInfo.Remove(personInf);

            //or context.People.Remove(context.PersonInfo.Find(PersonInfoID));
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