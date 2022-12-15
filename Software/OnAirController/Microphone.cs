using NAudio.CoreAudioApi;

namespace OnAirController
{
    internal class Microphone
    {
        private readonly static MMDeviceEnumerator mmde;

        static Microphone()
        {
            mmde = new MMDeviceEnumerator();
        }

        public static bool GetStateRecording()
        {
            var audioEndpoints = mmde.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            return audioEndpoints.Any(device => device.AudioMeterInformation.MasterPeakValue > 0.0f);
        }
    }
}
