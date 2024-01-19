using System;
using UnityEngine;

public class CheckerDetector : MonoBehaviour
{
    public event Action<bool> OnShowText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.objectChecker))
        {
            OnShowText?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Consts.objectChecker))
        {
            OnShowText?.Invoke(false);
        }
    }
}
