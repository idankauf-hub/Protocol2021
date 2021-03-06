using System;

namespace Protocol2021
{
    class Program
    {
        private const byte SOM = 0xAA;
        private const byte EOM = 0xAB;
        static void Main(string[] args)
        {
            //< SOM >< Len >< Seq ><MessageType>< Payload >< cs / CRC16 >< EOM >
            //Examples for messages:
            //0xAA, 0x07, 0x01,0x02, 0x01, 0x01, 0xA0, 0xAB, 0xAB      -->       “Wind speed    : 160 Km / h”
            //0xAA, 0x08, 0x01, 0x02, 0x02, 0x02, 0x27, 0x00, 0x36, 0xAB  -->   “Wind Direction: 39 degrees”
            //0xAA, 0x07, 0x01,0x02, 0x03, 0x01, 0x0C, 0x1A, 0xAB         -->    “Height             :  12 meters”

            //example of ack :
            //0xAA, 0x07, 0x01,0x01, 0x03, 0x01, 0x0C, 0x19, 0xAB 
            //Attributes:
            //1 - Wind speed - (range: 0 - 255 km / h)
            //2 - Wind Direction(range: 0 - 360) 2 bytes
            //3 - Height(range: 10 - 15 meters)


            // reciver
            Packet packet = new Packet(0xAA, 0x07, 0x01, 0x01, new byte[] { 0x03, 0x01, 0x0C }, 0x19, 0xAB);
            string res = packet.parseMsgFromBytes(packet);
            Console.WriteLine(res);
        }
    }
}
