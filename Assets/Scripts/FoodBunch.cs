using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBunch : MonoBehaviour
{
    [SerializeField] private ColorsStorage _storage;
    [SerializeField] private List<Food> _food;

    private void Start()
    {
        Color color = _storage.RandomColor;
        for (int i = 0; i < _food.Count; i++)
        {
            _food[i].SetColor(color);
        }
    }

    public void GenerateRandom()
    {
        for (int i = 0; i < _food.Count; i++)
        {
            if (Random.value <= 0.75f)
            {
                _food[i].gameObject.SetActive(true);
            }
            else
            {
                _food[i].gameObject.SetActive(false);
            }
        }
    }
}
