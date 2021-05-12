using System.Collections;
using BoundfoxStudios.MiniDash.Extensions;
using UnityEngine;

namespace BoundfoxStudios.MiniDash.Music
{
  [RequireComponent(typeof(AudioSource))]
  public class BackgroundMusicPlayer : MonoBehaviour
  {
    public AudioClip[] Songs;
    private AudioSource _audioSource;

    private void Start()
    {
      _audioSource = GetComponent<AudioSource>();
      StartCoroutine(PlayNextSong());
    }

    private IEnumerator PlayNextSong()
    {
      while (true)
      {
        var song = GetNextSong();

        if (song)
        {
          _audioSource.clip = song;
          _audioSource.Play();

          yield return new WaitForSecondsRealtime(_audioSource.clip.length);
        }

        yield return null;
      }
    }

    private AudioClip GetNextSong()
    {
      return Songs.PickOne();
    }
  }
}
