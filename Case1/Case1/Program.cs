// See https://aka.ms/new-console-template for more information

using Case1.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = CreateHost();
CodeService codeService = ActivatorUtilities.CreateInstance<CodeService>(host.Services);

string option = "";

while (true)
{
    Console.WriteLine("#1 -> Generate Code");
    Console.WriteLine("#2 -> Check Code\n");

    option = Console.ReadLine();
    Console.WriteLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("Generated Code : " + codeService.GenerateCode() + "\n");
            break;
        case "2":
            GetCodeFromUserAndCheck();
            break;
        default:
            break;
    }
}

void GetCodeFromUserAndCheck()
{
    Console.WriteLine("Please enter your code" + "\n");

    string code = "";

    while (string.IsNullOrWhiteSpace(code))
    {
        code = Console.ReadLine();
    }

    Console.WriteLine();
    bool isValidCode = codeService.CheckCode(code);
    Console.WriteLine(code + " is " + (isValidCode ? "valid\n" : "invalid\n"));
}

static IHost CreateHost() =>
  Host
  .CreateDefaultBuilder()
  .ConfigureServices((context, services) =>
  {
      services.AddSingleton<ICodeService, CodeService>();
  }).Build();