using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoundfoxStudios.MiniDash.SceneManagement
{
  public class PersistentSceneLoader : MonoBehaviour
  {
    public string[] ScenesNamesToLoad;

    private void Start()
    {
      LoadScenes();
    }

    private void LoadScenes()
    {
      foreach (var scene in ScenesNamesToLoad)
      {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
          SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
      }
    }
  }
}
