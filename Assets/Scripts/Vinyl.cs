using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinyl : MonoBehaviour
{
    [SerializeField, Range(0, 200)]
    float MaxRotationSpeed = 100;

    Vector3 EulerAngles;
    Quaternion CurrRotation;

    GameObject audioControllerObject;
    public AudioController audioController;
    GameObject VCObject;
    VinylController VC;

    // Start is called before the first frame update
    void Start()
    {
        EulerAngles = transform.rotation.eulerAngles;    
        audioControllerObject = GameObject.FindGameObjectsWithTag("Audio")[0];
        audioController = audioControllerObject.GetComponent<AudioController>();
        audioController.LoopPoint = audioController.audioSource.timeSamples / audioController.audioClip.frequency;
        audioController.Loop = true;
        VCObject = GameObject.FindGameObjectsWithTag("VC")[0];
        VC = VCObject.GetComponent<VinylController>();
    }

    // Update is called once per frame
    void Update()
    {
            EulerAngles += new Vector3(0, 0, 1) * MaxRotationSpeed * Time.deltaTime;
            CurrRotation.eulerAngles = EulerAngles;
            transform.rotation = CurrRotation;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            audioController.Loop = false;
            audioController.resume = true;
            VC.Active = false;
            Destroy(gameObject);
        }
    }
}
