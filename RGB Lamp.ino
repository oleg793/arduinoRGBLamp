#include <EEPROM.h>
int cmd, pwm = 255;
bool fls;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600, "SERIAL_8N1");
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()) {
    cmd = Serial.parseInt();
    if(cmd == 1000) {
      Serial.println("ok!");
    }
    if(cmd == 30) {
      pwm = 90;
    } else if(cmd == 31) {
      pwm = 255;
    }
    if(cmd == 9) {
      analogWrite(3, 0);
      analogWrite(5, 0);
      analogWrite(6, 0);
    }
    else if(cmd == 1) {
      analogWrite(3, pwm);
    } else if(cmd == 2) {
      analogWrite(5, pwm);
    } else if(cmd == 3) {
      analogWrite(6, pwm);
    } else if(cmd == 4) {
      if(fls == false) {
      fls = true;
      } else {
        fls = false;
        analogWrite(3, 0);
        analogWrite(5, 0);
        analogWrite(6, 0);
      }
    } else if(cmd == 6) {
      analogWrite(3, 0);
    } else if(cmd == 7) {
      analogWrite(5, 0);
    } else if(cmd == 8) {
      analogWrite(6, 0);
    } else if(cmd == 10) {
      analogWrite(3, pwm);
      analogWrite(5, pwm);
      analogWrite(6, pwm);
    } else if(cmd == 11) {
      analogWrite(3, 0);
      analogWrite(5, 0);
      analogWrite(6, 0);
    }
  }
  if(fls == true) {
    flash();
  }
}

void flash() {
  analogWrite(3, pwm);
  delay(2000);
  analogWrite(3, 0);
  analogWrite(5, pwm);
  delay(2000);
  analogWrite(5, 0);
  analogWrite(6, pwm);
  delay(2000);
  analogWrite(3, 0);
  analogWrite(5, 0);
  analogWrite(6, 0);
  analogWrite(3, pwm);
}
