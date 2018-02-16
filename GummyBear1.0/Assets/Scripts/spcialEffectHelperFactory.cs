using UnityEngine;
using System.Collections;

public class spcialEffectHelperFactory : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    public static spcialEffectHelperFactory Instance;

    public ParticleSystem smoke1;
    public ParticleSystem smoke2;

    void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position)
    {
       
         instantiate(smoke1, position);
         instantiate(smoke2, position);
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
