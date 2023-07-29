namespace Case1.Services
{
    public class CodeService : ICodeService
    {
        private const string CodePattern = "ACDEFGHKLMNPRTXYZ234579";

        private const int CodeLength = 8;

        public string GenerateCode()
        {
            var random = new Random();
            return new string(Enumerable.Repeat(CodePattern, CodeLength).Select(x => x[random.Next(x.Length)]).ToArray());
        }

        public bool CheckCode(string code)
        {
            // Check null, empty, whitespace
            if (string.IsNullOrWhiteSpace(code))
                return false;

            // Check code length
            if (code.Length != CodeLength)
                return false;

            // Check code pattern
            foreach (var charStr in code)
            {
                if (!CodePattern.Contains(charStr))
                    return false;
            }

            return true;
        }

        
    }
}
