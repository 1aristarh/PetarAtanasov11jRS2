using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class InterestContext : IDB<Interest, int>
    { 
        ExamDBContext _context;

        public InterestContext(ExamDBContext context)
        {
            _context = context;
        }

        public void Create(Interest item)
        {
            try
            {
                _context.Interests.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Interest Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests.AsNoTrackingWithIdentityResolution();
                return query.SingleOrDefault(g => g.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Interest> Read(int skip, int take, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests.AsNoTrackingWithIdentityResolution();
                return query.Skip(skip).Take(take).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Interest> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests.AsNoTracking();
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Interest item, bool useNavigationProperties = false)
        {
            try
            {
                Interest genreFrom = Read(item.ID);

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
                _context.Interests.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        
    }
}
