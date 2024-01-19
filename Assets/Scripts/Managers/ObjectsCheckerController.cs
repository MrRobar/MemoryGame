using UnityEngine;

public class ObjectsCheckerController : MonoBehaviour
{
    [SerializeField] private GameObject _objectsChecker;
    [SerializeField] private TargetsStateHandler targetsStateHandler;
    [SerializeField] private VariantsUIHandler _variantsUIHandler;

    private void OnEnable()
    {
        targetsStateHandler.OnGroupRemoved += Enable;
        _variantsUIHandler.OnAllCorrectAnswersSelected += Disable;
    }

    private void OnDisable()
    {
        targetsStateHandler.OnGroupRemoved -= Enable;
        _variantsUIHandler.OnAllCorrectAnswersSelected -= Disable;
    }

    private void Enable()
    {
        _objectsChecker.SetActive(true);
    }

    private void Disable()
    {
        _objectsChecker.SetActive(false);
    }
}