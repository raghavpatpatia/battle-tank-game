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
        cam.m_Lens.OrthographicSize = 10;
        cam.Follow = tankView.transform;
        cam.LookAt = tankView.transform;
    }
}