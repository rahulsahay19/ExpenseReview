﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReimbursementApp.Data.Contracts
{
  public interface IRepository<T> where T:class
    {
    //To query using LINQ
   
    IQueryable<T> GetAll();

    //Returning Expense
    T GetById(int id);

    //Adding Expense
    void Add(T entity);

    //Updating Expense
    void Update(T entity);

    //Deleting Expense
    void Delete(T entity);

    //Deleting Expense by id
    void Delete(int id);

}
}
