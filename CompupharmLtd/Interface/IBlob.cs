using System.Net;

namespace CompupharmLtd.Interface
{
    public interface IBlob
    {
         bool Upload(string file);
         bool Delete();
         bool CheckIfExist();

    }
}
