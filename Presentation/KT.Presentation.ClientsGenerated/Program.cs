using NSwag;
using NSwag.CodeGeneration.CSharp;

/*
    Generate client code from the swagger.json file.
    The generated code will be written to a file named ClientsGenerated.cs in the current directory.
    NOTE: The API project must be running for this to work.
*/
var httpClient = new HttpClient();
var document =
    await OpenApiDocument.FromJsonAsync(
        await httpClient.GetStringAsync("http://localhost:5130/swagger/v1/swagger.json"));
var settings = new CSharpClientGeneratorSettings
{
    ClassName = "{controller}Client",
    GenerateClientInterfaces = true,
    GenerateExceptionClasses = true,
    GenerateOptionalParameters = true,
    GenerateClientClasses = true,
    CSharpGeneratorSettings =
    {
        Namespace = "KT.Presentation.ClientsGenerated"
    },
    InjectHttpClient = true
};

var generator = new CSharpClientGenerator(document, settings);
var code = generator.GenerateFile();

File.WriteAllText("ClientsGenerated.cs", code);