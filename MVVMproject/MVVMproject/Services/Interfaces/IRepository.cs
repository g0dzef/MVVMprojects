﻿using MVVMproject.MVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);

        void Update(int id, T item);

        bool Delete(T item);
    }
}
