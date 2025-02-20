using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using XSNotifyDaemon.Types;

namespace XSNotifyDaemon;

class Program
{
    public class XSEmulator : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            XSOApiObject? apiObject = JsonConvert.DeserializeObject<XSOApiObject>(Encoding.ASCII.GetString(e.RawData));
            if (apiObject.command == "SendNotification")
            {
                XSONotificationObject? notif = JsonConvert.DeserializeObject<XSONotificationObject>(apiObject.jsonData);
                Console.WriteLine($"[{DateTime.Now}] [WS] {notif.title} - {notif.content}");
                // TODO: Is there a way to send notifications easily on Windows?
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    int timeoutMs = (int)(notif.timeout * 1000f);
                    try
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = "notify-send";
                        if (notif.useBase64Icon)
                        {
                            try
                            {
                                var iconBytes = Convert.FromBase64String(notif.icon);
                                File.WriteAllBytes("/tmp/xsnd-icon", iconBytes);
                                proc.StartInfo.Arguments =
                                    $"--icon=/tmp/xsnd-icon -t {timeoutMs} \"{notif.title}\" \"{notif.content}\"";
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error saving icon, giving up and using an icon-less notification... {ex.Message}");
                                proc.StartInfo.Arguments = $"-t {timeoutMs} \"{notif.title}\" \"{notif.content}\"";
                            }
                        }
                        else proc.StartInfo.Arguments = $"-t {timeoutMs} \"{notif.title}\" \"{notif.content}\"";
                        proc.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Exception while running desktop notif: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("Unimplemented command: " + apiObject.command);
            }
        }
    }
    
    static void Main(string[] args)
    {
        var websocketServer = new WebSocketServer("ws://127.0.0.1:42070");
        websocketServer.AddWebSocketService<XSEmulator>("/");
        Console.WriteLine("Opening websocket server at 127.0.0.1:42070");
        websocketServer.Start();
        Console.ReadKey (true);
        Console.WriteLine("Closing websocket server. Goodbye!");
        websocketServer.Stop();
    }
}