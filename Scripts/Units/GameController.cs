using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject LoosePanel;
    public static GameController Instance;
    PlayerController player;
    void Start()
    {
        Instance = this;
        SubscribeToPlayer();
    }

    private async UniTask SubscribeToPlayer()
    {
        while (player == null)
        {
            player = FindObjectOfType<PlayerController>();
            Debug.Log("Searching player... Found:" + player);
           await UniTask.Delay (TimeSpan.FromSeconds(1));
        }
        player.OnEnemyDie.AddListener(EndGame);

    }
    private void OnDestroy()
    {
        Instance = null;
    }
    public void EndGame(Unit unit) {
        unit.OnEnemyDie.RemoveListener(EndGame);
        LoosePanel.SetActive(true);
    }
    public void PressedRestart()
    {
        SceneManager.LoadScene(0);
    }
}
