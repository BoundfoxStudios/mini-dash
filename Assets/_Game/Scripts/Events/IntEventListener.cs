using System;
using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events
{
  [Serializable]
  public class IntEvent : UnityEvent<int>
  {
    
  }
  
  public class IntEventListener : MonoBehaviour
  {
    [SerializeField]
    private IntEventSO Channel;

    public IntEvent OnEventRaised;

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

    private void EventRaised(int value)
    {
      OnEventRaised?.Invoke(value);
    }
  }
}
