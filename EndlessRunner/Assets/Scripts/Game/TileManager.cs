using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    [SerializeField] float zSpawn ;
    [SerializeField] float tileLenght = 30;
    private List<GameObject> activeTiles= new List<GameObject>();
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z+tileLenght*3 > zSpawn){
            SpawnTile();
            DeleteTile();
        }
    }
    public void SpawnTile() 
    {

        int random = Random.Range(0,tilePrefabs.Length);
        Debug.Log("random :" + random);
        GameObject spawnedTile =Instantiate(tilePrefabs[random], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(spawnedTile);
        zSpawn += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
