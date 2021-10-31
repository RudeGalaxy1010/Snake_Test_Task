using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class SnakeCollisionController : MonoBehaviour
{
    public UnityAction<int> PointsChanged;
    public UnityAction<int> CrystalPointsChanged;
    public UnityAction FeverActivate;
    public UnityAction Lose;
    public int Points => _points;
    public int Crystals => _crystals;
    [SerializeField] private SnakeColorController _snakeColorController;
    private int _points;
    private int _crystals;
    private bool _isFever;

    private void Start()
    {
        _points = 0;
        _crystals = 0;
    }

    public void SetFever(bool isFever)
    {
        _isFever = isFever;
        if (!_isFever)
        {
            _crystals = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isFever)
        {
            other.gameObject.SetActive(false);
            return;
        }

        if (other.TryGetComponent(out Food food))
        {
            if (food.Color != _snakeColorController.Color)
            {
                Lose?.Invoke();
                return;
            }

            _points += food.Points;
            food.gameObject.SetActive(false);
            PointsChanged?.Invoke(Points);
        }
        else if (other.TryGetComponent(out Crystal crystal))
        {
            _crystals++;
            crystal.gameObject.SetActive(false);
            CrystalPointsChanged?.Invoke(Crystals);

            if (_crystals == 3)
            {
                FeverActivate?.Invoke();
            }
        }
        else if (other.TryGetComponent(out Spike spike))
        {
            Lose?.Invoke();
        }
    }
}
