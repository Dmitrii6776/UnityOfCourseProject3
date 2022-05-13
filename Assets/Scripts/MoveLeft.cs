using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private int speed = 30;
    [SerializeField] private int leftBound = -15;


    private CharacterMovement playerControlSc;
    // Start is called before the first frame update
    void Start()
    {
        playerControlSc = GameObject.Find("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlSc.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
