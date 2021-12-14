namespace Assets.Scripts.Core
{
  public class Creature
  {
    public string Name { get; set; }
    public int Level { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public int MaxMp { get; set; }
    public MagicType Alignment { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
  }
}
