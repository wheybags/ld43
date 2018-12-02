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

//    public UnityEvent OnReachDestination;
}