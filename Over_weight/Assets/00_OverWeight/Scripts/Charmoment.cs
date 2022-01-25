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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fat")
        {
            Destroy(other.gameObject);
            //eff[Random.Range(0, eff.Length)].Play();
            //if (body.GetBlendShapeWeight(0) < 100 && body.GetBlendShapeWeight(1) == 0)
            //{
            //    playerScore += 10;
            //    bodysizefat = body.GetBlendShapeWeight(0) + 25;
            //}
            //else if (body.GetBlendShapeWeight(1) > 0)
            //{
            //    playerScore += 10;
            //    bodysizefit = body.GetBlendShapeWeight(1) - 25;
            //}

            //body.SetBlendShapeWeight(0, bodysizefat);
            //dress.SetBlendShapeWeight(0, bodysizefat);
            //body.SetBlendShapeWeight(1, bodysizefit);
            //dress.SetBlendShapeWeight(1, bodysizefit);

        }

        if (other.gameObject.tag == "diet")
        {
            Destroy(other.gameObject);
            //eff[Random.Range(0, eff.Length)].Play();

            //if (body.GetBlendShapeWeight(1) < 100 && body.GetBlendShapeWeight(0) == 0)
            //{
            //    playerScore -= 10;
            //    bodysizefit = body.GetBlendShapeWeight(1) + 25;
            //}
            //else if (body.GetBlendShapeWeight(0) > 0)
            //{
            //    playerScore -= 10;
            //    bodysizefat = body.GetBlendShapeWeight(0) - 25;
            //}
            //body.SetBlendShapeWeight(0, bodysizefat);
            //dress.SetBlendShapeWeight(0, bodysizefat);
            //body.SetBlendShapeWeight(1, bodysizefit);
            //dress.SetBlendShapeWeight(1, bodysizefit);
            gamemanager.instance.setcoin(gamemanager.instance.getcoin() + 10);
            //SoundManager.instance.playVibration();
        }
        Debug.Log("trigger stay"+other.tag);
        isInBoxRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInBoxRange = false;
    }
}
