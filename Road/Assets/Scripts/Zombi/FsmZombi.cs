using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
namespace FSM.Scripts
{

    public class FsmZombi : MonoBehaviour
    {
        private Fsm _fsm;
        private float _walkSpeed = 5.0f;
        private GameObject _targetPlayer;
        private NavMeshAgent _agent;
        private Animator _anim;

        public event Action Died;

        private void Start()
        {
            _fsm = new Fsm();

            _targetPlayer = GameObject.FindWithTag("GasStation");
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _anim = gameObject.GetComponent<Animator>();

            _fsm.AddState(new FsmStateIdle(_fsm, transform, _agent));
            _fsm.AddState(new FsmWalk(_fsm, _targetPlayer.transform, _walkSpeed, _agent));
            _fsm.AddState(new FsmDeath(_fsm, transform, _anim));
            _fsm.AddState(new FsmStateAttack(_fsm, transform, _agent, _anim));

            _fsm.SetState<FsmWalk>();
        }

        private void FixedUpdate()
        {
            _fsm.FixedUpdate();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.gameObject.tag == "Player")
            {
                _fsm.SetState<FsmDeath>();
            }
        }

        public void DieZombie()
        {
            EventDeathEnamy.OnEnemyDied();
            Destroy(gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "GasStation")
            {
                _fsm.SetState<FsmStateAttack>();
            }
        }
        public void TakeDamage()
        {
            GameObject target = GameObject.Find("GasStation");
            target.GetComponent<GasStation>().GetDamage();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "GasStation")
            {
                _fsm.SetState<FsmWalk>();
            }
        }
    }
}
