using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] GameObject RuntimePool;
    [SerializeField] int scoreBonus = 12;
    ScoreBoard scoreBoard;



    public void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    [Header("Prefabs")]
    [Tooltip("Explosion gameObject")] [SerializeField] GameObject explosion;
    private void OnParticleCollision(GameObject other)
    {
        
        GameObject obj = Instantiate(explosion, transform.position, transform.rotation);
        obj.transform.parent = RuntimePool.transform;
        Destroy(gameObject);
        scoreBoard.ScoreHit(scoreBonus); // todo revisar se devo utilizar static e aqui neste local 

    }
}

