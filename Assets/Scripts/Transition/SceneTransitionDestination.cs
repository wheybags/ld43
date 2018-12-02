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

public class SceneTransitionDestination : MonoBehaviour
{
    public DestinationTag DestinationTag;

//    public UnityEvent OnReachDestination;
}