using PFFWebAPI.Models;

namespace PFFWebAPI.Data
{
    public interface IPresentData
    {
        List<Present> GetPresents();

        Present GetPresent(int id);

        Present AddPresent(Present present);

        void DeletePresent(Present present);

        Present EditPresent(Present present);
    }
}