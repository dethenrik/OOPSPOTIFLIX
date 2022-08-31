namespace OOPSPOTIFLIX
{
    internal class Movie : SharedContent
    {
        public string Title { get; set; }
        public DateTime length { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string WWW { get; set; }


        

    }
    internal class ListName
    {
        private string GetListName()
        {
            string listName = Console.ReadLine();
            return listName;
        }
            public List<string> listName { get { GetListName }; set; }
            
        }
    }

