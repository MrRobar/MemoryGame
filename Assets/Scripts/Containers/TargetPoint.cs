using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> _connectedObjects;
    private bool _isActivated;
    private bool _keepActivated = false;

    public void Activate()
    {
        _isActivated = true;
    }

    public void Deactivate()
    {
        if (_keepActivated)
        {
            return;
        }

        _isActivated = false;
    }

    public void DisableObjects()
    {
        if (_isActivated)
        {
            _keepActivated = true;
        }

        foreach (var go in _connectedObjects)
        {
            go.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    public void EnableObjects()
    {
        if (_isActivated)
        {
            gameObject.SetActive(false);
            return;
        }

        foreach (var go in _connectedObjects)
        {
            go.SetActive(true);
        }
    }
}