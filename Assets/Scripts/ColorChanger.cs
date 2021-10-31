using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color Color => _color;

    [SerializeField] private ColorsStorage _storage;

    private Color _color;

    private void Start()
    {
        _color = _storage.RandomColor;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(renderer.material);
        renderer.material.color = _color;
    }
}
