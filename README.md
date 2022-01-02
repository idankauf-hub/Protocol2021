# Protocol2021
Building my own protocol

   < SOM >< Len >< Seq >< Payload >< cs / CRC16 >< EOM >
          Examples for messages:
          0xAA, 0x06, 0x01, 0x01, 10x01, 0xA0, 0xA9, 0xAB      -->       “Wind speed    : 160 Km / h”
          0xAA, 0x07, 0x01, 0x02, 0x02, 0x27, 0x00, 0x33, 0xAB  -->   “Wind Direction: 39 degrees”
          0xAA, 0x06, 0x01, 0x03, 0x01, 0x0C, 0x17, 0xAB         -->    “Height             :  12 meters”
  Attributes:
            1 - Wind speed - (range: 0 - 255 km / h)
            2 - Wind Direction(range: 0 - 360) 2 bytes
            3 - Height(range: 10 - 15 meters)
