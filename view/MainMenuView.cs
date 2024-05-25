namespace kanboss
{
  public class MainMenuView
  {
    private IConfig _config;
    public MainMenuView(IConfig config)
    {
      _config = config;
    }
    public void Show()
    {
      Console.WriteLine("Welcome to Kanboss!");
      Console.WriteLine("Version: " + _config.GetVersion());
    }
  }
}
