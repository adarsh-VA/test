namespace Foodie.Models.ResponseModels
{
    public class UserRatingResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MyRating { get; set; }
        public float AvgRating { get; set; }    
    }
}
