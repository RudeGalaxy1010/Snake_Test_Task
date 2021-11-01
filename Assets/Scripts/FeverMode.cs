using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverMode : MonoBehaviour
{
    [SerializeField] private SnakeMovement _snakeMovement;
    [SerializeField] private SnakeCollisionController _snakeCollisionController;
    [SerializeField] private Track _track;

    private void OnEnable()
    {
        _snakeCollisionController.FeverActivate += () => StartFever(5);
    }

    private void OnDisable()
    {
        _snakeCollisionController.FeverActivate -= () => StartFever(5);
    }

    public void StartFever(float time)
    {
        StartCoroutine(Fever(time));
    }

    private IEnumerator Fever(float time)
    {
        _snakeMovement.SetActive(false);
        _snakeCollisionController.SetFever(true);
        _track.Speed *= 3;
        _snakeMovement.Center();
        yield return new WaitForSeconds(time);
        _track.Speed /= 3;
        _snakeMovement.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _snakeCollisionController.SetFever(false);
    }
}
