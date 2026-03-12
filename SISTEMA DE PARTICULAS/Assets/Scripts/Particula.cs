using UnityEngine;

public class Particula : MonoBehaviour
{
    public float initialSpeed;
    public float angle;
    public float maxLifeTime;
    public float currentLifeTime;
    public float gravity;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        currentLifeTime = 0f;
    }

    public void UpdateParticle(float time)
    {
        currentLifeTime += time;

        float rad = angle * Mathf.Deg2Rad;

        float x = initialSpeed * Mathf.Cos(rad) * currentLifeTime;
        float y = (initialSpeed * Mathf.Sin(rad) * currentLifeTime)
                  - (0.5f * gravity * currentLifeTime * currentLifeTime);

        transform.position = startPosition + new Vector3(x, y, 0);
    }
}
