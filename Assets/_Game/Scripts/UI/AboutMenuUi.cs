using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class AboutMenuUi : MonoBehaviour
  {
    public void BackToMainMenu()
    {
      FindObjectOfType<SceneLoader>().ChangeScene("MainMenu");
    }
  }
}
