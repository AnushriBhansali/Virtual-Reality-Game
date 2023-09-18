using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    public float minDirection=1.5f;

    public GameObject sparksVFX;

    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Method 1
        //transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate() {
        if (stopped)
        return;

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {

        bool hit =false;

        if (other.CompareTag("Wall")){
            direction.z= -direction.z;
            hit=true;
        }

        if (other.CompareTag("Racket")){
            direction.x= -direction.x;
            hit=true;

        }

        if (hit){
           GameObject sparks= Instantiate(this.sparksVFX, transform.position, transform.rotation);
           Destroy(sparks, 4f);
        }

       }
        private void ChooseDirection() {

            float signX = Mathf.Sign(Random.Range(-1f, 1f));
            float signZ = Mathf.Sign(Random.Range(-1f, 1f));
            

            this.direction = new Vector3(0.5f, 0, 0.5f);

        }

        public void Stop(){
            this.stopped = true;
        }

        public void Go() {
            ChooseDirection();
            this.stopped = false;
        }
}

