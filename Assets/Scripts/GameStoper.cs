using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStoper : MonoBehaviour
{
    [SerializeField] private SnakeCollisionController _snakeCollisionController;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _startPanel;

    private void OnEnable()
    {
        _snakeCollisionController.Lose += StopGame;
        _snakeCollisionController.Lose += () => _losePanel.SetActive(true);
    }

    private void OnDisable()
    {
        _snakeCollisionController.Lose -= StopGame;
        _snakeCollisionController.Lose -= () => _losePanel.SetActive(true);
    }

    private void Start()
    {
        _losePanel.SetActive(false);
        _startPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        _startPanel.SetActive(false);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
