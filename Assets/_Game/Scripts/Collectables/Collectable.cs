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
    public AudioSource CollectableAudio;

    private void Awake()
    {
      if (IsNecessaryForLevelCompletion)
      {
        LevelRuntimeDataSO.RegisterCollectableForLevelCompletion(gameObject);
      }
    }

    public void Collect()
    {
      CollectableAudio.Play();
      CollectableCollectedEventSO.RaiseEvent(Points);

      if (IsNecessaryForLevelCompletion)
      {
        LevelRuntimeDataSO.RemoveCollectableForLevelCompletion(gameObject);
      }

      Destroy(gameObject);
    }
  }
}
