using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.UnitOfWork
{
    public interface ICallHandlerUnit
    {
        void HandleCall(CallEventArgs callEventArgs);
        void HandleRespond(RespondEventArgs respondEventArgs);
        void HandleReject(RejectEventArgs rejectEventArgs);
    }
}