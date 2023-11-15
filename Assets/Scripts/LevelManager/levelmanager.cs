using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : GenericSingleton<levelmanager>
{
    [SerializeField] private GameObject[] entities;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float CameraOrthoSize;
    private Coroutine destroyLevel;
    protected override void Awake()
    {
        base.Awake();
    }

    public void DestroyEverythingCoroutine()
    {
        if (destroyLevel != null)
        {
            StopCoroutine(destroyLevel);
        }
        destroyLevel = StartCoroutine(DestroyLevel());
    }

    private IEnumerator DestroyLevel()
    {
        yield return StartCoroutine(Camera());
        yield return StartCoroutine(EnemyTankService.Instance.DestroyAllEnemies());
        yield return StartCoroutine(DestroyEnvironment());
    }

    private IEnumerator DestroyEnvironment()
    {
        foreach(GameObject item in entities)
        {
            yield return StartCoroutine(DestroyEntity(item));
            if (item == null)
            {
                continue;
            }
            Destroy(item);
            ParticleSystems.Instance.PlayParticles(item.transform, Particles.BuildingExplosion, 2);
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator DestroyEntity(GameObject entity)
    {
        List<Transform> childObjects = new List<Transform>();
        foreach (Transform item in entity.GetComponentsInChildren<Transform>())
        {
            if (item.childCount != 0)
            {
                continue;
            }

            childObjects.Add(item);
        }
        foreach (Transform item in childObjects)
        {
            Destroy(item.gameObject);
            ParticleSystems.Instance.PlayParticles(item, Particles.BuildingExplosion, 2);
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Camera()
    {
        while (cam.m_Lens.OrthographicSize < CameraOrthoSize)
        {
            cam.m_Lens.OrthographicSize += 1f;
            yield return new WaitForSeconds(0.05f);
        }
    }

}