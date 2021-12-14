using System;
using R = UnityEngine.Random;

public static class UnityRandom
{
  public static int GetRange(int minInclusive, int maxInclusive)
  {
    return R.Range(minInclusive, maxInclusive + 1);
  }

  public static T GetRandomEnum<T>()
  {
    var values = Enum.GetValues(typeof(T)) as T[];
    var randomIndex = R.Range(0, values.Length);
    return values[randomIndex];
  }
}
