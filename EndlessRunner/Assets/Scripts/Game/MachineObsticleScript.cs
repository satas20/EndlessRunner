using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MachineObsticleScript : MonoBehaviour
{
    public GameObject kanca;
    public float time;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    IEnumerator ExampleCoroutine()
    {
        while (true) {
            kanca.transform.DORotate(new Vector3(-90, 0, -90), 1);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);
            kanca.transform.DORotate(new Vector3(-90, 0, 0), 0.5f);
            yield return new WaitForSeconds(2);
        }
        
        
    }
}
