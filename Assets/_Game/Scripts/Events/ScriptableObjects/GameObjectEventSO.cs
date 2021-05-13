using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Events.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Mini Dash/Events/Game Object")]
  public class GameObjectEventSO : EventBaseSO
  {
    public UnityAction<GameObject> OnEventRaised;

    public void RaiseEvent(GameObject value)
    {
      OnEventRaised?.Invoke(value);
    }
  }
}
