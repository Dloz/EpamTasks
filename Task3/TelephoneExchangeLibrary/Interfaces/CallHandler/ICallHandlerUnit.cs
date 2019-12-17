using TelephoneExchangeLibrary.EventsArgs;

namespace TelephoneExchangeLibrary.Interfaces.CallHandler
{
    public interface ICallHandlerUnit
    {
        void HandleCall(CallEventArgs callEventArgs);
        void HandleRespond(RespondEventArgs respondEventArgs);
        void HandleReject(RejectEventArgs rejectEventArgs);
    }
}