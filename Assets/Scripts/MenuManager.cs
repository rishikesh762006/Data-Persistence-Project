using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public InputField inputField;
    public string currentPlayerName;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CurrentPlayer()
    {
        currentPlayerName = inputField.text;
        InstanceManager.Instance.currentPlayerName = currentPlayerName;
    }

    public void End()
    {
        InstanceManager.Instance.SaveData();
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
