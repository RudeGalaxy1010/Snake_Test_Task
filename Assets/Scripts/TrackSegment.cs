using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    [SerializeField] private List<FoodBunch> _food;
    [SerializeField] private List<Spike> _spikes;
    [SerializeField] private List<Crystal> _crystals;

    private void Start()
    {
        GenerateRandom();
    }

    public void GenerateRandom()
    {
        for (int i = 0; i < _food.Count; i++)
        {
            _food[i].GenerateRandom();
            _food[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < _spikes.Count; i++)
        {
            if (Random.value <= 0.5f)
            {
                _spikes[i].gameObject.SetActive(true);
            }
            else
            {
                _spikes[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < _crystals.Count; i++)
        {
            if (Random.value <= 0.05f)
            {
                _crystals[i].gameObject.SetActive(true);
            }
            else
            {
                _crystals[i].gameObject.SetActive(false);
            }
        }
    }

    public void GenerateStart()
    {
        for (int i = 0; i < _food.Count / 3; i++)
        {
            _food[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _spikes.Count / 3; i++)
        {
            _spikes[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _crystals.Count / 3; i++)
        {
            _crystals[i].gameObject.SetActive(false);
        }
    }
}
