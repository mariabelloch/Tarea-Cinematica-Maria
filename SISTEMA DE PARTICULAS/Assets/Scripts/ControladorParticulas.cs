using System.Collections.Generic;
using UnityEngine;

public class ControladorParticulas : MonoBehaviour
{
    public GameObject particlePrefab;

    public int numberOfParticles = 20;
    public float initialSpeed = 5f;
    public float angle = 45f;
    public float lifeTime = 3f;
    public float gravity = 9.8f;

    private List<GameObject> particles = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateParticleExplosion();
        }

        UpdateParticleExplosion();
    }

    void CreateParticleExplosion()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            GameObject p = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            Particula particleScript = p.GetComponent<Particula>();

            particleScript.initialSpeed = initialSpeed + Random.Range(-2f, 2f);
            particleScript.angle = Random.Range(0f, 360f);
            particleScript.maxLifeTime = lifeTime + Random.Range(-1f, 1f);
            particleScript.gravity = gravity;

            particles.Add(p);
        }
    }

    void UpdateParticleExplosion()
    {
        for (int i = particles.Count - 1; i >= 0; i--)
        {
            Particula p = particles[i].GetComponent<Particula>();

            p.UpdateParticle(Time.deltaTime);

            if (p.currentLifeTime >= p.maxLifeTime)
            {
                Destroy(particles[i]);
                particles.RemoveAt(i);
            }
        }
    }
}
