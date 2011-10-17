using System.ServiceModel;

namespace jeza.ioFTPD.Manager
{
    [ServiceContract(Namespace = "http://jeza.ioFTPD.Manager")]
    public interface IManager
    {
        [OperationContract]
        int ProcessZipScript(string[] args);

        [OperationContract]
        int ProcessArchiveScript(string[] args);
        
        [OperationContract]
        int ProcessManager(string[] args);
    }
}