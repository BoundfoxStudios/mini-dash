using System;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Collectables
{
  public class CollectableRotator : MonoBehaviour
  {
    public float Speed = 1;

    private void Update()
    {
      transform.Rotate(Vector3.forward, Speed * Time.deltaTime);
    }
  }
}
