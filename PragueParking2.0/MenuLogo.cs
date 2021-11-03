using System;
using Spectre.Console;
using System.Threading.Tasks;
//using System.Threading;
using System.Linq;
using System.Text;
using System.Timers;

    
namespace PragueParking2._0
{
    public class MenuLogo
    {
        public static void MenuLogos()
        {
            Console.Clear();
            AnsiConsole.Write(
            new FigletText("Prague Parking 2.0")
                .LeftAligned()
                .Color(Color.Red));

            Console.WriteLine();

            var menuTable = new Table().RoundedBorder()
                .BorderColor(Color.Yellow)
                .Caption("Press Esc to exit.")
                .Title("MENU");

            menuTable.AddColumn("[bold][green]Manage vehicles[/][/]");
            menuTable.AddColumn("[bold][cyan]Parking house[/][/]");
            menuTable.AddColumn("[bold][red]Administration[/][/]");

            menuTable.AddEmptyRow();
            menuTable.AddRow("[gray]■[/]  [green](P)[/]ark a vehicle  ", "[gray]■[/]  [cyan](O)[/]verview parking  ", "[gray]■[/]  [red](R)[/]eload admin file  ");
            menuTable.AddRow("[gray]■[/]  [green](C)[/]heck out vehicle  ", "[gray]■[/]  [cyan](V)[/]isual overview  ", "[gray]■[/]  Load [red](T)[/]estfile");
            menuTable.AddRow("[gray]■[/]  [green](M)[/]ove a vehicle  ", " ", " ");
            menuTable.AddEmptyRow();

            AnsiConsole.Write(menuTable);

            Console.WriteLine();
            Console.WriteLine();

            //SideInfo();
            //Clock().Wait();
        }

        //static async void SideInfo()
        //{   
        //    var sideMenu = new Table().RoundedBorder()
        //        .BorderColor(Color.Red)
        //        .Title("Parking information");

        //    sideMenu.AddColumn("               test              ");
        //    sideMenu.AddRow("              test                ");

        //    AnsiConsole.Write(sideMenu);
        //}

        //static async Task Clock()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine(DateTime.Now.ToString());
        //        await Task.Delay(1000);
        //        Console.Clear();
        //    }


            //await Task.Run(() =>
            //{
            //    var clearArrayTime = "23:59:00";
            //    var timeParts = clearArrayTime.Split(new char[1] { ':' });
            //var dateNow = DateTime.Now;
            //    var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
            //      int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));

            //TimeSpan ts;

            //    if (date > dateNow)
            //        ts = date - dateNow;
            //    else
            //    {
            //        date = date.AddDays(1);
            //        ts = date - dateNow;
            //    }
            //    Task.Delay(ts).ContinueWith((x) => ClearArray());
            //});

            //var sideMenu2 = new Table().RoundedBorder()
            //    .BorderColor(Color.Aqua)
            //    .Title("Time");

            //sideMenu2.AddColumn("                test           ");
            //sideMenu2.AddRow("              test                ");

            //AnsiConsole.Write(sideMenu2);
        //}


    }
}


