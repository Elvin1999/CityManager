﻿using CityManager.Models;

namespace CityManager.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user,string password);
        Task<User> Login(string userName,string password);
        Task<bool> UserExists(string username);
    }
}
