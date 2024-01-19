using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartLevel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}