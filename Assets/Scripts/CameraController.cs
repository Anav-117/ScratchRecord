using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject CameraObject;
    Camera cam;
    GameObject Player;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.GetChild(0).gameObject;
        CameraObject = transform.GetChild(1).gameObject;
        cam = CameraObject.GetComponent<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player) {
            float cameraX = CameraObject.transform.position.x;
            float cameraY = CameraObject.transform.position.y;
            Vector2 PlayerPos = Player.transform.position;
                if ((Mathf.Abs(PlayerPos.x - cameraX) > 0.5f) || (Mathf.Abs(PlayerPos.y - cameraY) > 0.5f)) {
                    moving = true;
            }
            
            if (moving) {
                cameraX = Mathf.Clamp(Mathf.Lerp(cameraX, PlayerPos.x, Mathf.Abs(PlayerPos.x - cameraX)/10), -4.5f, 5.5f);
                cameraY = Mathf.Clamp(Mathf.Lerp(cameraY, PlayerPos.y, Mathf.Abs(PlayerPos.y - cameraY)/10), -1, 20);
                if (Input.GetKeyDown("f")) {
                    float[] CamPos = CameraShake(cameraX, cameraY);
                    CameraObject.transform.position = new Vector3(CamPos[0], CamPos[1], -5);    
                }
                else {
                    CameraObject.transform.position = new Vector3(cameraX, cameraY, -5);
                }
                
            }

            if ((Mathf.Abs(PlayerPos.x - cameraX) < 0.1f) || (Mathf.Abs(PlayerPos.x - cameraX) < 0.1f)) {
                moving = false;
            }
            
        }
    }

    float[] CameraShake(float cameraX, float cameraY) {
        float[] CamPos = {cameraX+0.5f, cameraY+0.5f};
        return CamPos;
    }
}
