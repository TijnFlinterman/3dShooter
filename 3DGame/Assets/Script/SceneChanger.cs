using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Gameplay()
    {
        SceneManager.LoadScene("Woods");
    }
    public void TestChamber()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
