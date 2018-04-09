using UnityEngine;
using System.Collections;

public class EnemyAItest : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    [SerializeField]
    public static float range;
    public float fireRate = 1;
    public float fireCount = 0;
    public float turnSpeed = 5;

    public float GunSpeed;
    public float GunDamage;
    public float GunDrop;
    [SerializeField]
    public  static bool canMove;
    public bool canMoveAi = false;

    public string enemyTag = "Player";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firepoint;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            canMoveAi = true;
            target = nearestEnemy.transform;
        }
        else
        {
            canMoveAi = false;
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveAi == true)
        {
            canMove = true;
        }
        else if (canMoveAi == false)
        {
            canMove = false;
        }


        if (target == null)
        {
            range = 8;
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

        if (fireCount <= 0f)
        {
            Shooting();
            fireCount = 1f + fireRate;
        }
        fireCount -= Time.deltaTime;
    }

    void Shooting()
    {
        range = 12;
        GameObject bullet = Instantiate(bulletPrefab, firepoint.transform.position, firepoint.transform.rotation);
        BulletCode BullInfo = bullet.GetComponent<BulletCode>();
        //bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right);
        BullInfo.Speed = GunSpeed;
        BullInfo.Damage = GunDamage;
        BullInfo.Drop = GunDrop;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}