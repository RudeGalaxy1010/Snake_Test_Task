using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class SnakeColorController : MonoBehaviour
{
    public Color Color => _material.color;
    [SerializeField] private ColorsStorage _colorStarage;
    [SerializeField] private Material _material;

    private void Start()
    {
        _material.color = _colorStarage.RandomColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ColorChanger colorChanger))
        {
            _material.color = colorChanger.Color;
        }
    }
}
