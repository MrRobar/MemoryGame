using System;
using UnityEngine;

public class ObjectSelectionTextController : MonoBehaviour
{
    [SerializeField] private CheckerDetector _checkerDetector;
    [SerializeField] private InputManager _inputManager;
    private bool _isShowingText;
    public event Action OnShowNextText;

    private void OnEnable()
    {
        _checkerDetector.OnShowText += ShowingFirstText;
        _inputManager.OnSpacePressed += SpacePressed;
    }

    private void OnDisable()
    {
        _checkerDetector.OnShowText -= ShowingFirstText;
    }

    private void ShowingFirstText(bool inChecker)
    {
        _isShowingText = inChecker;
    }

    private void SpacePressed()
    {
        if (!_isShowingText)
        {
            return;
        }

        OnShowNextText?.Invoke();
    }
}