
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
public SpriteRenderer graphics;

    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        //if the ennemy is almost at destination
        if(Vector3.Distance(transform.position, target.position)< 0.3f){

        destPoint = (destPoint + 1) % waypoints.Length;
        target = waypoints[destPoint]; 
        graphics.flipX = !graphics.flipX; 


        }

    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.transform.CompareTag("Player")){
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
