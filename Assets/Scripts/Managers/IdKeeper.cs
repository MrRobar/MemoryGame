using UnityEngine;

public class IdKeeper : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private ObjectsSerializer _serializer;
    public string ID => _id;

    private void OnEnable()
    {
        _serializer.OnResponseIdReceived += UpdateID;
    }

    private void OnDisable()
    {
        _serializer.OnResponseIdReceived -= UpdateID;
    }

    private void UpdateID(string id)
    {
        _id = id;
    }
}