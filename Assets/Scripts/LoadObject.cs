using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObject : MonoBehaviour
{
    int[,] WorldArray;

    [SerializeField]
    GameObject[] Prefabs;
 
    // Start is called before the first frame update
    void Start()
    {
        //WorldArray = new int [40, 16];

        WorldArray = new int [6, 29];

        for (int i=0; i<6; i++) {
            for (int j=0; j<29; j++) {
                WorldArray[i,j] = -1;
            }
        }

        int platforms = 0;
        int x = 0;
        int y = 0;

        while(platforms < 5) {
            x = Random.Range(0, 29);
            y = Random.Range(0, 6);

            if (WorldArray[y,x] == -1) {
                for (int k = -5; k<6; k++) {
                    for (int l =-5; l<6; l++) {
                        WorldArray[Mathf.Clamp(y+k, 0, 5), Mathf.Clamp(x+l, 0, 28)] = 0;
                    }
                }
                WorldArray[y,x] = 1;
                Instantiate(Prefabs[0], new Vector3 ((x * 0.5f) - 8f, (y * 0.5f) - 1f, -0.1f), Quaternion.identity);
                platforms++;
            }
        }
    }
}
