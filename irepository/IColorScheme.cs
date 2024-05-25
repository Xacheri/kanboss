namespace kanboss
{
    public interface IColorScheme
    {
      public string GetBorderColor();
      public string GetHeaderColor();
      public string GetBodyColor();
      public string GetHighPriorityColor();
      public string GetMediumPriorityColor();
      public string GetLowPriorityColor();
      public string GetCompletedColor();
    }
}
