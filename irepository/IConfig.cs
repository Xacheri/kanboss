namespace kanboss
{
    public interface IConfig
    {
      /// <summary>
      /// This makes sure that IConfig is implemented as a singleton. 
      /// abstract static methods cannot be used from an interface instace,
      /// but must be implemented in the class that implements the interface
      /// </summary>
      public abstract static IConfig Load();
      /// <summary>
      /// Save any changes to the configuration
      /// </summary>
      public bool Save();
      /// <summary>
      /// Get the version of the application
      /// </summary>
      public string GetVersion();
      /// <summary>
      /// Get the path to the application data directory
      /// Should be cross platform compatible
      /// </summary>
      public string GetAppDataPath();
      /// <summary>
      /// Get the color scheme for the application
      /// </summary>
      public IColorScheme GetColorScheme();
    }
}
