using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class MainMenuUi : MonoBehaviour
  {
    public void GoToAboutMenu()
    {
      FindObjectOfType<SceneLoader>().ChangeScene("About");
    }
  }
}
