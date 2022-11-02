using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileMove : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] public float speed = 1.5f;

    //public float speed = 12f;
    Transform myTransform;
    //public Transform Target;
   

    // Start is called before the first frame update
    void Start()
    {
       
        myTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //myTransform.Translate(Vector3.up*Time.deltaTime*speed);

        //myTransform.Translate(new Vector3(10f, 10f, 10f) * Time.deltaTime, target.transform);
        //float step = Time.deltaTime * speed;
        //myTransform.transform.position = Vector3.MoveTowards(myTransform.transform.position, Target.position, step);

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;


        Destroy(this.gameObject, 3f);
    }
}
