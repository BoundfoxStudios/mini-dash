using System;
using BoundfoxStudios.MiniDash.SceneManagement;
using TMPro;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class InGameUi : MonoBehaviour
  {
    public GameObject PauseButton;
    public GameObject PlayerUi;
    public GameObject PauseMenuUi;
    public GameObject LevelCompletedUi;
    public TextMeshProUGUI PointsText;
    public TextMeshProUGUI PointsLevelCompletedText;

    private void Awake()
    {
      PauseMenuUi.SetActive(false);
      LevelCompletedUi.SetActive(false);
    }

    public void OnPointsChange(int value)
    {
      PointsText.text = value.ToString();
    }

    public void OnLevelCompleted(int value)
    {
      PauseButton.SetActive(false);
      PlayerUi.SetActive(false);

      PointsLevelCompletedText.text = value.ToString();
      LevelCompletedUi.SetActive(true);
    }

    public void PauseGame()
    {
      Time.timeScale = 0;
      PauseMenuUi.SetActive(true);
    }

    public void ResumeGame()
    {
      Time.timeScale = 1;
      PauseMenuUi.SetActive(false);
    }

    public void BackToMainMenu()
    {
      Time.timeScale = 1;
      FindObjectOfType<SceneLoader>().ChangeScene("MainMenu");
    }

    public void GoToLevelSelection()
    {
      Time.timeScale = 1;
      FindObjectOfType<SceneLoader>().ChangeScene("LevelSelection");
    }
  }
}
