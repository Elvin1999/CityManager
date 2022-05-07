using AutoMapper;
using CityManager.Data;
using CityManager.Dtos;
using CityManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityManager.Controllers
{

    [ApiController()]
    [Route("api/Cities")]
    public class CitiesController:ControllerBase
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities=_appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }


        [HttpGet]
        [Route("detail")]
        public IActionResult GetCitiesById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn= _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }


        [HttpGet]
        [Route("Photos")]
        public IActionResult GetPhotosByCityId(int cityId)
        {
            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

    }
}
