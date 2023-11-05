using Cinemachine;
using UnityEngine;

public class FollowPlayerScript 
{
    private CinemachineVirtualCamera cam;
    public FollowPlayerScript(CinemachineVirtualCamera camera)
    {
        cam = camera;
    }
        
    public void FollowPlayer(TankView tankView)
    {
        cam.Follow = tankView.transform;
        cam.LookAt = tankView.transform;
    }
}