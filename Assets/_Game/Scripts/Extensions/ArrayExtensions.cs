using UnityEngine;

namespace BoundfoxStudios.MiniDash.Extensions
{
  public static class ArrayExtensions
  {
    public static T PickOne<T>(this T[] list)
    {
      return list[Random.Range(0, list.Length)];
    }
  }
}
