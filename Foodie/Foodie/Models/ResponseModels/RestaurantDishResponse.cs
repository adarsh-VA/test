namespace Foodie.Models.ResponseModels
{
    public class RestaurantDishResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float AvgRating { get; set; } = 0;
    }
}
