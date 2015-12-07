using System;
using System.ServiceModel;

namespace FileService
{
    [ServiceContract]
    public interface IFileTransferService
    {
        [OperationContract]
        void SendFile(UkazFileInfo ukazFileInfo);

        [OperationContract]
        bool IsFileProcessed(string fileName);

        [OperationContract]
        UkazFileInfo DownloadFile(UkazFileInfo request);

        [OperationContract]
        bool IsValidPassword(string password);
    }

    [MessageContract]
    public class UkazFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageHeader(MustUnderstand = true)]
        public string FileMovePath;

        [MessageHeader(MustUnderstand = true)]
        public string Password; 

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
