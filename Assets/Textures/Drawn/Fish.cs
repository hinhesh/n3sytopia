using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Provides fish behavior including swimming animation, obstacle avoidance, and
/// wandering behavior.
/// </summary>
public class Fish : MonoBehaviour
{

   public float amplitude = 0.00001f;
    public float frequency = 1f;
    public float speed = 0.0004f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // Déplacement autonome en utilisant une fonction sinusoïdale
        float yOffset = amplitude * Mathf.Sin(frequency * (Time.time - startTime));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

        // Rotation pour simuler le mouvement naturel du poisson
        transform.Rotate(Vector3.up * Mathf.Sin(frequency * 0.5f * (Time.time - startTime)) * 10f);
    }
}
