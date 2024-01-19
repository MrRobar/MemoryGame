using System;
using UnityEngine;

public class TargetsDetector : MonoBehaviour
{
    public event Action<bool> OnShowText;
    private TargetPoint _current;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.targetTag))
        {
            _current = other.GetComponent<TargetPoint>();
            _current.Activate();
            OnShowText?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Consts.targetTag))
        {
            _current.Deactivate();
            _current = null;
        }

        OnShowText?.Invoke(false);
    }
}