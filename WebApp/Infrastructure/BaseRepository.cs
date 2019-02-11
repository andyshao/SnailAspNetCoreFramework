﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using WebApp.Entity;
using WebApp.Enum;

namespace WebApp.Infrastructure
{
    public class BaseRepository<T> where T:BaseEntity
    {
        public DatabaseContext db;

        public BaseRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public List<T> AllValid()
        {
            return db.Set<T>().Where(a => a.IsValid == (int) ValidOrNot.Valid).ToList();
        }

        public List<T> All()
        {
            return db.Set<T>().ToList();
        }

        public T FirstOrDefault(Expression<Func<T,bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public List<T> Where(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }
        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }
        public void SetInvalid(int id)
        {
            var entity=db.Set<T>().FirstOrDefault(a => a.Id == id);
            if (entity != null)
            {
                entity.IsValid = (int) ValidOrNot.Invalid;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity=db.Set<T>().FirstOrDefault(a => a.Id == id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public void Update(object dto,int id)
        {
            var entity = db.Set<T>().FirstOrDefault(a => a.Id == id);
            if (entity != null)
            {
                Mapper.Map(dto, entity);
            }
            db.SaveChanges();
        }
    }
}
