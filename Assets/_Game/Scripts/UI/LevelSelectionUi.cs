using System;
using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class LevelSelectionUi : MonoBehaviour
  {
    public Transform LevelButtonContainer;
    public LevelSelectionButton LevelSelectionButtonPrefab;
    public LevelsSO LevelsSO;
    
    private void Awake()
    {
      CreateButtons();
    }

    private void CreateButtons()
    {
      for (int i = LevelButtonContainer.childCount - 1; i >= 0; i--)
      {
        Destroy(LevelButtonContainer.GetChild(i).gameObject);
      }

      foreach (var level in LevelsSO.Levels)
      {
        var levelSelectionButton = Instantiate(LevelSelectionButtonPrefab, LevelButtonContainer);
        levelSelectionButton.LevelSO = level;
      }
    }

    public void BackToMainMenu()
    {
      FindObjectOfType<SceneLoader>().ChangeScene("MainMenu");
    }
  }
}
