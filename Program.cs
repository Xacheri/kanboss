namespace kanboss;

class Program
{
    static void Main(string[] args)
    {
      // Load the configuration
      IConfig config = Config.Load();

      // Create the main menu view 
      MainMenuView mainMenu = new MainMenuView(config);
      // if there are no arguments, show the main menu
      if (args.Length == 0)
      {
        mainMenu.Show();
      }

      // if there are arguments, process them
      else
      {
        // process the arguments
        switch (args[0])
        {
          case "help":
            Console.WriteLine("Help is on the way!");
            break;
          default:
            Console.WriteLine("Unknown command: " + args[0]);
            break;
        }
      }
    }
}
