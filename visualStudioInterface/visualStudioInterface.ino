String data;
char d1;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(13,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()){
    data = Serial.readString();
    d1 = data.charAt(0);

    if(d1=='A'){
      digitalWrite(13,HIGH);
    }else if(d1=='a'){
      digitalWrite(13,LOW);
    }else if(d1=='b'){
      blinkLED();
    }else if(d1=='t'){
      Serial.write("H");
    }
  }
  
}
void blinkLED(){
  digitalWrite(13,HIGH);
  delay(1000);
  digitalWrite(13,LOW);
}
