using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoundfoxStudios.MiniDash.SceneManagement
{
  public class SceneLoader : MonoBehaviour
  {
    public void ChangeScene(string sceneName)
    {
      var persistentSceneLoader = FindObjectOfType<PersistentSceneLoader>();

      if (!persistentSceneLoader)
      {
        Debug.LogError("No persistent scene loader found!");
        return;
      }

      var list = new List<AsyncOperation>();

      for (var i = SceneManager.sceneCount - 1; i >= 0; i--)
      {
        var scene = SceneManager.GetSceneAt(i);

        var sceneDefinition = persistentSceneLoader.SceneDefinitionSOs.SingleOrDefault(definition => definition.SceneName.Contains(scene.name));

        if (sceneDefinition == null || !sceneDefinition.PersistBetweenSceneSwitch)
        {
          list.Add(SceneManager.UnloadSceneAsync(scene));
        }
      }

      StartCoroutine(LoadAfterAsyncOperationCompletion(list, sceneName));
    }

    private IEnumerator LoadAfterAsyncOperationCompletion(List<AsyncOperation> list, string sceneName)
    {
      yield return new WaitUntil(() => list.All(operation => operation.isDone));

      SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
  }
}
