using System;
using ComponentViews;
using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private SpawnPositionComponents spawnPositionComponents;
        private int _playersNumber;
        
    }
}