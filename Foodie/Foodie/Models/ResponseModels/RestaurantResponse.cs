﻿using Foodie.Models.DbModels;

namespace Foodie.Models.ResponseModels
{
    public class RestaurantResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RestaurantDishResponse> Dishes { get; set;}
        public float Rating { get; set; } = 0;
    }
}
