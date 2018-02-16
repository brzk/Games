using UnityEngine;
using System.Collections;
public class SpecialEffectsHelper5 : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper5 Instance5;

    public ParticleSystem pistolEffect;
    public ParticleSystem shotGunEffect;
    public ParticleSystem gunEffect;
    public ParticleSystem laserEffect;
    public ParticleSystem laserEffect2;

    void Awake()
    {
        Instance5 = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position, string bulletTag)
    {
        instantiate(pistolEffect, position);
        instantiate(shotGunEffect, position);
        instantiate(laserEffect, position);
        instantiate(laserEffect2, position);
        instantiate(gunEffect, position);
        
    }

    /// <summary>
    /// Instantiate a Particle system from prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}