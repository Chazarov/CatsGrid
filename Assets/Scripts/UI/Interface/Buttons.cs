using UnityEngine;

public class Buttons : MonoBehaviour
{
    public delegate void Items();
    public static event Items StartButtonPush;
    public static event Items ReloadButtonPush;
    public void StartGameButton()
    {
        if(StartButtonPush != null) StartButtonPush();
    }

    public void ReloadButton()
    {
        if (ReloadButtonPush != null) ReloadButtonPush();
    }
}
