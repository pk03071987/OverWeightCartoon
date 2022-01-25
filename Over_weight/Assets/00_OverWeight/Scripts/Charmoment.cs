using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Charmoment : MonoBehaviour
{
    [SerializeField] bool isInBoxRange = false;
    [SerializeField] Rigidbody body;
    [SerializeField] bool useCamDirection = false;
    [SerializeField] bool startMove = false;
    [SerializeField] Transform character;
    [SerializeField] float forwardSpeed = 2f;
    [SerializeField] float downwardSpeed = 2f;
    [SerializeField] Vector3 speed;
    [SerializeField] Vector3 speed2;
    Vector3 camDirection;
    // Start is called before the first frame update
    void Start()
    {
        camDirection = character.forward;
    }
    public void DoRestart()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        if(startMove)
        {
        
            if(!useCamDirection)
            {
                if(!isInBoxRange)
                character.Translate(speed * Time.deltaTime, Space.World);
                else
                {
                character.Translate(speed2 * Time.deltaTime, Space.World);

                }
            }
            else
            {
                 character.position += (camDirection * Time.deltaTime * forwardSpeed);
                //body.MovePosition(body.position + (camDirection * Time.deltaTime * forwardSpeed));
            }
        }
    }
  
}
