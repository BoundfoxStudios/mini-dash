using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Collectables
{
  public class PointsManager : MonoBehaviour
  {
    public LevelRuntimeDataSO LevelRuntimeDataSO;

    public void OnCollectableCollected(int value)
    {
      LevelRuntimeDataSO.Points += value;
    }
  }
}
