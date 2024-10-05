using StoreApp.LogService.Services.Abstract;

namespace StoreApp.LogService.Services.Concrete;
public class LogService : ILogService
{
    public void LogInfoToTxtFile(string message)
    {
        File.WriteAllText("log.txt", message);
    }
}
