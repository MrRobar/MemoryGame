using TMPro;
using UnityEngine;

public class TextColorizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textObj;
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    private Color _textColor;
    private string _textToColorize;

    private void OnEnable()
    {
        _variantsUIHandler.OnColorizeText += UpdateTextAndColor;
    }

    private void OnDisable()
    {
        _variantsUIHandler.OnColorizeText -= UpdateTextAndColor;
    }

    private void UpdateTextAndColor(string text, Color color)
    {
        _textColor = color;
        _textToColorize = text;
        FindAndColorize();
    }

    private void FindAndColorize()
    {
        string originalText = _textObj.text;

        int circleIndex = originalText.IndexOf(_textToColorize);

        if (circleIndex >= 0)
        {
            var startingTag = $"<color=#{ColorUtility.ToHtmlStringRGB(_textColor)}>";
            string newText = originalText.Insert(circleIndex, startingTag);

            int endIndex = circleIndex + _textToColorize.Length + startingTag.Length;

            newText = newText.Insert(endIndex, "</color>");

            _textObj.text = newText;
        }
    }
}