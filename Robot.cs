using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using model;

namespace rsa_uipath;

public class Robot
{
    private static Config config;
    private static Project project;
    private static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    static Robot()
    {
        try
        {
            config = ReadJSON<Config>(Files.Config);
            project = ReadJSON<Project>(Files.Project);
        }
        catch (Exception ex)
        {
            ReportFatalError(ex);
            throw;
        }
    }

    internal static T ReadJSON<T>(FileInfo fileToRead) where T : new()
    {
        try
        {
            if (!fileToRead.Exists) throw new Exception("file not found on " + fileToRead.FullName);

            var read = JsonSerializer.Deserialize<T>(fileToRead.OpenText().ReadToEnd(), jsonSerializerOptions);
            if (read == null) return new T();
            return read;
        }
        catch (Exception ex)
        {
            throw new Exception("deserialization error: " + ex.Message);
        }
    }

    internal static void ReportFatalError(Exception ex)
    {
        // TODO
    }
}
