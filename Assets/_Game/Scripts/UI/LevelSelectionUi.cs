using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class LevelSelectionUi : MonoBehaviour
  {
    public void SelectLevel(int level)
    {
      FindObjectOfType<SceneLoader>().ChangeScene($"Level{level}");
    }

    public void BackToMainMenu()
    {
      FindObjectOfType<SceneLoader>().ChangeScene("MainMenu");
    }
  }
}
