using UnityEngine;

namespace BoundfoxStudios.MiniDash.Levels.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Levels/Levels", order = 0)]
  public class LevelsSO : ScriptableObject
  {
    public LevelSO[] Levels;
  }
}
