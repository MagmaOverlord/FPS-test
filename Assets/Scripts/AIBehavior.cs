using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;


    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<Player>()) {
                    //Debug.Log("I see you");
                    if (bullet == null) {
                        Debug.Log("I see you");
                        bullet = Instantiate(bulletPrefab) as GameObject;
                        bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        bullet.transform.rotation = transform.rotation;
                    }
                }

                //check to see if we're close enough to turn around
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-179, 180);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive) {
        _alive = alive; 
    }
}
