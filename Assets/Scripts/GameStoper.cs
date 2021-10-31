using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStoper : MonoBehaviour
{
    [SerializeField] private SnakeCollisionController _snakeCollisionController;
    [SerializeField] private GameObject _losePanel;

    private void OnEnable()
    {
        _snakeCollisionController.Lose += ReceiveLose;
    }

    private void OnDisable()
    {
        _snakeCollisionController.Lose -= ReceiveLose;
    }

    private void Start()
    {
        _losePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReceiveLose()
    {
        _losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
