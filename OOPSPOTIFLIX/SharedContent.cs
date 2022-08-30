namespace OOPSPOTIFLIX
{
    internal abstract class SharedContent // abstact gør man ikke længere can oprette en instans af en klasse
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        public DateTime Length { get; set; }
        public string WWW { get; set; }

        public string GetReleaseDate()
        {
            return ReleaseDate.ToString("D");
        }
    }
}
