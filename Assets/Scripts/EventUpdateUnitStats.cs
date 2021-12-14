namespace Assets.Scripts
{
  public class EventUpdateUnitStats
  {
    public int PlayerSlotId { get; set; }
    public bool IsPlayerUnit { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int MP { get; set; }
    public string UnitName { get; set; }
  }
}
