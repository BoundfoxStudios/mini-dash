using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Levels
{
  public class LevelManager : MonoBehaviour
  {
    public LevelsSO LevelsSO;
    public LevelRuntimeDataSO LevelRuntimeDataSO;
    public AudioSource LevelCompletedAudio;

    public void PlayLevelCompletedAudio()
    {
      LevelCompletedAudio.Play();
    }

    public bool HasNextLevel()
    {
      var currentLevelIndex = LevelRuntimeDataSO.LevelIndex;
      var highestIndex = LevelsSO.Levels[LevelsSO.Levels.Length - 1].Index;

      return currentLevelIndex < highestIndex;
    }

    public bool TryLoadNextLevel()
    {
      if (!HasNextLevel())
      {
        return false;
      }

      LoadLevel(LevelRuntimeDataSO.LevelIndex + 1);
      return true;
    }

    public void LoadLevel(int index)
    {
      FindObjectOfType<SceneLoader>().ChangeScene($"Level{index}");
    }

    public void RestartLevel()
    {
      LoadLevel(LevelRuntimeDataSO.LevelIndex);
    }
  }
}
