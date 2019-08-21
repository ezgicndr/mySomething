using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository
    {
        SomethingEntities ctx;
        User usr;
        public UserRepository()
        {
            ctx = new SomethingEntities();
            usr = new User();
        }

        public void Add(User entity)
        {
            
            entity.IsDeleted = false;
            ctx.Users.Add(entity);
            ctx.SaveChanges();
        }
        public List<User> Listele()
        {
            return ctx.Users.ToList();
        }

        public void Delete(int id)
        {
            usr = ctx.Users.Find(id);
            ctx.Users.Remove(usr);
            ctx.SaveChanges();
        }

        public User Find(int id)
        {
            usr=ctx.Users.Find(id);
            return usr;
        }
        public void Update(User usr)
        {
            usr.CreateDate = DateTime.Now;
            ctx.Entry(usr).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
