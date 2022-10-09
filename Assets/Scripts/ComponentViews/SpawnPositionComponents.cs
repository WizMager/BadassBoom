using UnityEngine;

namespace ComponentViews
{
    public class SpawnPositionComponents : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;

        public Transform[] GetSpawnPositions => spawnPositions;
    }
}