namespace TDSGamer.FiniteStateMachine
{
    public interface IAction
    {
        bool CanCancel();
        void Cancel();
    }   
}