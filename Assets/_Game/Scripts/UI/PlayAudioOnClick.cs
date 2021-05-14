using System;
using UnityEngine;
using UnityEngine.UI;

namespace BoundfoxStudios.MiniDash.UI
{
  public class PlayAudioOnClick : MonoBehaviour
  {
    public Button Button;
    public AudioSource AudioSource;

    private void OnEnable()
    {
      Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
      Button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
      AudioSource.Play();
    }
  }
}
