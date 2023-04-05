using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnAirController.Properties;

namespace OnAirController
{
    public partial class Form1 : Form
    {
        private bool currentRedordingState = false;

        public Form1()
        {
            InitializeComponent();

            HID.VendorId = Settings.Default.vendor_id;
            HID.ProductId = Settings.Default.product_id;
            HID.SerialNumber = Settings.Default.serial_number;

            vendorIdBox.Text = HID.VendorIdHex;
            productIdBox.Text = HID.ProductIdHex;
            serialNumberBox.Text = HID.SerialNumber;

            HID.Init();
            Task.Run(() => RecordingCheck());
        }

        private void On()
        {
            Task.Run(() =>
            {
                if (HID.Stream == null)
                {
                    return;
                }
                for (short i = 0x0; i <= 0xff; i++)
                {
                    HID.Stream.Write(new byte[] { 0x00, (byte)i });
                }
                HID.Stream.Close();
            });
        }

        private void Off()
        {
            Task.Run(() =>
            {
                if (HID.Stream == null)
                {
                    return;
                }
                for (short i = 0xff; i >= 0x0; i--)
                {
                    HID.Stream.Write(new byte[] { 0x00, (byte)i });
                }
                HID.Stream.Close();
            });
        }

        private void onBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ON");
            On();
        }

        private void offBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Off");
            Off();
        }

        private void brightness_Scroll(object sender, EventArgs e)
        {
            if (HID.Stream == null)
            {
                return;
            }
            HID.Stream.Write(new byte[] { 0x00, (byte)brightness.Value });
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.vendor_id = Convert.ToUInt16(vendorIdBox.Text, 16);
            Settings.Default.product_id = Convert.ToUInt16(productIdBox.Text, 16);
            Settings.Default.serial_number = serialNumberBox.Text;
            Settings.Default.Save();
            HID.VendorId = Settings.Default.vendor_id;
            HID.ProductId = Settings.Default.product_id;
            HID.SerialNumber = Settings.Default.serial_number;
        }

        private void linkRecordingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (linkRecordingCheckBox.Checked)
            {
                Task.Run(() => RecordingCheck());
            }
        }
        private void RecordingCheck()
        {
            while (true)
            {
                if (!linkRecordingCheckBox.Checked)
                {
                    return;
                }
                var recording = Microphone.GetStateRecording();
                if (currentRedordingState != recording)
                {
                    currentRedordingState = recording;
                    if (recording)
                    {
                        On();
                    }
                    else
                    {
                        Off();
                    }
                }

                Thread.Sleep(500);
            }
        }
    }
}