#include "HidLed.h"

#define SHOW_LOG false

#define LED_PIN 5
#define SW1_PIN 19
#define SW2_PIN 18
#define SW3_PIN 10

// state
bool currentPressedButton[3] = {false, false, false};
bool isUsbMode = true;
uint8_t manualBrightness = 255;

HidLed hidLed;

void setup() {
#if SHOW_LOG
  Serial.begin(115200);
#endif
  pinMode(SW1_PIN, INPUT_PULLUP);
  pinMode(SW2_PIN, INPUT_PULLUP);
  pinMode(SW3_PIN, INPUT_PULLUP);
  
  delay(500);
}

void pressSw1() {
  isUsbMode = !isUsbMode;
  // 3回点滅
  for(int i = 0; i < 3; i++) {
    analogWrite(LED_PIN, 255);
    delay(200);
    analogWrite(LED_PIN, 0);
    delay(200);
  }

  if (!isUsbMode) {
    analogWrite(LED_PIN, 255);
    return;
  }
}

void pressSw2() {
  if (isUsbMode) {
    return;
  }

  manualBrightness += 51;
  analogWrite(LED_PIN, manualBrightness);
}

void pressSw3() {
  //
}

void loop() {
  // 2000 = 500Hz
  delayMicroseconds(2000);

  if (isUsbMode) {
    analogWrite(LED_PIN, hidLed.led_brightness);
#if SHOW_LOG
    // Serial.println(hidLed.led_brightness, DEC);
#endif
  }

  bool isPressedButton[3] = {digitalRead(SW1_PIN) == LOW, digitalRead(SW2_PIN) == LOW, digitalRead(SW3_PIN) == LOW};
  for(int i = 0; i < sizeof(isPressedButton) / sizeof(bool); i++) {
    if (isPressedButton[i] == currentPressedButton[i]) {
      continue;
    }

    if (isPressedButton[i]) {
      switch (i) {
        case 0: // SW1
          pressSw1();
          break;
        case 1: // SW2
          pressSw2();
          break;
        case 2: // SW3
          pressSw3();
          break;
      }
#if SHOW_LOG
      Serial.print("PUSH SW");
      Serial.println(i + 1, DEC);
      Serial.flush();
#endif
    }
    currentPressedButton[i] = isPressedButton[i];      
  }
}
