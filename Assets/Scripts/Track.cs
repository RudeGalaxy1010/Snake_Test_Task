using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private float _segmentLength = 100;
    [SerializeField] private List<TrackSegment> _segments;
    [SerializeField] public float Speed;

    private void Start()
    {
        _segments[0].GenerateRandom();
        _segments[1].GenerateRandom();
        _segments[2].GenerateStart();
    }

    private void Update()
    {
        if (_segments[2].transform.position.z <= -_segmentLength * 2f)
        {
            _segments[2].GenerateRandom();
            _segments[2].transform.position = _segments[0].transform.position + Vector3.forward * _segmentLength;
            var tempSegment = _segments[0];
            _segments[0] = _segments[2];
            _segments[2] = _segments[1];
            _segments[1] = tempSegment;
        }

        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
    }
}
