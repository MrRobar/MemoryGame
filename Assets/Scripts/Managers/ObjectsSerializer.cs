using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class ObjectsSerializer : MonoBehaviour
{
    [SerializeField] private TargetsDetector _targetsDetector;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private IntersectedObjectsContainer _container;
    [SerializeField] private List<string> _namesToSerialize;
    private bool _canCollect = false;

    private const string _url = "http://51.250.110.85:8021/exercises/set_exercise_data";

    public event Action OnSuccessfulResponse;
    public event Action<string> OnResponseIdReceived;


    private void OnEnable()
    {
        _targetsDetector.OnShowText += SetCanField;
        _inputManager.OnSpacePressed += CollectAndSerialize;
    }

    private void OnDisable()
    {
        _targetsDetector.OnShowText -= SetCanField;
        _inputManager.OnSpacePressed -= CollectAndSerialize;
    }

    private void SetCanField(bool b)
    {
        _canCollect = b;
    }

    private void CollectAndSerialize()
    {
        if (!_canCollect)
        {
            return;
        }

        _namesToSerialize.Clear();
        _namesToSerialize = _container.FoundObjects.Select(x => x.name).ToList();
        string jsonData = JsonConvert.SerializeObject(_namesToSerialize);
        StartCoroutine(SendPostRequest(jsonData));
    }

    private IEnumerator SendPostRequest(string jsonBody)
    {
        using (UnityWebRequest request = new UnityWebRequest(_url, "POST"))
        {
            var bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var response = request.downloadHandler.text;
                var responseId = JsonConvert.DeserializeObject<string>(response);
                OnSuccessfulResponse?.Invoke();
                OnResponseIdReceived?.Invoke(responseId);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
            }
        }
    }
}