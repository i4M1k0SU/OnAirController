using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System.Diagnostics;

namespace OnAirController
{
    internal class Microphone
    {
        private static readonly string[] BlackListProcesses = { "Krisp", "nvcontainer", "svchost" };
        private readonly static MMDeviceEnumerator mmde;

        static Microphone()
        {
            mmde = new MMDeviceEnumerator();
        }

        public static bool GetStateRecording()
        {
            var audioEndpoints = mmde.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
#if DEBUG
            Console.Clear();
            foreach (var device in audioEndpoints)
            {
                Console.WriteLine("--Device--");
                Console.WriteLine(device.FriendlyName);

                var sessions = device.AudioSessionManager.Sessions;
                for (int i = 0; i < sessions.Count; i++)
                {
                    using (var session = sessions[i])
                    {
                        var processId = session.GetProcessID;
                        var processName = GetProcessName(processId);
                        if (!string.IsNullOrEmpty(processName) && !BlackListProcesses.Contains(processName))
                        {
                            Console.WriteLine($"Application using microphone: {processName}, State: {session.State == AudioSessionState.AudioSessionStateActive} , Value: {session.AudioMeterInformation.MasterPeakValue}");
                        }
                    }
                }
                Console.WriteLine("--End--\n");
            }
#endif
            return audioEndpoints.Any(device =>
            {
                var sessions = device.AudioSessionManager.Sessions;
                for (int i = 0; i < sessions.Count; i++)
                {
                    using (var session = sessions[i])
                    {
                        var processId = session.GetProcessID;
                        var processName = GetProcessName(processId);
                        if (!string.IsNullOrEmpty(processName) && !BlackListProcesses.Contains(processName))
                        {
                            if (session.State == AudioSessionState.AudioSessionStateActive)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            });
        }

        private static string? GetProcessName(uint processId)
        {
            try
            {
                using (var process = Process.GetProcessById((int)processId))
                {
                    return process.ProcessName;
                }
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
    }
}
