using UnityEngine;
using UnityEngine.Events;

public class SwipesHandler : MonoBehaviour
{
    public UnityAction<float> OnSwipeHorizontal;

    [SerializeField] private float _threshold;
    [SerializeField] private float _sensitivity;

    private Camera _camera;
    private Vector2 _touchPosition;
    private Vector2 _releasePosition;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = _camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        }
        else if (Input.GetMouseButton(0))
        {
            _releasePosition = _camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);

            var delta = _releasePosition - _touchPosition;
            if (Mathf.Abs(delta.x) > _threshold)
            {
                OnSwipeHorizontal?.Invoke(delta.x * _sensitivity);
            }
        }
    }
}
