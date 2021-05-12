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
    private PersistentSceneLoader _persistentSceneLoader;

    private void Awake()
    {
      _persistentSceneLoader = FindObjectOfType<PersistentSceneLoader>();
    }

    public void ChangeScene(string sceneName)
    {
      var list = new List<AsyncOperation>();
      
      for (var i = SceneManager.sceneCount - 1; i >= 0; i--)
      {
        var scene = SceneManager.GetSceneAt(i);
        
        if (_persistentSceneLoader.ScenesNamesToLoad.Contains(scene.name))
        {
          continue;
        }

        list.Add(SceneManager.UnloadSceneAsync(scene));
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
