using System.ServiceModel;
using CServer.Chat;

namespace CServer.Contracts
{
    [ServiceContract]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(ChatMessage msg);
    }

    [ServiceContract(CallbackContract = typeof(IChat))]
    public interface IChatManager
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string name);
        [OperationContract(IsOneWay = true)]
        void SubmitMessage(ChatMessage msg);
    }
}