using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        _player.ScoreAdded += OnScoreAdded;
    }

    private void OnDisable()
    {
        _player.ScoreAdded -= OnScoreAdded;
    }

    private void OnScoreAdded(int score)
    {
        _scoreDisplay.text = score.ToString();
    }
}
