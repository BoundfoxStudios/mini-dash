using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Levels
{
  public class LevelManager : MonoBehaviour
  {
    public LevelRuntimeDataSO LevelRuntimeDataSO;

    public void OnNecessaryCoinCollected(GameObject coin)
    {
      LevelRuntimeDataSO.RemoveCollectableForLevelCompletion(coin);
    }
  }
}
