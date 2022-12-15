#pragma once

#include <PluggableUSB.h>

class HidLed : public PluggableUSBModule {

public:
  uint8_t led_brightness;
  HidLed(void);

protected:
  int getInterface(uint8_t* interfaceCount);
  int getDescriptor(USBSetup& setup);
  bool setup(USBSetup& setup);
  uint8_t getShortName(char *iSerialNum);
  uint8_t epType[1];

};

extern HidLed hidLed;
