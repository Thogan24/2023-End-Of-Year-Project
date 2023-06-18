using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    public GameObject hitCircleObject;
    public Camera fpsCam;
    public Vector3 hitRecoilPoint;


    [Header("Variables")]
    public float damage = 10f;
    public float range = 100f;
    public bool cooldown = true;
    public float cooldownTime = 0.2f;
    public bool recoilCooldown = true;
    public float time = 0f;
    public bool isShooting = false;
    public float shootingTime = 0f;
    public float recoilAmount = 0f;
    public float movingAccuracy = 1f;
    public float recoilAccuracy = 1f;


    private void Start()
    {
    }

    void Update()
    {
        time += Time.deltaTime;
        if (isShooting == true)
        {
            shootingTime += Time.deltaTime;
        }

        if (time > cooldownTime)
        {
            cooldown = false;
        }

        if (time > cooldownTime + 0.05f)
        {
            recoilCooldown = false;
            shootingTime = 0f;
            isShooting = false;
            recoilAmount = 0f;
            recoilAccuracy = 1f;
        }
        else
        {
            if (recoilAmount < 2.5f)
            {
                recoilAmount = shootingTime;
            }
            else if (recoilAccuracy < 10f)
            {
                Debug.Log(recoilAccuracy);
                recoilAccuracy = (shootingTime - 1.5f) * 3;
            }
            recoilCooldown = true;
        }

        if (Input.GetMouseButton(0) && cooldown == false)
        {
            isShooting = true;
            cooldown = true;
            time = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, new Vector3((Random.Range(-100, 100) * 0.0001f * movingAccuracy * recoilAccuracy) + fpsCam.transform.forward.x, (recoilAmount * 0.1f + (Random.Range(-100, 100) * 0.0001f * movingAccuracy * recoilAccuracy)) + fpsCam.transform.forward.y, fpsCam.transform.forward.z), out hit, range))
        {

            hitRecoilPoint = hit.point;


            GameObject hitCircle = Instantiate(hitCircleObject, hitRecoilPoint, Quaternion.LookRotation(hit.normal));
            Destroy(hitCircle, 5f);
            Debug.Log(hit);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {                
                enemy.TakeDamage(5f);
                PlayerStats playerstats = player.GetComponent<PlayerStats>();
                playerstats.currencyAmount += 5;
            }

        }
    }
}
