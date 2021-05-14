using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events
{
 public class VoidEventListener : MonoBehaviour
  {
    [SerializeField]
    private VoidEventSO Channel;

    public UnityEvent OnEventRaised;

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

    private void EventRaised()
    {
      OnEventRaised?.Invoke();
    }
  }
}
