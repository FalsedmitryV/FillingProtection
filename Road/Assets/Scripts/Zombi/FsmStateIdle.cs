
using UnityEngine;
using UnityEngine.AI;

namespace FSM.Scripts
{
    public class FsmStateIdle : FsmState
    {
        protected readonly Transform ZombieTransform;
        protected readonly NavMeshAgent ZombieAgent;
        public FsmStateIdle(Fsm fsm, Transform transform, NavMeshAgent agent) : base(fsm) 
        {
            ZombieTransform = transform;
            ZombieAgent = agent;
        }

        public override void Enter()
        {

        }
        public override void Exit()
        {

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
