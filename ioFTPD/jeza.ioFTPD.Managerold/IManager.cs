using System.ServiceModel;
using jeza.ioFTPD.Framework;

namespace jeza.ioFTPD.Manager
{
    [ServiceContract(Namespace = "http://jeza.ioFTPD.Manager")]
    public interface IManager
    {
        [OperationContract]
        ManagerResponse ProcessZipScript(string[] args);

        [OperationContract]
        ManagerResponse ProcessArchiveScript(string[] args);
        
        [OperationContract]
        ManagerResponse ProcessManager(string[] args);
    }
}