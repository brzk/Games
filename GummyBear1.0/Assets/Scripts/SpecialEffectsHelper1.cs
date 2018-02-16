using UnityEngine;
using System.Collections;
public class SpecialEffectsHelper1 : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper1 Instance1;

    public ParticleSystem pistolEffect;
    public ParticleSystem shotGunEffect;
    public ParticleSystem gunEffect;
    public ParticleSystem laserEffect;

    void Awake()
    {
        Instance1 = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position, string bulletTag)
    {
        switch (bulletTag)
        {
            case("pistolBullet"):
                {
                    instantiate(pistolEffect, position);
                    break;
                }
            case ("shotgunBullet"):
                {
                    instantiate(shotGunEffect, position);
                    break;
                }
            case ("laserBullet"):
                {
                    instantiate(laserEffect, position);
                    break;
                }
            case ("flamethrowerBullet"):
                {
                    instantiate(gunEffect, position);
                    break;
                }
        }
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