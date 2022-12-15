#include <PluggableUSB.h>
#include <HID.h>
#include <avr/boot.h>

#include "HidLed.h"

static const uint8_t PROGMEM hidReport[] = {
    0x05, 0x01, // Usage Page (Generic Desktop)
    0x09, 0x00, // Usage (Undefined)
    0xa1, 0x01, // Collection (Application)
    0x15, 0x00, // Logical Minimum (0)
    0x25, 0xff, // Logical Maximum (255)
    0x75, 0x08, // Report Size (8)
    0x95, 0x01, // Report Count (1)
    0x05, 0x08, // Usage Page (LED)
    0x09, 0x4b, // Usage (Generic Indicator)
    0x91, 0x02, // Output (Data,Var,Abs)
    0xc0        // End Collection
};

// エンドポイントとインターフェースの数を指定する
// ここでは両方1
HidLed::HidLed() : PluggableUSBModule(1, 1, epType) {
  epType[0] = EP_TYPE_INTERRUPT_IN;
  PluggableUSB().plug(this);
  led_brightness = 0xff;
}

int HidLed::getInterface(uint8_t* interfaceCount) {
  *interfaceCount += 1; // uses 1
  led_brightness = 0x00;
  HIDDescriptor hidInterface = {
    D_INTERFACE(pluggedInterface, 1, USB_DEVICE_CLASS_HUMAN_INTERFACE, HID_SUBCLASS_NONE, HID_PROTOCOL_NONE),
    D_HIDREPORT(sizeof(hidReport)),
    D_ENDPOINT(USB_ENDPOINT_IN(pluggedEndpoint), USB_ENDPOINT_TYPE_INTERRUPT, USB_EP_SIZE, 16)
  };

  return USB_SendControl(0, &hidInterface, sizeof(hidInterface));
}

static char toHex(uint8_t n) {
  return n <= 9 ? '0' + n : 'A' + (n - 10);
}

uint8_t HidLed::getShortName(char *iSerialNum) {
  iSerialNum[0] = 'O';
	iSerialNum[1] = 'n';
	iSerialNum[2] = 'A';
	iSerialNum[3] = 'i';
	iSerialNum[4] = 'r';
  iSerialNum[5] = '-';

  // シリアルナンバーを取得する
  for(int i = 0; i < 10; i++) {
    uint8_t b = boot_signature_byte_get(i + 0xE);
    iSerialNum[6 + i * 2] = toHex(b >> 4);
    iSerialNum[6 + i * 2 + 1] = toHex(b & 0xF);
  }

  return 6 + 10 * 2;
}

int HidLed::getDescriptor(USBSetup& setup) {
  if (
    // Check if this is a HID Class Descriptor request
    setup.bmRequestType != REQUEST_DEVICETOHOST_STANDARD_INTERFACE ||
    setup.wValueH != HID_REPORT_DESCRIPTOR_TYPE ||
    // In a HID Class Descriptor wIndex contains the interface number
    setup.wIndex != pluggedInterface
  ) {
    return 0;
  }

  return USB_SendControl(TRANSFER_PGM, hidReport, sizeof(hidReport));
}

bool HidLed::setup(USBSetup& setup) {
  if (pluggedInterface != setup.wIndex) {
    led_brightness = 0xff;
    return false;
  }

  if (setup.bmRequestType == REQUEST_DEVICETOHOST_CLASS_INTERFACE) {
    led_brightness = 0x00;
    return true;
  }

  if (
    setup.bmRequestType == REQUEST_HOSTTODEVICE_CLASS_INTERFACE &&
    setup.bRequest == HID_SET_REPORT &&
    setup.wValueH == HID_REPORT_TYPE_OUTPUT && setup.wLength == 1
  ) {
    USB_RecvControl(&led_brightness, 1);
    return true;
  }

  return false;
}
