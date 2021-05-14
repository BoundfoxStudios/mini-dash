using BoundfoxStudios.MiniDash.Levels;
using BoundfoxStudios.MiniDash.SceneManagement;
using TMPro;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class InGameUi : MonoBehaviour
  {
    public GameObject GameOverUi;
    public GameObject PauseButton;
    public GameObject PlayerUi;
    public GameObject PauseMenuUi;
    public GameObject LevelCompletedUi;
    public GameObject NextLevelButton;
    public TextMeshProUGUI PointsText;
    public TextMeshProUGUI PointsLevelCompletedText;

    private void Awake()
    {
      PauseMenuUi.SetActive(false);
      LevelCompletedUi.SetActive(false);
      GameOverUi.SetActive(false);
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
      NextLevelButton.SetActive(FindObjectOfType<LevelManager>().HasNextLevel());
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

    public void ShowGameOverUi()
    {
      GameOverUi.SetActive(true);
    }

    public void RestartLevel()
    {
      Time.timeScale = 1;
      FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void GoToNextLevel()
    {
      FindObjectOfType<LevelManager>().TryLoadNextLevel();
    }
  }
}
