using CityManager.Models;

namespace CityManager.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity);
        void Delete<T>(T entity);
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosByCity(int id);
        City GetCityById(int id);
        Photo GetPhotoById(int id);
    }
}
