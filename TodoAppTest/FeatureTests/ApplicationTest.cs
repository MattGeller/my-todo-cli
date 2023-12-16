namespace TodoAppTest;
using System.Diagnostics;
using System.Text;

public class ApplicationTest
{

    [Test]
    public void Show()
    {
        // Arrange
        var command = "show";

        // Act
        string actualOutput = RunConsoleApp(command);

        // Assert
        Assert.AreEqual("Hooray! No Items", actualOutput);
    }

    
    private string RunConsoleApp(string command, string argument = "")
    {
        Process process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"run {command} {argument}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        StringBuilder outputBuilder = new StringBuilder();

        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                outputBuilder.AppendLine(e.Data);
            }
        };

        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();

        return outputBuilder.ToString().Trim();
    }


    // private string RunConsoleApp(string command, string argument = "")
    //     {
    //         Process process = new Process();
    //         process.StartInfo.FileName = "dotnet";
    //         process.StartInfo.Arguments = $"run {command} {argument}";
    //         process.StartInfo.RedirectStandardOutput = true;
    //         process.StartInfo.UseShellExecute = false;
    //         process.StartInfo.CreateNoWindow = true;

    //         process.Start();
    //         string output = process.StandardOutput.ReadToEnd();
    //         process.WaitForExit();

    //         return output;
    //     }
}