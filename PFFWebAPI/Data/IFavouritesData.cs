using PFFWebAPI.Models;

namespace PFFWebAPI.Data
{
    public interface IFavouritesData
    {
        List<Favourites> GetFavourites();

        Favourites GetFavourites(int id);

        Favourites AddFavourites(Favourites favourites);

        void DeleteFavourites(Favourites favourites);

        Favourites EditFavourites(Favourites favourites);
    }
}
