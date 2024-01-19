using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class LoadRightAnswers : MonoBehaviour
{
    [SerializeField] private ObjectSelectionTextController _objectSelectionTextController;
    [SerializeField] private IdKeeper _idKeeper;
    [SerializeField] private string[] _correctAnswers;

    public string[] CorrectAnswers => _correctAnswers;

    private void OnEnable()
    {
        _objectSelectionTextController.OnShowNextText += GetNames;
    }

    private void OnDisable()
    {
        _objectSelectionTextController.OnShowNextText -= GetNames;
    }

    private void GetNames()
    {
        StartCoroutine(GetNamesFromServer(_idKeeper.ID));
    }

    public IEnumerator GetNamesFromServer(string recordId)
    {
        string url = $"http://51.250.110.85:8021/exercises/get_exercise_data?record_id={recordId}";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error while sending GET request: {www.error}");
                yield break;
            }

            string json = www.downloadHandler.text;
            _correctAnswers = JsonConvert.DeserializeObject<string[]>(json);
        }
    }
}