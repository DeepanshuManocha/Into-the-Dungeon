using UnityEngine;

public class EnemiesShreyansh : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retratDistance;
    private float TimeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private Transform player;
    public Transform Player;
    public int health = 1;
    public void Takedamage(int damage)
    {
        health -= damage;
        print(health);
        if (health == 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);

    }

    // void movingPath()
    // {
    //     enemies.AddForce(new Vector3(1f, 1f, 0f), ForceMode.Impulse);
    // }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);


        }
        else if (Vector3.Distance(transform.position, Player.position) < stoppingDistance && Vector3.Distance(transform.position, Player.position) > retratDistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector3.Distance(transform.position, Player.position) < retratDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);

        }

        if (TimeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            TimeBtwShots = startTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
