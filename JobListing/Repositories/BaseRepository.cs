using JobListing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace JobListing.Repositories
{
    public class BaseRepository<T> : IDisposable where T : class, new()
    {
        protected readonly JobListingContext context = new JobListingContext();
        public bool Add(T data)
        {   //ctrl+k+s kısayoluyla try catch ekleyebiliyorsun
            try
            {
                context.Set<T>().Add(data);

                try
                {
                    return context.SaveChanges() > 0 ? true : false;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                T deletedData = context.Set<T>().Find(id);
                context.Set<T>().Remove(deletedData);
                return context.SaveChanges() > 0 ? true : false;

            }
            catch (Exception)
            {

                return true;
            }
        }
        public List<T> GetAll()
        {

            //using (context=new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {

            //using (context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public bool Update(T data)
        {
            //using (context = new Context())
            {
                context.Entry<T>(data).State = EntityState.Modified;
                int result = context.SaveChanges();
                //ternary if
                return result > 0 ? true : false;
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            //using (context=new Context())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}