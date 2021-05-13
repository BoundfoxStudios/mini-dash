using System;
using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events
{
  [Serializable]
  public class GameObjectEvent : UnityEvent<GameObject>
  {
    
  }
  
  public class GameObjectEventListener : MonoBehaviour
  {
    [SerializeField]
    private GameObjectEventSO Channel;

    public GameObjectEvent OnEventRaised;

    private void OnEnable()
    {
      if (Channel)
      {
        Channel.OnEventRaised += EventRaised;
      }
    }

    private void OnDisable()
    {
      if (Channel)
      {
        Channel.OnEventRaised -= EventRaised;
      }
    }

    private void EventRaised(GameObject value)
    {
      OnEventRaised?.Invoke(value);
    }
  }
}
