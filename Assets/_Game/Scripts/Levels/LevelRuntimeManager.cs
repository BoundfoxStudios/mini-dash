using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Levels
{
  public class LevelRuntimeManager : MonoBehaviour
  {
    public int LevelIndex;
    public LevelRuntimeDataSO LevelRuntimeDataSO;

    private void Awake()
    {
      LevelRuntimeDataSO.LevelIndex = LevelIndex;
    }

    private void OnDestroy()
    {
      LevelRuntimeDataSO.Clean();
    }
  }
}
