using UnityEngine;

namespace BoundfoxStudios.MiniDash.UI
{
  public class SocialButtonsUi : MonoBehaviour
  {
    public void GoToDiscord()
    {
      Application.OpenURL("https://discord.gg/tHqNzMT");
    }

    public void GoToYouTube()
    {
      Application.OpenURL("https://youtube.com/c/boundfox");
    }

    public void GoToGitHub()
    {
      Application.OpenURL("https://github.com/boundfoxstudios/mini-dash");
    }
  }
}
