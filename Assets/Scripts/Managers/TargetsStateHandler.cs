using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetsStateHandler : MonoBehaviour
{
    [SerializeField] private ObjectsSerializer _objectsSerializer;
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    [SerializeField] private List<TargetPoint> _targets;

    public event Action OnGroupRemoved;

    private void OnEnable()
    {
        _objectsSerializer.OnSuccessfulResponse += DisableGroups;
        _variantsUIHandler.OnAllCorrectAnswersSelected += EnableGroups;
    }

    private void OnDisable()
    {
        _objectsSerializer.OnSuccessfulResponse -= DisableGroups;
        _variantsUIHandler.OnAllCorrectAnswersSelected -= EnableGroups;
    }

    private void DisableGroups()
    {
        foreach (var target in _targets)
        {
            target.DisableObjects();
        }

        OnGroupRemoved?.Invoke();
    }

    private void EnableGroups()
    {
        foreach (var target in _targets)
        {
            target.gameObject.SetActive(true);
            target.EnableObjects();
        }
    }
}