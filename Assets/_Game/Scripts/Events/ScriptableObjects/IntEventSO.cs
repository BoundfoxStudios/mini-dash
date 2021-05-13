using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Events/Int")]
  public class IntEventSO : EventBaseSO
  {
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int value)
    {
      OnEventRaised?.Invoke(value);
    }
  }
}
