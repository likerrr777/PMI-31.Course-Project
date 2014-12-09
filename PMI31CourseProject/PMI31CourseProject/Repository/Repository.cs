﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using System.Linq.Expressions;
using ProjectDatabase;

namespace PMI31CourseProject.Repository
{
    public class Repository<T> where T: class
    {
        private Course_ProjectEntities dataContext;
        private DbSet<T> dbSet;

        public Repository(Course_ProjectEntities context)
        {
            this.dataContext = context;
            this.dbSet = context.Set<T>();
        }

        public virtual void Add(T element)
        {
            this.dbSet.Add(element);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicat)
        {
            return dbSet.Where(predicat).ToList();
        }
    }
}
