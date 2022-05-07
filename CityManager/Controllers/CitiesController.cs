﻿using AutoMapper;
using CityManager.Data;
using CityManager.Dtos;
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
    }
}