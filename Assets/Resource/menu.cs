using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour
{

    public void GoToMainMenu()
    {
        Application.LoadLevel("main_menu");
    }

    public void GoToARCamera()
    {
        Application.LoadLevel("sceneAR");
    }

    public void GoToPanduan()
    {
        Application.LoadLevel("panduan");
    }

    public void GoToLatihanSoal()
    {
        Application.LoadLevel("Game");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
