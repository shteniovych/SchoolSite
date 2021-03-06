﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
    }
}
