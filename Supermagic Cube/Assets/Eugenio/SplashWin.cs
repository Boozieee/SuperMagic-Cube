using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashWin : MonoBehaviour
{
    public GameObject canva;

    public void Win()
    {
        canva.SetActive(true);
        Application.LoadLevel(Application.loadedLevel);
    }
}
