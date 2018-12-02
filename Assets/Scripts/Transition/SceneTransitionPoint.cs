using UnityEngine;
using SceneTransition;

[RequireComponent(typeof(Collider2D))]
public class SceneTransitionPoint : MonoBehaviour
{
    [SceneName]
    public string NewSceneName;

    [Tooltip("The tag of the SceneTransitionDestination script in the scene being transitioned to.")]
    public DestinationTag TransitionDestinationTag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneController.TransitionToScene(this);
        }
    }
}