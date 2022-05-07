using CityManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CityManager.Data
{
    public class AppRepository : IAppRepository
    {
        DataContext context;

        public AppRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);  
        }

        public List<City> GetCities()
        {
            var cities=context.Cities.Include(c=>c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int id)
        {
            var city=context
                .Cities
                .Include(c=>c.Photos)
                .FirstOrDefault(c=>c.Id==id);
            return city;
        }

        public Photo GetPhotoById(int id)
        {
            var photo=context.Photos.FirstOrDefault(c=>c.Id==id);
            return photo;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos=context.Photos.Where(p=>p.CityId== cityId).ToList();  
            return photos;
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
