# Protocol2021
  A program for recieve my own customized communication protocol that validates the packet and returns the data.
  # Examples for messages:
          < SOM >< Len >< Seq >< Payload >< cs / CRC16 >< EOM >
          0xAA, 0x06, 0x01, 0x01, 0x01, 0xA0, 0xA9, 0xAB      -->       “Wind speed    : 160 Km / h”
          0xAA, 0x07, 0x01, 0x02, 0x02, 0x27, 0x00, 0x33, 0xAB  -->   “Wind Direction: 39 degrees”
          0xAA, 0x06, 0x01, 0x03, 0x01, 0x0C, 0x17, 0xAB         -->    “Height             :  12 meters”
  # Payload attributes:
   **first byte:**
   
      1 - Wind speed - (range: 0 - 255 km / h)
      2 - Wind Direction(range: 0 - 360)
      3 - Height(range: 10 - 15 meters)
  **second byte:**
  
    length of the data

  **third and forth(only case thats the wind direction is more than 255):**
  
    The value
