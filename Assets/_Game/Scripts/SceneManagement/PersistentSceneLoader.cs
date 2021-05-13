using BoundfoxStudios.MiniDash.SceneManagement.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoundfoxStudios.MiniDash.SceneManagement
{
  public class PersistentSceneLoader : MonoBehaviour
  {
    public SceneDefinitionSO[] SceneDefinitionSOs;

    private void Start()
    {
      LoadScenes();
    }

    private void LoadScenes()
    {
      foreach (var sceneDefinition in SceneDefinitionSOs)
      {
        if (!SceneManager.GetSceneByName(sceneDefinition.SceneName).isLoaded)
        {
          SceneManager.LoadScene(sceneDefinition.SceneName, LoadSceneMode.Additive);
        }
      }
    }
  }
}
