using System;
using UnityEngine;

public class ParticleSystems : GenericSingleton<ParticleSystems>
{
    [SerializeField] private Particle[] particle;
    protected override void Awake()
    {
        base.Awake();
    }

    public void PlayParticles(Transform location, Particles particle, float time)
    {
        ParticleSystem particleSystem = GetParticleSystem(particle);
        if (particleSystem != null)
        {
            ParticleSystem newParticleSystem = Instantiate(particleSystem, location.position, location.rotation);
            newParticleSystem.Play();
            Destroy(newParticleSystem.gameObject, time);
        }
        else
        {
            Debug.LogError("Particle System not found, Particle Type: " + particle);
        }
    }
    private ParticleSystem GetParticleSystem(Particles particles)
    {
        Particle p = Array.Find(particle, i => i.particle == particles);
        if (p != null)
        {
            return p.particleSystem;
        }
        return null;
    }
}