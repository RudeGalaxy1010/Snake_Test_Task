using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private SnakeCollisionController _foodController;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _crystalsText;

    private void OnEnable()
    {
        _foodController.PointsChanged += (p) => _scoreText.text = p.ToString();
        _foodController.CrystalPointsChanged += (c) => _crystalsText.text = c.ToString();
    }

    private void OnDisable()
    {
        _foodController.PointsChanged -= (p) => _scoreText.text = p.ToString();
        _foodController.CrystalPointsChanged -= (c) => _crystalsText.text = c.ToString();
    }
}
