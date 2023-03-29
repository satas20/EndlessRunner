using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAtractor : MonoBehaviour
{
    public float attractorStrenght = 5f;
    public float attractorRange = 5f;
    public float magnetDuration;
    public float magnetTimer;
    private void Start()
    {
        magnetTimer = magnetDuration;
    }
    private void Update()
    {
        
        magnetTimer -= Time.deltaTime;
        if (magnetTimer < 0){
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attractorRange);
        foreach(Collider hitCollider in hitColliders){
            if (hitCollider.CompareTag("Coin")) {
                hitCollider.transform.position = Vector3.Lerp(hitCollider.transform.position, transform.position,attractorStrenght);
                Vector3 forceDirection = transform.position - hitCollider.transform.position;
                //hitCollider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * attractorStrenght);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attractorRange);
    }
}
