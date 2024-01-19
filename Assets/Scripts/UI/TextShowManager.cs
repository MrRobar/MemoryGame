using UnityEngine;

public class TextShowManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetText;
    [SerializeField] private GameObject _checkerText;
    [SerializeField] private GameObject _chosePicked, _variants, _gameoverText, _gameOverButton;
    [SerializeField] private TargetsDetector _targetsDetector;
    [SerializeField] private CheckerDetector _checkerDetector;
    [SerializeField] private ObjectSelectionTextController _objectSelectionTextController;
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    [SerializeField] private GameoverHandler _gameoverHandler;
    private bool _isPickingState = false;

    private void OnEnable()
    {
        _targetsDetector.OnShowText += SetTargetTextState;
        _checkerDetector.OnShowText += SetCheckerTextState;
        _objectSelectionTextController.OnShowNextText += ShowChoseTexts;
        _variantsUIHandler.OnAllCorrectAnswersSelected += HideVariants;
        _gameoverHandler.OnGameOver += EnableGameOverUI;
    }

    private void OnDisable()
    {
        _targetsDetector.OnShowText -= SetTargetTextState;
        _checkerDetector.OnShowText -= SetCheckerTextState;
        _objectSelectionTextController.OnShowNextText -= ShowChoseTexts;
        _variantsUIHandler.OnAllCorrectAnswersSelected -= HideVariants;
        _gameoverHandler.OnGameOver -= EnableGameOverUI;
    }

    private void SetTargetTextState(bool isVisible)
    {
        if (_isPickingState)
        {
            return;
        }

        _targetText.SetActive(isVisible);
    }

    private void SetCheckerTextState(bool isVisible)
    {
        if (_isPickingState)
        {
            return;
        }

        _checkerText.SetActive(isVisible);
    }

    private void ShowChoseTexts()
    {
        _isPickingState = true;
        _chosePicked.SetActive(true);
        _variants.SetActive(true);
        _checkerText.SetActive(false);
    }

    private void HideVariants()
    {
        _variants.SetActive(false);
        _chosePicked.SetActive(false);
        _isPickingState = false;
    }

    private void EnableGameOverUI()
    {
        _gameoverText.SetActive(true);
        _gameOverButton.SetActive(true);
    }
}