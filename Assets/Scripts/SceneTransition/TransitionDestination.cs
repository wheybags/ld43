using UnityEngine;

public enum DestinationTag
{
    Left,
    Right,
    Top,
    Bottom,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
}

public class TransitionDestination : MonoBehaviour
{
    public DestinationTag DestinationTag;

    [Tooltip("This is the gameobject that has transitioned.  For example, the player.")]
    public GameObject TransitioningGameObject;

//    public UnityEvent OnReachDestination;
}