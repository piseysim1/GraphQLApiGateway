namespace GraphQLApiGateway.Types
{
    public class ReviewType
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
    }
}
