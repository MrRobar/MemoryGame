using System;
using System.Collections.Generic;
using UnityEngine;

public class GameoverHandler : MonoBehaviour
{
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    [SerializeField] private List<GameObject> _targets;
    private int _counter;

    public event Action OnGameOver;

    private void OnEnable()
    {
        _variantsUIHandler.OnAllCorrectAnswersSelected += CheckForGameOver;
    }

    private void OnDisable()
    {
        _variantsUIHandler.OnAllCorrectAnswersSelected -= CheckForGameOver;
    }
    
    private void CheckForGameOver()
    {
        _counter++;
        if (_counter == _targets.Count)
        {
            OnGameOver?.Invoke();
        }
    }
}
