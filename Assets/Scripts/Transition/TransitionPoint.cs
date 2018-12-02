using UnityEngine;
using SceneTransition;

[RequireComponent(typeof(Collider2D))]
public class TransitionPoint : MonoBehaviour
{
    [Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
    public Transform Destination;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Destination.transform.position;
            other.gameObject.transform.rotation = Destination.transform.rotation;
        }
    }
}