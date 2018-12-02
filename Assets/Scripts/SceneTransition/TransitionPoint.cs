using UnityEngine;
using SceneTransition;

[RequireComponent(typeof(Collider2D))]
public class TransitionPoint : MonoBehaviour
{
    public enum TransitionType
    {
        DifferentScene,
        SameScene
    }

    [SceneName] public string NewSceneName;

    [Tooltip("Whether the transition will be within this scene, to a different zone or a non-gameplay scene.")]
    public TransitionType Type;

    [Tooltip("The tag of the SceneTransitionDestination script in the scene being transitioned to.")]
    public DestinationTag TransitionDestinationTag;

    [Tooltip("The destination in this scene that the transitioning gameobject will be teleported.")]
    public TransitionDestination Destination;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Type == TransitionType.SameScene)
            {
                other.gameObject.transform.position = Destination.transform.position;
                other.gameObject.transform.rotation = Destination.transform.rotation;
            }
            else
            {
                SceneController.TransitionToScene(this);
            }
        }
    }
}