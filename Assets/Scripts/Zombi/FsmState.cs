namespace FSM.Scripts
{
    public abstract class FsmState
    {
        protected readonly Fsm Fsm;
        protected bool isActive;

        public FsmState(Fsm fsm)
        {
            Fsm = fsm;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void FixedUpdate() { }
    }
}
