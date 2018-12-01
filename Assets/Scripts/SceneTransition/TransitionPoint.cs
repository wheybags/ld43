using UnityEngine;
using SceneTransition;

[RequireComponent(typeof(Collider2D))]
public class TransitionPoint : MonoBehaviour
{
    [Tooltip("This is the gameobject that will transition.  For example, the player.")]
    public GameObject TransitioningGameObject;

    [SceneName]
    public string NewSceneName;

    [Tooltip("The tag of the SceneTransitionDestination script in the scene being transitioned to.")]
    public DestinationTag TransitionDestinationTag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == TransitioningGameObject)
        {
            SceneController.TransitionToScene(this);
        }
    }
}