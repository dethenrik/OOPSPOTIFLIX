using System.ComponentModel.DataAnnotations;

namespace OOPSPOTIFLIX
{
    internal class Gui
    {

        Data data = new Data();



        public Gui()
        {
            data.movieList = new();
            while (true)
            {
                Console.Clear();
                Menu();

            }

        }








        private void Menu()
        {
            Console.WriteLine("\nMOVIE MENU\n1: Movies \n2: Series \n3: Music \n4: Save list \n5: Load list");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SeriesMenu();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:

                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SaveData();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    LoadData();
                    break;
            }
        }







        private void SaveData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/movielist.json", json);
        }






        private void LoadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/movielist.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
        }




        //-------------------MOVIE-------------------//


        private void MovieMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMOVIE MENU\n1: list of Movies \n2: search for Movies \n3: Add Movie ");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMovie();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMovie();
                    break;

            }
        }




        private void AddMovie()
        {
            Movie movie = new Movie();

            movie.Title = GetString("Title: ");
            movie.length = GetLength();
            movie.Genre = GetString("Genre: ");
            movie.ReleaseDate = GetReleaseDate();
            movie.WWW = GetString("WWW: ");


            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.movieList.Add(movie);
                    break;

                case ConsoleKey.N:
                    break;

            }
        }




        private void SearchMovie()
        {
            Console.WriteLine("search: ");
            string search = Console.ReadLine();
            foreach (Movie movie in data.movieList)
            {
                if (movie.Title != null && search != null)
                {
                    if (movie.Title.Contains(search) || movie.Genre.Contains(search))
                    {
                        Console.Clear();
                        ShowMovie(movie);
                    }

                }
            }
        }
        




        private void ShowMovie(Movie m)
        {
            Console.WriteLine($"{m.Title} {m.length} {m.Genre} {m.ReleaseDate} {m.WWW}");
        }
        private void ShowMovieList()
        {
            foreach (Movie m in data.movieList)
            {
                ShowMovie(m);
            }
        }




        //---------------SERIES------------------//



        private void SeriesMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMOVIE MENU\n1: list of series \n2: search for series \n3: Add series ");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSeriesList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSeries();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSeries();
                    break;

            }
        }



        private void AddSeries()
        {
            Series series = new Series();



            series.Title = GetString("Title: ");
            series.Genre = GetString("Genre: ");
            series.ReleaseDate = GetReleaseDate();
            series.WWW = GetString("WWW: ");


            ShowSeries(series);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.seriesList.Add(series);
                    break;

                case ConsoleKey.N:
                    break;

            }
        }



        private void AddEpisode()
        {
            Episode episode = new Episode();



            episode.Title = GetString("Title: ");
            episode.Season = Getint("Genre: ");
            episode.ReleaseDate = GetReleaseDate();
            episode.EpisodeNum = Getint("WWW: ");


            ShowSeries(series);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.seriesList.Add(series);
                    break;

                case ConsoleKey.N:
                    break;

            }
        }




        private void SearchSeries()
        {
            Console.WriteLine("search: ");
            string search2 = Console.ReadLine();
            foreach (Series series in data.seriesList)
            {
                if (series.Title != null && search2 != null)
                {
                    if (series.Title.Contains(search2) || series.Genre.Contains(search2))
                    {
                        Console.Clear();
                        ShowSeries(series);
                    }

                }
            }
        }




        private void ShowSeries(Series s)
        {
            Console.WriteLine($"{s.Title} {s.Length} {s.Genre} {s.ReleaseDate} {s.WWW}");
        }
        private void ShowSeriesList()
        {
            foreach (Series s in data.seriesList)
            {
                ShowSeries(s);
            }
        }





        //--------------MUSIC---------------//
























































        //-----------------------------------//




        private DateTime GetLength()
        {
            DateTime to;
            do
            {
                Console.Clear();
                Console.WriteLine("length (hh:mm:ss): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out to));
            return to;
        }




        private DateTime GetReleaseDate()
        {
            DateTime dateOnly;
            do
            {
                Console.Clear();
                Console.WriteLine("Release date (MM/DD/YYYY): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out dateOnly));
            return dateOnly;
        }


        private string GetString(string type)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine(type);
                input = Console.ReadLine();
            }
            while (input == null && input != "");
            return input;
        }

        private string Getint(int type)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine(type);
                input = Console.ReadLine();
            }
            while (input == null && input != "");
            return input;
        }
    }
}
