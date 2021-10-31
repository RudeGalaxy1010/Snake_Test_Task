using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private SwipesHandler _swipesController;
    [SerializeField] private Transform _snakeHead;
    [SerializeField] private Transform[] _positions = new Transform[3];
    [SerializeField] private int _tailPositionsStep;
    [SerializeField] private List<Transform> _tailElements;

    private int _currentPositionIndex;
    private List<Vector3> _positionHistory;
    private bool _isActive;

    public void Center()
    {
        _currentPositionIndex = 1;
        _snakeHead.transform.position = _positions[_currentPositionIndex].position;
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }

    private void OnEnable()
    {
        _swipesController.OnSwipeHorizontal += (d) => Shift((int)Mathf.Sign(d));
    }

    private void OnDisable()
    {
        _swipesController.OnSwipeHorizontal -= (d) => Shift((int)Mathf.Sign(d));
    }

    private void Start()
    {
        _positionHistory = new List<Vector3>();
        Center();
        SetActive(true);
    }

    private void Update()
    {
        if (_snakeHead.transform.position != _positions[_currentPositionIndex].position)
        {
            _snakeHead.transform.position = Vector3.MoveTowards
                (_snakeHead.transform.position, _positions[_currentPositionIndex].position, _speed * Time.deltaTime);
        }

        _positionHistory.Insert(0, _snakeHead.position);
        int index = 0;
        for (int i = 0; i < _tailElements.Count; i++)
        {
            Vector3 position = _positionHistory[Mathf.Min(index * _tailPositionsStep, _positionHistory.Count - 1)];
            Vector3 direction = position - _tailElements[i].position;
            direction = new Vector3(direction.x, direction.y, 0);
            _tailElements[i].position += direction * _speed * Time.deltaTime;
            _tailElements[i].LookAt(position);
            index++;
        }

        if (_positionHistory.Count > 150)
        {
            _positionHistory.RemoveAt(_positionHistory.Count - 1);
        }
    }

    private void Shift(int direction)
    {
        if (direction == 0)
        {
            return;
        }

        if (!_isActive)
        {
            return;
        }

        if (direction > 0 && _currentPositionIndex < 2)
        {
            _currentPositionIndex++;
        }
        else if (direction < 0 && _currentPositionIndex > 0)
        {
            _currentPositionIndex--;
        }
    }
}
