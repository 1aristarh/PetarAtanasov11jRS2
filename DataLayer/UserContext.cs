using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class UserContext : IDB<User, int>
    {
        ExamDBContext _context;

        public UserContext(ExamDBContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<User> query = _context.Users.AsNoTrackingWithIdentityResolution();
                return query.SingleOrDefault(g => g.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<User> query = _context.Users.AsNoTrackingWithIdentityResolution();
                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<User> query = _context.Users.AsNoTracking();
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User item, bool useNavigationProperties = false)
        {
            try
            {
                User genreFrom = Read(item.ID);

                _context.Entry(genreFrom).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Users.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(User user)
        {
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
