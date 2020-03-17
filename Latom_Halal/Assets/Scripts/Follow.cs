using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.0f;
    private Transform target;
    public Vector3 distance;


    void Start()
    {
        target = player.transform;
    }
    
    void Update()
    {
        distance = player.transform.position - transform.position;    
        Quaternion rotation = Quaternion.LookRotation(distance);
        float step;
        // An if to get the monster to only chase if within distance.
        if(distance.x < 15 && distance.y < 10 && distance.z < 15)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.rotation = rotation;
        }

       // step = speed * Time.deltaTime;
       // transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
