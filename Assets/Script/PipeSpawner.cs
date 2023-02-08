using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin;
    public float yPosMax;
    
    IEnumerator SpawnPipeCoroutine() {
        yield return new WaitForSeconds(spawnTime);

        Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
        StartCoroutine(SpawnPipeCoroutine());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
