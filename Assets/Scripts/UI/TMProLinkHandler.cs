using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMProLinkHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _variantsText;
    [SerializeField] private Canvas _canvasToCheck;
    [SerializeField] private Camera _camera;

    public event Action<string> OnClickedOnLink;

    private void Awake()
    {
        if (_canvasToCheck.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            _camera = null;
        }
        else
        {
            _camera = _canvasToCheck.worldCamera;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var mousePos = new Vector3(eventData.position.x, eventData.position.y, 0f);
        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(_variantsText, mousePos, _camera);
        if (linkTaggedText == -1)
        {
            return;
        }

        var linkInfo = _variantsText.textInfo.linkInfo[linkTaggedText];
        OnClickedOnLink?.Invoke(linkInfo.GetLinkText());
    }
}