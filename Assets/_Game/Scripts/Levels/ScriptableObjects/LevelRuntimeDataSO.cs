using System.Collections.Generic;
using System.Collections.ObjectModel;
using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Levels.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Level Runtime Data", order = 0)]
  public class LevelRuntimeDataSO : ScriptableObject
  {
    private int _points;
    private IList<GameObject> _necessaryCollectablesForLevelCompletion = new Collection<GameObject>();
    
    public IntEventSO PointsEventChangedSO;
    public IntEventSO LevelCompletedEventSO;

    public int Points
    {
      get => _points;
      set
      {
        _points = value;
        PointsEventChangedSO.RaiseEvent(_points);
      }
    }

    public void RegisterCollectableForLevelCompletion(GameObject collectable)
    {
      _necessaryCollectablesForLevelCompletion.Add(collectable);
    }

    public void RemoveCollectableForLevelCompletion(GameObject collectable)
    {
      _necessaryCollectablesForLevelCompletion.Remove(collectable);
      
      if (_necessaryCollectablesForLevelCompletion.Count == 0)
      {
        LevelCompletedEventSO.RaiseEvent(_points);
      }
    }

    private void OnDisable()
    {
      _points = 0;
      _necessaryCollectablesForLevelCompletion.Clear();
      Debug.Log("Disabling LevelRuntimeData");
    }
  }
}
