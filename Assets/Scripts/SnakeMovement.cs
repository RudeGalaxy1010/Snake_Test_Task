using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private SwipesHandler _swipesController;
    [SerializeField] private Transform _snakeHead;
    [SerializeField] private int _tailPositionsStep;
    [SerializeField] private Vector2 _limits;
    [SerializeField] private List<Transform> _tailElements;

    private List<Vector3> _positionHistory;
    private Vector3 _targetPosition;
    private bool _isActive;

    public void Center()
    {
        _snakeHead.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        _targetPosition = _snakeHead.transform.position;
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }

    private void OnEnable()
    {
        _swipesController.OnSwipeHorizontal += (d) => Shift(d);
    }

    private void OnDisable()
    {
        _swipesController.OnSwipeHorizontal -= (d) => Shift(d);
    }

    private void Start()
    {
        _positionHistory = new List<Vector3>();
        Center();
        _targetPosition = transform.position;
        SetActive(true);
    }

    private void Update()
    {
        if (_snakeHead.transform.position != _targetPosition)
        {
            _snakeHead.transform.position = Vector3.MoveTowards
                (_snakeHead.transform.position, _targetPosition, _speed * Time.deltaTime);
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

    private void Shift(float delta)
    {
        if (delta == 0)
        {
            return;
        }

        if (!_isActive)
        {
            return;
        }

        Vector3 shiftPosition = transform.position + Vector3.right * delta;
        _targetPosition = new Vector3(Mathf.Clamp(shiftPosition.x, _limits.x, _limits.y), shiftPosition.y, shiftPosition.z);
    }
}
