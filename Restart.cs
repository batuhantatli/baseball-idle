using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject _restartPanel;

    public void GameOver()
    {
        _restartPanel.SetActive(true);
        Game.Instance._gameStop = true;
        FindObjectOfType<ObstacleGenerator>().DestoryAllSpawnedObj();
    }

    public void RestartButton()
    {

        _restartPanel.SetActive(false);
        Game.Instance._gameStop = false;
        Game.Instance.transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).GetComponent<HealthBar>().GameStarted();
    }
}
