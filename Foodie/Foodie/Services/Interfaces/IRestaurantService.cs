﻿using Foodie.Models.ResponseModels;

namespace Foodie.Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantResponse Get(int id);
    }
}
