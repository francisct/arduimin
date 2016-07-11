/*
 modified 29 Juin 2015
 par Francis Chillis Pion
*/

float distance;

void setup() 
{
 Serial.begin(9600);  //Protocole de communication. Le 9600 fait 
 		      //référence à la vitesse du port de 
 		      //communication. Sert à voir les valeurs des 
		      //variables
}




void loop() {                // Fonction appelé en boucle similaire à un 
 				     // while(true)

Distance();                  


}

void Distance(void){
delay(60);
int sensorValue = analogRead(A0);    //Lit la valeur analogique (0-5V) et la transforme en valeur discrétisé (0-1023)
float voltage = sensorValue * (5.0 / 1023.0);  //Ajuste la discrétisation à l'échelle du voltage utilisé
distance = pow(voltage, -1.133)*26.142;  //Utilise les spécifications techniques pour converte le 
                                               //voltage en distance

if (distance >= 30)
    {
      distance = 1;
    }
if (distance <=10)
    {
      distance =0;
    }

Serial.print(distance/30);

     
}
