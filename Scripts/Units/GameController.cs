using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject LoosePanel;
    public static GameController Instance;
    void Start()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    public void EndGame()
    {
        LoosePanel.SetActive(true);
    }
    public void PressedRestart()
    {
        SceneManager.LoadScene(0);
    }
}
