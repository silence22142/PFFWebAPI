using Microsoft.AspNetCore.Mvc;
using PFFWebAPI.Models;

namespace PFFWebAPI.Data
{

    public class PresentData : IPresentData
    {
        private ApplicationDbContext _context;
        public PresentData(ApplicationDbContext context)
        {
            _context = context;
        }

        public Present AddPresent(Present present)
        {
            _context.Presents.Add(present);
            _context.SaveChanges();
            return present;
        }

        public void DeletePresent(Present present)
        {
            _context.Presents.Remove(present);
            _context.SaveChanges();
        }

        public Present EditPresent(Present present)
        {
            var existingPresent = _context.Presents.Find(present.Id);
            if (existingPresent != null)
            {
                _context.Presents.Update(existingPresent);
                _context.SaveChanges();
            }
            return present;
        }

        public List<Present> GetPresents()
        {
            return _context.Presents.ToList();
        }

        public Present GetPresent(int id)
        {
            var present = _context.Presents.Find(id);
            return present;
        }
    }
}