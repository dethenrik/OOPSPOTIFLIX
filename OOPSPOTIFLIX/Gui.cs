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
        private void SaveDataSeries()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/Serieslist.json", json);
        }

        private void LoadDataSeries()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/Serieslist.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
        }

        private void SaveDataAlbum()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/Albumlist.json", json);
        }

        private void LoadDataAlbum()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/Albumlist.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
        }

        private void SaveDataSong()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/Songlist.json", json);
        }

        private void LoadDataSong()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/Songlist.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
        }



        //-------------------MOVIE-------------------//


        private void MovieMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMOVIE MENU\n1: list of Movies \n2: search for Movies \n3: Add Movie \n4: Save movie list \n5: Load movies list ");

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
            Console.WriteLine("\nMOVIE MENU\n1: list of series \n2: search for series \n3: Add series \n 4: Save Series \n5: Load Series ");

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
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SaveDataSeries();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    LoadDataSeries();
                    break;

            }
        }



        private void AddSeries()
        {
            Series series = new Series();



            series.Title = GetString("Title: ");
            series.Genre = GetString("Genre: ");
            series.Length = GetLength();
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
            episode.Length = GetLength();
            episode.ReleaseDate = GetReleaseDate();
            episode.EpisodeNum = Getint("WWW: ");


            ShowEpisode(episode);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.seriesList.Add(s);
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


        private void SearchEpisode()
        {
            Console.WriteLine("search: ");
            string search2 = Console.ReadLine();
            foreach (Episode episode in data.EpisodeList)
            {
                if (episode.Title != null && search2 != null)
                {
                    if (episode.Title.Contains(search2) || episode.Genre.Contains(search2))
                    {
                        Console.Clear();
                        ShowEpisode(episode);
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

        private void ShowEpisode(Episode e)
        {
            Console.WriteLine($"{e.Title} {e.Length} {e.Genre} {e.ReleaseDate} {e.WWW}");
        }
        private void ShowEpisodeList()
        {
            foreach (Episode e in data.EpisodeList)
            {
                ShowEpisode(e);
            }
        }





        //--------------MUSIC---------------//






        private void MusicMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMUSIC MENU\n1: list of Albums \n2: List of songs \n3: Search for album \n4: Search for song \n5: Add album \n6: Add song \n7: Save album list\n8: Load album list\n9: Save Song list \n0: Load Song list");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowAlbumList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ShowSongList();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    SearchAlbum();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SearchSong();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    AddAlbum();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    AddSong();
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    SaveDataAlbum();
                    break;
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:
                    LoadDataAlbum();
                    break;
                case ConsoleKey.NumPad9:
                case ConsoleKey.D9:
                    SaveDataSong();
                    break;
                case ConsoleKey.NumPad0:
                case ConsoleKey.D0:
                    LoadDataSong();
                    break;
            }
        }



        private void AddAlbum()
        {
            Music music = new Music();

            music.Title = GetString("Title: ");
            music.Genre = GetString("Genre: ");
            music.ReleaseDate = GetReleaseDate();
            music.Artist = GetString("Kunstner: ");

            ShowAlbum(music);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.albumList.Add(music);
                    break;

                case ConsoleKey.N:
                    break;
            }
        }

        private void AddSong()
        {
            Music music = new Music();


            music.Title = GetString("Title: ");
            music.Genre = GetString("Genre: ");
            music.ReleaseDate = GetReleaseDate();
            music.Artist = GetString("Kunstner: ");


            ShowSong(music);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    data.songList.Add(music);
                    break;

                case ConsoleKey.N:
                    break;

            }
        }

        //-------------------SEARCH ALBUM---------------\\

        private void SearchAlbum()
        {
            Console.WriteLine("search album: ");
            string search2 = Console.ReadLine();
            foreach (Music music in data.albumList)
            {
                if (music.Title != null && search2 != null)
                {
                    if (music.Title.Contains(search2) || music.Genre.Contains(search2))
                    {
                        Console.Clear();
                        ShowAlbum(music);
                    }

                }
            }
        }
        //-------------------SEARCH ALBUM---------------\\




        //-------------------------SEARCH SONGS----------------------\\
        private void SearchSong()
        {
            Console.WriteLine("search song: ");
            string search2 = Console.ReadLine();
            foreach (Music music in data.songList)
            {
                if (music.Title != null && search2 != null)
                {
                    if (music.Title.Contains(search2) || music.Genre.Contains(search2))
                    {
                        Console.Clear();
                        ShowSong(music);
                    }

                }
            }
        }
        //-------------------------SEARCH SONGS----------------------\\



        //-------------------SHOW ALBUMS---------------\\
        private void ShowAlbum(Music M)
        {
            Console.WriteLine($"{M.Title} {M.Length} {M.Genre} {M.ReleaseDate} {M.Artist}");
        }
        private void ShowAlbumList()
        {
            foreach (Music n in data.albumList)
            {
                ShowAlbum(n);

                Console.WriteLine("Do you wish to search for a song "); 
            }
        }
        //-------------------SHOW ALBUMS---------------\\




        //-------------------- SHOW SONGS-------------\\
        private void ShowSong(Music M)
        {
            Console.WriteLine($"{M.Title} {M.Length} {M.Genre} {M.ReleaseDate} {M.Artist}");
        }
        private void ShowSongList()
        {
            foreach (Music n in data.songList)
            {
                ShowSong(n);
            }
        }
        //-------------------- SHOW SONGS-------------\\




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
