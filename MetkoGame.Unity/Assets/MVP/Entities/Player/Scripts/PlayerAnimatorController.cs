using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

namespace MVP
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] Animator _controller;
        [SerializeField] PlayerMovementController _player;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _controller.SetFloat("Speed", _player.CharacterController.velocity.sqrMagnitude);
            if (Input.GetKeyDown(KeyCode.Space))
            {

                _controller.SetTrigger("AttackTrig");
            }
        }
    }
}