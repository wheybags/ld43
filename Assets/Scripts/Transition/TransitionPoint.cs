using UnityEngine;
using SceneTransition;

[RequireComponent(typeof(Collider2D))]
public class TransitionPoint : MonoBehaviour
{
    [Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
    public Transform Destination;
    public Transform CameraDestination;

    private GameObject _camera;

    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Destination.transform.position;
            other.gameObject.transform.rotation = Destination.transform.rotation;
            _camera.transform.position = new Vector3(CameraDestination.position.x, CameraDestination.position.y, -10);
        }
    }
}