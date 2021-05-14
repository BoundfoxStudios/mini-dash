using System;
using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Collectables
{
  public class Collectable : MonoBehaviour
  {
    public int Points;
    public bool IsNecessaryForLevelCompletion;
    public LevelRuntimeDataSO LevelRuntimeDataSO;
    public IntEventSO CollectableCollectedEventSO;

    private void Awake()
    {
      if (IsNecessaryForLevelCompletion)
      {
        LevelRuntimeDataSO.RegisterCollectableForLevelCompletion(gameObject);
      }
    }

    public void Collect()
    {
      CollectableCollectedEventSO.RaiseEvent(Points);

      if (IsNecessaryForLevelCompletion)
      {
        LevelRuntimeDataSO.RemoveCollectableForLevelCompletion(gameObject);
      }

      Destroy(gameObject);
    }
  }
}
