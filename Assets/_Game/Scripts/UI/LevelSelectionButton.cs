using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using BoundfoxStudios.MiniDash.SceneManagement;
using TMPro;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class LevelSelectionButton : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    private LevelSO _levelSO;

    public LevelSO LevelSO
    {
      get => _levelSO;
      set
      {
        _levelSO = value;
        UpdateUi();
      }
    }

    private void UpdateUi()
    {
      Text.text = LevelSO.Index.ToString();
    }

    public void LoadLevel()
    {
      FindObjectOfType<SceneLoader>().ChangeScene($"Level{_levelSO.Index}");
    }
  }
}
