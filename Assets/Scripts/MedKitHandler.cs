using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitHandler : MonoBehaviour
{
    public ParticleSystem DestroyParticle;

    public AudioSource DestroyAudio;
    
    public int HealthPointCount;

    private Coroutine damageCoroutine;


    public GameManager _GameManager;

    private void Start()
    {
        _GameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyParticle.transform.parent = null;
        DestroyAudio.transform.parent=null;

        DestroyParticle.Play();
        DestroyAudio.Play();

        Destroy(gameObject);

        _GameManager.Healing(HealthPointCount);
    }
}
