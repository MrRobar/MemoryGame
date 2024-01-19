using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VariantsUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _variantsText;
    [SerializeField] private ObjectSelectionTextController _objectSelectionTextController;
    [SerializeField] private TMProLinkHandler _linkHandler;
    [SerializeField] private List<GameObject> _allObjects;
    [SerializeField] private LoadRightAnswers _rightAnswers;
    public event Action<string, Color> OnColorizeText;
    public event Action OnAllCorrectAnswersSelected;
    private int _correctAnswersCount;


    private void OnEnable()
    {
        _objectSelectionTextController.OnShowNextText += UpdateTextData;
        _linkHandler.OnClickedOnLink += CheckVariant;
    }

    private void OnDisable()
    {
        _objectSelectionTextController.OnShowNextText -= UpdateTextData;
        _linkHandler.OnClickedOnLink -= CheckVariant;
    }

    private void CheckVariant(string variantName)
    {
        var resultName = _rightAnswers.CorrectAnswers.FirstOrDefault(x => x == variantName);
        if (resultName != null)
        {
            OnColorizeText?.Invoke(resultName, Color.green);
            _correctAnswersCount++;
            if (_correctAnswersCount >= _rightAnswers.CorrectAnswers.Length)
            {
                _correctAnswersCount = 0;
                OnAllCorrectAnswersSelected?.Invoke();
            }
        }
        else
        {
            OnColorizeText?.Invoke(variantName, Color.red);
        }
    }

    private void UpdateTextData()
    {
        var id = 0;
        _variantsText.text = "Варианты:\n";
        foreach (var go in _allObjects)
        {
            _variantsText.text += $"<link = {id}>{go.name}</link> \n";
            id++;
        }
    }
}