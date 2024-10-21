
using UnityEngine;
using UnityEngine.AI;

namespace FSM.Scripts
{
    public class FsmDeath : FsmState
    {
        protected readonly Transform ZombieTransform;
        protected readonly Transform transformPlayer;
        protected readonly NavMeshAgent Agent;
        private Animator _anim;
        public FsmDeath(Fsm fsm, Transform transform, Animator animator) : base(fsm) {

            ZombieTransform = transform;
            _anim = animator;
        }

        public override void Enter()
        {
            ZombieTransform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            ZombieTransform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    
            _anim.SetBool("IsDead", true);
        }
        public override void Exit()
        {
            Debug.Log("Death state [EXIT]");
        }
    }
}
