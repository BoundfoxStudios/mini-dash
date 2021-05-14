using UnityEngine;
using UnityEngine.Events;

namespace BoundfoxStudios.MiniDash.Player
{
  public class SpriteBecameInvisible : MonoBehaviour
  {
    public UnityEvent BecameInvisible;

    private void OnBecameInvisible()
    {
      BecameInvisible?.Invoke();
    }
  }
}
