using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject go;
    public float speed = 2.0f;
    public float xMin,xMax,yMin,yMax;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x= Mathf.Clamp(go.transform.position.x,xMin,xMax);
        float y = Mathf.Clamp(go.transform.position.y, yMin, yMax);


        //float interpolation = speed * Time.deltaTime;

        //Vector3 position = this.transform.position;

        //if (go.transform.position.y > -1.69)
            //position.y = Mathf.Lerp(this.transform.position.y, go.transform.position.y, interpolation);

        //if (go.transform.position.x > 0)
            //position.x = Mathf.Lerp(this.transform.position.x, go.transform.position.x, interpolation);

        this.transform.position = new Vector3(x,y,this.transform.position.z);


    }

}
