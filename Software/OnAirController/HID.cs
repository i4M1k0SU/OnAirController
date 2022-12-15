using HidSharp;

namespace OnAirController
{
    internal class HID
    {
        public static ushort VendorId = 0x0;
        public static ushort ProductId = 0x0;
        public static string SerialNumber = "";
        private static HidDevice? device;

        public static void Init()
        {
            Task.Run(() => DeviceCheck());
        }

        private static void Connect()
        {
            var devices = DeviceList.Local.GetHidDevices(VendorId, ProductId, serialNumber: SerialNumber);
            if (devices.Count() == 0)
            {
                Console.WriteLine("Device NotFound");
                device = null;
                return;
            }
            Console.WriteLine("Connected!");
            device = devices.First();
        }

        private static void DeviceCheck()
        {
            while (true)
            {
                Connect();
                Thread.Sleep(500);
            }
        }

        public static HidStream? Stream
        {
            get
            {
                if (device != null && device.TryOpen(out var hidStream))
                {
                    //var a = hidStream.CanWrite;
                    return hidStream;
                }
                return null;
            }
        }

        public static string VendorIdHex
        {
            get
            {
                return "0x" + VendorId.ToString("X4");
            }
            set
            {
                VendorId = Convert.ToUInt16(value, 16);
            }
        }

        public static string ProductIdHex
        {
            get
            {
                return "0x" + ProductId.ToString("X4");
            }
            set
            {
                ProductId = Convert.ToUInt16(value, 16);
            }
        }

        public static bool IsConnected
        {
            get
            {
                return device != null;
            }
        }
    }
}
