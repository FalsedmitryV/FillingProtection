
using UnityEngine;
using UnityEngine.AI;

namespace FSM.Scripts
{
    public class FsmStateAttack : FsmState
    {
        protected readonly Transform ZombieTransform;
        protected readonly NavMeshAgent ZombieAgent;
        private Animator _anim;

        public FsmStateAttack(Fsm fsm, Transform transform, NavMeshAgent agent, Animator animator) : base(fsm) 
        {
            ZombieTransform = transform;
            ZombieAgent = agent;
            _anim = animator;
        }

        public override void Enter()
        {
            _anim.SetBool("IsAttack", true);
            Debug.Log("Idle state [ENTER]");
        }
        public override void Exit()
        {
            _anim.SetBool("IsAttack", false);
            Debug.Log("Idle state [EXIT]");
        }

        public override void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            ZombieAgent.SetDestination(ZombieTransform.position);
        }
    }
}
