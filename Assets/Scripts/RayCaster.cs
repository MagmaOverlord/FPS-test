using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    private Camera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0); //getting the middle of the screen
            Ray ray = _camera.ScreenPointToRay(point); //creates a ray at a position, specifically the position we just defined
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) { // out modifier puts information into the variable hit (not exactly what it does but it does tahat in this context)
                Debug.Log("Hit "+hit.point);
                StartCoroutine(SphereIndicator(hit.point)); //a coroutine is essentially like a thread, enables us to run multiple functions at once and pause one without pausing others
            }
        }
    }

    //spawn a sphere at a position
    private IEnumerator SphereIndicator(Vector3 pos) { //IEnumerators are "interfaces" - basically like an abstract class
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1); //yield means return to function after rteturn is executed

        Destroy(sphere);
    }
}
