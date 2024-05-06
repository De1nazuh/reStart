using UnityEngine;

public class LevelBlock : MonoBehaviour
{
    public Transform endPosition;
    public LevelBlock[] levelBlockPrefabs;

    public ColliderSignals endPositionSignals;
    public ColliderSignals startPositionSignals;
}
