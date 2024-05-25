namespace kanboss
{
    public class Config : IConfig
    {
        private static Config _instance;
        private IColorScheme _colorScheme;
        private string _colorSchemePath;
        private string _version;
        private string _appDataPath;
        private string _rawJson;

        /// <summary>
        /// Constructor initializes the configuration on the first Load() call
        /// </summary>
        private Config()
        {
          try
          {
            // folder creation/check
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _appDataPath = Path.Combine(AppDataFolder, "kanboss");
            if (!Directory.Exists(_appDataPath))
            {
                Directory.CreateDirectory(_appDataPath);
            }

            // json file creation/checked
            string jsonPath = Path.Combine(_appDataPath, "config.json");
            if (!File.Exists(jsonPath))
            {
                // wriite the default json file if it doesn't exist
                File.WriteAllText(jsonPath,
                    "{\"_version\": \"0.0.1\", \"_colorScheme\": \"default-color-scheme.json\"}");
                    
            }
            _rawJson = File.ReadAllText(jsonPath);
            string colorSchemeFromJson = System.Text.Json.JsonDocument.Parse(_rawJson).RootElement.GetProperty("_colorScheme").GetString();
 
            // load the color scheme 
            _colorSchemePath = Path.Combine(_appDataPath, colorSchemeFromJson);
            if (!File.Exists(_colorSchemePath))
            {
                // write the default color scheme if it doesn't exist
                File.WriteAllText(_colorSchemePath,
                    "{\"borderColor\": \"#000000\", \"headerColor\": \"#000000\", \"bodyColor\": \"#000000\", \"highPriorityColor\": \"#000000\", \"mediumPriorityColor\": \"#000000\", \"lowPriorityColor\": \"#000000\", \"completedColor\": \"#000000\"}");
            }
          }
          catch (Exception e)
          {
            Console.Error.WriteLine("Error loading configuration: " + e.Message + "\n" + e.StackTrace);
          }
        }

        /// <summary>
        /// Static method to load the configuration
        /// </summary>
        public static IConfig Load()
        {
            if (_instance == null)
            {
                _instance = new Config();
            }

            return _instance;
        }

        public bool Save()
        {
            try 
            {
                // save the color scheme details
                File.WriteAllText(_colorSchemePath, _colorScheme.GetRawJson());
                
                string json = System.Text.Json.JsonSerializer.Serialize(new
                {
                    _version = _version,
                    _colorSchemePath = _colorSchemePath,

                });
                
                File.WriteAllText(Path.Combine(_appDataPath, "config.json"), json);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error saving configuration: " + e.Message + "\n" + e.StackTrace);
                return false;
            }
            return true;
        }

        public string GetVersion()
        {
            return _version;
        }

        public string GetAppDataPath()
        {
            return _appDataPath;
        }

        public IColorScheme GetColorScheme()
        {
            return _colorScheme;
        }
    }
}
