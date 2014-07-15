#include <OneWire.h>
#include <DallasTemperature.h>
#include <SoftwareSerial.h>

int led = 4;

#define ONE_WIRE_BUS 0
#define RX 1
#define TX 2

SoftwareSerial ms(RX,TX);
float TempArray[] = {0};
OneWire oneWire(ONE_WIRE_BUS);
 
// Pass our oneWire reference to Dallas Temperature.
DallasTemperature sensors(&oneWire);
 
void setup(void) {
  pinMode(led, OUTPUT);   
  sensors.begin();  
  ms.begin(9600);
}
 
 
void loop(void) {
  digitalWrite(led, !digitalRead(led));  
  sensors.requestTemperatures();
  TempArray[0] = sensors.getTempCByIndex(0);
  ms.println(TempArray[0]);
  delay(1000);  
}
