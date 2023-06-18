using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] GameObject[] Prefabs;
    [SerializeField] float Timer = 0;
    public int enemyCount = 0;
    [SerializeField] float minSpawnTime = 5f;
    [SerializeField] float maxSpawnTime = 10f;
    [SerializeField] Vector3 randomRotation;
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;
    [SerializeField] float OffsetZ;
    void Update()
    {
        if (enemyCount <= 5)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GameObject InstantiatedPrefab = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
                InstantiatedPrefab.SetActive(true);
                Vector3 OffsetVector = new Vector3(Random.Range(-OffsetX, OffsetX), Random.Range(-OffsetY, OffsetY), Random.Range(-OffsetZ, OffsetZ));
                InstantiatedPrefab.transform.position = transforms[Random.Range(0, transforms.Length)].position + OffsetVector;
                randomRotation = new Vector3(90, Random.Range(0, 90), Random.Range(0, 90));
                InstantiatedPrefab.transform.Rotate(randomRotation);
                Timer = Random.Range(minSpawnTime, maxSpawnTime);
                enemyCount++;
            }
        }
    }
}