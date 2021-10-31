using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Food : MonoBehaviour
{
    public int Points => _points;
    public Color Color => _color;

    [SerializeField] private int _points;

    private Color _color;

    public void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(renderer.material);
        _color = color;
        renderer.material.color = _color;
    }
}
