namespace LibraryAPI.Dtos.Resources.BarrowBookResources
{
    public class BarrowBookDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public DateTime BarrowStartDate { get; set; }
        public DateTime BarrowEndDate { get; set;}
    }
}
