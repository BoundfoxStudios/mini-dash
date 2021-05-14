using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Events/Void")]
  public class VoidEventSO : EventBaseSO
  {
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
      OnEventRaised?.Invoke();
    }
  }
}
