using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSPOTIFLIX
{


    internal class SeriesGui
    {

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
            series series = new series();



            series.Title = GetString("Title: ");
            series.Length = GetLength();
            series.Genre = GetString("Genre: ");
            series.ReleaseDate = GetReleaseDate();
            series.WWW = GetString("WWW: ");


            ShowMovie(series);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Y:
                    OOPSPOTIFLIX.series.Episodes.Add(series);
                    break;

                case ConsoleKey.N:
                    break;

            }
        }


        //private void SearchMovie()
        //{
        //    Console.WriteLine("search: ");
        //    string search = Console.ReadLine();
        //    foreach (Movie movie in data.movieList)
        //    {
        //        if (movie.Title != null && search != null)
        //        {
        //            if (movie.Title.Contains(search) || movie.Genre.Contains(search))
        //            {
        //                Console.Clear();
        //                ShowMovie(movie);
        //            }

        //        }
        //    }
        //}

        //private DateTime GetLength()
        //{
        //    DateTime to;
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("length (hh:mm:ss): ");
        //    } while (!TimeOnly.TryParse(Console.ReadLine(), out to));
        //    return to;
        //}
        private DateTime GetReleaseDate()
        {
            DateTime dateOnly;
            do
            {
                Console.Clear();
                Console.WriteLine("Release date (MM/DD/YYYY): ");
            } while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly));
            return dateOnly;
        }




        //private void ShowMovie(Movie m)
        //{
        //    Console.WriteLine($"{m.Title} {m.length} {m.Genre} {m.ReleaseDate} {m.WWW}");
        //}
        //private void ShowMovieList()
        //{
        //    foreach (Movie m in series.Episodes)
        //    {
        //        ShowMovie(m);
        //    }
        //}




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
    }
}
