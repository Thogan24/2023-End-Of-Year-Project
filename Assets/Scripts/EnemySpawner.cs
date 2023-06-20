using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] float Timer = 15f;
    [SerializeField] float minSpawnTime = 4f;
    [SerializeField] float maxSpawnTime = 6f;
    [SerializeField] Vector3 randomRotation;
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;
    [SerializeField] float OffsetZ;
    void Update()
    {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GameObject InstantiatedPrefab = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
                InstantiatedPrefab.transform.parent = GameObject.Find("GameObjects").transform;
                InstantiatedPrefab.SetActive(true);
                InstantiatedPrefab.GetComponent<Enemy>().enabled = true; // Enable the Enemy script on the spawned enemy
                Vector3 OffsetVector = new Vector3(Random.Range(-OffsetX, OffsetX), Random.Range(-OffsetY, OffsetY), Random.Range(-OffsetZ, OffsetZ));
                InstantiatedPrefab.transform.position = transforms[Random.Range(0, transforms.Length)].position + OffsetVector;
                randomRotation = new Vector3(90, Random.Range(0, 90), Random.Range(0, 90));
                InstantiatedPrefab.transform.Rotate(randomRotation);
                Timer = Random.Range(minSpawnTime, maxSpawnTime);
            }
    }
}