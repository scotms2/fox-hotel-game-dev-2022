using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputRay : MonoBehaviour
{
    public string scenename;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, mask))
        //    {
        //        Debug.Log(hit.transform.name);
        //        if (hit.transform.tag == "Player")
        //        {
        //            SceneManager.LoadScene(scenename);
        //        }
        //    }
        //}
    }
}
