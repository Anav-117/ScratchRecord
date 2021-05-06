using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylController : MonoBehaviour
{
    [SerializeField]
    GameObject VinylPrefab;
    
    public AudioController audioRef;

    public bool Active;

    [SerializeField]
    GameObject Crowd;

    public int Number = 0;

    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Active = false;
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (audioRef.Loop) {
            Timer += Time.deltaTime;
            Crowd.transform.GetChild(1).GetComponent<AudioSource>().volume = Timer/10;
        }
        
        float Volume = Crowd.transform.GetChild(0).GetComponent<AudioSource>().volume;
        Crowd.transform.GetChild(0).GetComponent<AudioSource>().volume = Mathf.Lerp(Volume, 0.02f, 0.002f);
        
    }

    IEnumerator Spawn(){
        while(true) {
            if (!Active) {
                Active = true;                
                Crowd.transform.GetChild(1).GetComponent<AudioSource>().volume = 0;
                Crowd.transform.GetChild(0).GetComponent<AudioSource>().volume = 0.1f;
                yield return new WaitForSeconds(Random.Range(5, 10));
            }
            if (Active) {
                if (!audioRef.Loop) {
                    Instantiate(VinylPrefab, new Vector3((0.5f + Random.Range(-8, 7)), (0.5f + Random.Range(-2, 1)), 0), Quaternion.identity);
                    Timer = 0;
                    Crowd.transform.GetChild(1).GetComponent<AudioSource>().Stop();
                    Crowd.transform.GetChild(1).GetComponent<AudioSource>().Play();
                }
            }

            yield return null;
        }
    }
}
