using Photon.Pun;
using UnityEngine;
using Zenject;

public class PhotonViewInstaller : MonoInstaller
{
    [SerializeField] private GameObject photonViewPrefab;

    public override void InstallBindings()
    {
        var photonViewInstance = PhotonNetwork.Instantiate(photonViewPrefab.name, Vector3.zero, Quaternion.identity).GetComponent<PhotonView>();
            
        Container.Bind<PhotonView>().FromInstance(photonViewInstance);
    }
}