using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New colors storage", menuName = "Custom/Colors Storage")]
public class ColorsStorage : ScriptableObject
{
    public List<Color> Colors;

    public Color RandomColor => Colors[Random.Range(0, Colors.Count)];
}
