using System;
using BoundfoxStudios.MiniDash.Levels.ScriptableObjects;
using BoundfoxStudios.MiniDash.Player;
using BoundfoxStudios.MiniDash.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BoundfoxStudios.MiniDash.Levels
{
  public class LevelManager : MonoBehaviour
  {
    public LevelsSO LevelsSO;
    public LevelRuntimeDataSO LevelRuntimeDataSO;

    private GameControls _controls;

    private void Awake()
    {
      _controls = new GameControls();
    }

    private void OnEnable()
    {
      _controls.LevelManager.RestartLevel.performed += RestartLevelPerformed;
      
      _controls.LevelManager.Enable();
    }

    private void OnDisable()
    {
      _controls.LevelManager.RestartLevel.performed -= RestartLevelPerformed;
      
      _controls.LevelManager.Disable();
    }

    private void RestartLevelPerformed(InputAction.CallbackContext _)
    {
      RestartLevel();
    }

    public bool HasNextLevel()
    {
      var currentLevelIndex = LevelRuntimeDataSO.LevelIndex;
      var highestIndex = LevelsSO.Levels[LevelsSO.Levels.Length - 1].Index;

      return currentLevelIndex < highestIndex;
    }

    public bool TryLoadNextLevel()
    {
      if (!HasNextLevel())
      {
        return false;
      }

      LoadLevel(LevelRuntimeDataSO.LevelIndex + 1);
      return true;
    }

    public void LoadLevel(int index)
    {
      FindObjectOfType<SceneLoader>().ChangeScene($"Level{index}");
    }

    public void RestartLevel()
    {
      LoadLevel(LevelRuntimeDataSO.LevelIndex);
    }
  }
}
