using PFFWebAPI.Models;

namespace PFFWebAPI.Data
{
    public class FavouritesData : IFavouritesData
    {
        private ApplicationDbContext _context;
        public FavouritesData(ApplicationDbContext context)
        {
            _context = context;
        }
        public Favourites AddFavourites(Favourites favourites)
        {
            _context.Favourites.Add(favourites);
            _context.SaveChanges();
            return favourites;
        }

        public void DeleteFavourites(Favourites favourites)
        {
            _context.Favourites.Remove(favourites);
            _context.SaveChanges();
        }

        public Favourites EditFavourites(Favourites favourites)
        {
            var existingFavourites = _context.Favourites.Find(favourites.Id);
            if (existingFavourites!= null)
            {
                _context.Favourites.Update(existingFavourites);
                _context.SaveChanges();
            }
            return favourites;
        }

        public List<Favourites> GetFavourites()
        {
            return _context.Favourites.ToList();
        }

        public Favourites GetFavourites(int id)
        {
            var favourites = _context.Favourites.Find(id);
            return favourites;
        }
    }
}
