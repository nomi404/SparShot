using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUrl : MonoBehaviour
{
    public void openInstagram()
    {
        Application.OpenURL("https://www.instagram.com/playxelstudio/");
    }
    
    public void openFacebook()
    {
        Application.OpenURL("https://www.facebook.com/PlayXelStudio");
    }
    public void openYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCHKAkDVGGy3_O0aTGUV755Q");
    }


}
