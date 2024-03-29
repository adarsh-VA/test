﻿using Foodie.Models.RequestModels;
using Foodie.Models.ResponseModels;

namespace Foodie.Services.Interfaces
{
    public interface IRestaurantService
    {
        public List<RestaurantResponse> GetAll();
        public RestaurantResponse Get(int id);
        public int Create(RestaurantRequest restaurantRequest);
    }
}
