using JobListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.Repositories
{
    public class UserRepository :BaseRepository<Users>
    {
        public Users Login(string email, string password)
        {
            return context.Set<Users>().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}