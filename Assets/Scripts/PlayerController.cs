using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    float MaxSpeed = 2.5f;

    [SerializeField, Range(0, 10)]
    float JumpForce = 5;

    bool jumping = false;
    int jumpCount = 0;

    Rigidbody2D rb;

    AudioSource JumpAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        JumpAudio = gameObject.GetComponent<AudioSource>();
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !jumping) {
            if (jumpCount == 0) {
                rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            }
            else if (jumpCount == 1) {
                rb.velocity = Vector3.zero;
                rb.AddForce(transform.up * JumpForce / 1, ForceMode2D.Impulse);
            }
            JumpAudio.Stop();
            JumpAudio.Play();

            jumpCount++;
            
            if (jumpCount >= 2) {
                jumping = true;
            } 
        }

        float Horizontal = Input.GetAxis("Horizontal") * MaxSpeed * Time.deltaTime;

        float Xpos = transform.position.x;
        float Ypos = transform.position.y;

        if (Mathf.Abs(Horizontal) > 0) {
            Xpos = Mathf.Clamp(Xpos + Horizontal, -8.2f, 9.3f);

            transform.localScale = new Vector3(Horizontal/Mathf.Abs(Horizontal), 1, 1);

            transform.position = new Vector3 (Xpos, Ypos, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.rotation.z == 0) {
            jumping = false;
            jumpCount = 0;
        }
    }
}
