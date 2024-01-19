using System.Collections.Generic;
using UnityEngine;

public class IntersectedObjectsContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _foundObjects;

    public List<GameObject> FoundObjects => _foundObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Consts.targetTag) || other.CompareTag(Consts.centerTag))
        {
            return;
        }
        _foundObjects.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _foundObjects.Remove(other.gameObject);
    }
}