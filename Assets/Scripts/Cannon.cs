using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject Fireball;

    Vector3 Pos;

    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        Pos = new Vector3 (transform.position.x + (0.5f * -Mathf.Sign(transform.position.x)), transform.position.y, 0);
        start = false;
        StartCoroutine("SpawnFireball");
    }

    IEnumerator SpawnFireball() {
        while(true) {
            if (start) {
                Instantiate(Fireball, Pos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
            else if (!start) {
                start = true;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
