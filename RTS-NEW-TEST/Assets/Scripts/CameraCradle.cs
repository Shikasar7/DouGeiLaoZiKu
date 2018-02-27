using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCradle : MonoBehaviour {

      public float near = 20.0f;
      public float far = 100.0f;
  
     public float sensitivityX = 10f;
     public float sensitivityY = 10f;
     public float sensitivetyZ = 2f;
     public float sensitivetyMove = 2f;
     public float sensitivetyMouseWheel = 2f;
     public float Speed = 50;
    //相机移动速度

    void Update()
    {
                // 滚轮实现镜头缩进和拉远
         if (Input.GetAxis("Mouse ScrollWheel") != 0)
                    {
                        this.GetComponent<Camera>().fieldOfView = this.GetComponent<Camera>().fieldOfView - Input.GetAxis("Mouse ScrollWheel") * sensitivetyMouseWheel;
                        this.GetComponent<Camera>().fieldOfView = Mathf.Clamp(this.GetComponent<Camera>().fieldOfView, near, far);
                    }
               

   
            transform.Translate(
            Input.GetAxis("Horizontal") * Speed * Time.deltaTime,
            Input.GetAxis("Vertical") * Speed * Time.deltaTime,
            0);
    }


}
 



