namespace Case1.Services
{
    public interface ICodeService
    {
        string GenerateCode();

        bool CheckCode(string code);
    }
}
