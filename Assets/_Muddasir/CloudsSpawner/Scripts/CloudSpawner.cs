using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] Clouds;
    private List<GameObject> CloudsPool = new List<GameObject>();
    private List<GameObject> CloudsPool_Spawned = new List<GameObject>();
    public int poolSize = 100;

    public float SpawnRate = 1;
    public int CountPerSpawn = 1;


    public float DistnceToDeSpawn = 50;
    public float speed = 2;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        GameObject go = null;
        while (CloudsPool.Count < poolSize)
        {
            go = Instantiate(Clouds[Random.Range(0, Clouds.Length)]);
            go.transform.parent = this.transform;
            go.SetActive(false);
            CloudsPool.Add(go);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(FirstSpawn());
    }

    // Update is called once per frame
    private void Update()
    {

    }
    private IEnumerator FirstSpawn()
    {
        for (int j = 0; j < 30; j++)
        {
                if (CloudsPool.Count > 0)
                {
                    GameObject go = CloudsPool[CloudsPool.Count - 1];
                    CloudsPool.Remove(go);
                    CloudsPool_Spawned.Add(go);

                    go.transform.position = transform.position
                        + ((transform.forward * Random.Range(0, DistnceToDeSpawn))
                        + (transform.up * Random.Range(-(transform.localScale.y / 2), transform.localScale.y / 2))
                        + (transform.right * Random.Range(-(transform.localScale.x / 2), transform.localScale.x / 2)));
                    go.SetActive(true);

                    StartCoroutine(Move(go));
                }
                yield return null;
            
        }

        StartCoroutine(Spawning());
    }
    private IEnumerator Spawning()
    {
        while (true)
        {
            for (int i = 0; i < CountPerSpawn; i++)
            {
                Spawn();
                yield return null;
            }
            yield return new WaitForSeconds(SpawnRate);
        }
    }

    void Spawn()
    {
        if (CloudsPool.Count > 0)
        {
            GameObject go = CloudsPool[CloudsPool.Count - 1];
            CloudsPool.Remove(go);
            CloudsPool_Spawned.Add(go);

            go.transform.position = transform.position
                + ((transform.forward * Random.Range(-(transform.localScale.z / 2), transform.localScale.z / 2))
                + (transform.up * Random.Range(-(transform.localScale.y / 2), transform.localScale.y / 2))
                + (transform.right * Random.Range(-(transform.localScale.x / 2), transform.localScale.x / 2)));
            go.SetActive(true);

            StartCoroutine(Move(go));
        }

    }

    private IEnumerator Move(GameObject go)
    {
        while (Vector3.Distance(transform.position, go.transform.position) < DistnceToDeSpawn)
        {
            go.transform.Translate(transform.forward * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
        go.SetActive(false);
        CloudsPool_Spawned.Remove(go);
        CloudsPool.Add(go);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }


}
