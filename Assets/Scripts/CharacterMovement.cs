using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _RB;
    [SerializeField] private int _force = 10;

    [SerializeField] private float gravityModifier;

    [SerializeField] private bool _onGround;

    public bool GameOver = false;

    private Animator playerAnim;

    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private ParticleSystem dirtParticle;
    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && _onGround && !GameOver)
        {
            dirtParticle.Stop();
            _RB.AddForce(Vector3.up * _force, ForceMode.Impulse);
            _onGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
            dirtParticle.Play();
        } else if(other.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();
            
            
        }
    }
}
