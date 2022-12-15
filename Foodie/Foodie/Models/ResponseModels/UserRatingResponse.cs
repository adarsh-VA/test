namespace Foodie.Models.ResponseModels
{
    public class UserRatingResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MyRating { get; set; } = 0;
        public float AvgRating { get; set; } = 0;
    }
}
