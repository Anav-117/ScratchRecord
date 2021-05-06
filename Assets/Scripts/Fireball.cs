using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    int dir = 0;

    [SerializeField, Range(0, 10)]
    float FireBallSpeed = 5;

    Animator Anim;

    bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0) {
            dir = 1;
        }
        else {
            dir = -1;
        }
        Anim = GetComponent<Animator>();
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float YPos = transform.position.y;
        
        if (!destroyed) {
            transform.position = new Vector3 (transform.position.x + (dir * FireBallSpeed * Time.deltaTime), YPos, 0);
            transform.localScale = new Vector3 (dir, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(other);
            Destroy(gameObject); 
        }
        if (other.gameObject.tag != "Vinyl") {
            Destroy(gameObject);
        }
    }
}
