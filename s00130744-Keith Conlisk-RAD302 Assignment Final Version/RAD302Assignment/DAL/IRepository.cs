using RAD302Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace RAD302Assignment.DAL
{
    public interface IRepository<T> : IDisposable
    {
        List<T> GetAllItems();
        T GetItemByID(int id);
    }
}