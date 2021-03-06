using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol2021
{

    class Packet
    {
        private byte som;
        private byte len;
        private byte seq;
        private byte messageType;
        private byte[] payload;
        private byte checksum;
        private byte eom;
        private const byte SOM = 0xAA;
        private const byte EOM = 0xAB;
        private byte sum;
        public Packet()
        {
                
        }
        public Packet(byte som, byte len, byte seq, byte messageType, byte[] payload, byte checksum, byte eom)
        {
            this.som = som;
            this.len = len;
            this.seq = seq;
            this.messageType = messageType;
            this.payload = payload;
            this.checksum = checksum;
            this.eom = eom;
        }

        public byte Som { get => som; set => som = value; }
        public byte Len { get => len; set => len = value; }
        public byte Seq { get => seq; set => seq = value; }
        public byte MessageType { get => messageType; set => messageType = value; }

        public byte[] Payload { get => payload; set => payload = value; }
        public byte Checksum { get => checksum; set => checksum = value; }
        public byte Eom { get => eom; set => eom = value; }


        public bool isValid(Packet packet)
        {
            //checking for:
            //Length of the message
            //SOM and EOM  
            //checksum valid
            for (int i = 0; i < packet.Payload.Length; i++)
            {
                sum += packet.Payload[i];
            }
            if ( 
                packet.Som != SOM || packet.Eom != EOM ||//SOM and EOM  
                packet.Checksum != sum +packet.MessageType+ packet.Len + packet.Seq)//check checksum

            { //checksum valid

                return false;
            }

            return true;

        }

        public string parseMsgFromBytes(Packet packet)
        {
            if (isValid(packet))
            {
                if (packet.MessageType== 1)
                {
                    return "Ack recieve";
                }
                return appSendMsg(packet);
            }
            return "Isn`t Valid packet";
        }

        public string appSendMsg(Packet packet)
        {
            string outPut = "";
            switch (packet.Payload[0])
            {
                case 1:// wind speed -up to 255 km/h
                    outPut = "Wind speed: " + packet.Payload[2];
                    break;
                case 2: //wind direction between 0-360 degrees
                    if (packet.Payload[1] == 2)
                    {
                        byte[] value = new byte[2];
                        for (int i = 0; i < packet.Payload.Length - 2; i++)
                        {
                            //pay [2,3 ]
                            value[i] = packet.Payload[i + 2];
                        }
                        outPut = "Wind direction: " + BitConverter.ToInt16(value, 0);

                    }
                    outPut = "Wind direction: " + packet.Payload[2];
                    break;
                case 3: //Height in meters
                    outPut = "Height: " + packet.Payload[2];
                    break;
                default:
                    outPut = "Error: Type of payload is Wrong";
                    break;
            }
            return outPut;
        }
    }
}
