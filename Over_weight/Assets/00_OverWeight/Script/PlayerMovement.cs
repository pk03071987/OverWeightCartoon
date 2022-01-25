using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float tryspeed;
    public bool leftw, rightw;
    Vector3 currentspeed;
    // Start is called before the first frame update
    public bool starshooting;
    float x;
    Vector3 a, direction, pressPos;
    public float speed, downwardSpeed;

    void Start()
    {
        currentspeed = new Vector3(tryspeed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            starshooting = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                x = hit.point.x;
                pressPos = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            starshooting = false;
        }

        if (Input.GetMouseButton(0) && transform.childCount > 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                direction = hit.point - pressPos;
                if (hit.point.x > x && !rightw)
                {
                    pressPos = Input.mousePosition;
                    float vx = hit.point.x - x;
                    x = hit.point.x;
                    a = transform.position;
                    a.x += vx * 1.5f;
                    transform.position = Vector3.SmoothDamp(transform.position, a, ref currentspeed, Time.deltaTime, speed * direction.normalized.magnitude);
                }

                if (hit.point.x < x && !leftw)
                {
                    pressPos = Input.mousePosition;
                    float vx = x - hit.point.x;
                    x = hit.point.x;
                    a = transform.position;
                    a.x -= vx * 1.5f;
                    transform.position = Vector3.SmoothDamp(transform.position, a, ref currentspeed, Time.deltaTime, speed * direction.normalized.magnitude);
                }
            }
        }
    }
}
