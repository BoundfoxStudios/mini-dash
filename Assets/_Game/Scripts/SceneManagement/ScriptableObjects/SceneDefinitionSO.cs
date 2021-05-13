using UnityEngine;

namespace BoundfoxStudios.MiniDash.SceneManagement.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Scene Definition", order = 0)]
  public class SceneDefinitionSO : ScriptableObject
  {
    public string SceneName;
    public bool PersistBetweenSceneSwitch;
  }
}
