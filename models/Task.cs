namespace kanboss;

/// <summary>
/// Represents a task on a board
/// </summary>
class Task {
  public string Title { get; set; }
  public string Description { get; set; }
  /// <summary>
  /// position in Column
  /// </summary>
  public int Row { get; set; }
  /// <summary>
  /// index of Column in board
  /// </summary>
  public int Column { get; set; }
}
