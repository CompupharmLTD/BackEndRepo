using CompupharmLtd.Model;

namespace CompupharmLtd.Interface
{
    public interface IEmailSending
    {
        int Send(string fromad, string toad, string body, string header, string subjectcontent);

    }
}