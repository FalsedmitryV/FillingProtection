using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace FSM.Scripts
{
    public class FsmWalk : FsmState
    {
        protected readonly Transform transformPlayer;
        protected readonly NavMeshAgent ZombieAgent;
        protected readonly float Speed;
        public FsmWalk(Fsm fsm, Transform target, float speed, NavMeshAgent agent) : base(fsm) 
        {   
            Speed = speed;
            ZombieAgent = agent;
            transformPlayer = target;
        }

        public override void Enter()
        {
          
        }
        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {
            if (transformPlayer == null)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            Move();
        }

        private void Move()
        {
            ZombieAgent.speed = Speed;
            ZombieAgent.SetDestination(transformPlayer.position);
        }
    }
}
