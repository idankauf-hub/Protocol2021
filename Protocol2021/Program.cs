using System;

namespace Protocol2021
{
    class Program
    {
        private const int V = 2;

        //private const byte SOM = 0xAA;
        //private const byte EOM = 0xAB;
        //private const byte length = 0x07;
        //private const byte checksum = 0x33;



        //public bool isValid(Packet packet)
        //{

        //    //checking for:
        //    //Length of the message
        //    //SOM and EOM  
        //    //checksum valid

        //    if (packet.Length - 2 != length || //Length of the message exclude <SOM> and <Len> 
        //        buf[0] != SOM || buf[buf.Length - 1] != EOM ||//SOM and EOM  
        //         buf[1] + buf[2] + buf[3] + buf[4] + buf[5] != checksum)
        //    { //checksum valid

        //        return false;
        //    };

        //    return true;

        //}

        //public string parseMsg(byte[] buf)
        //{
        //    if (isValid(buf))
        //    {
        //        byte[] payload = new byte[3];
        //        int j = 3;

        //        //extract the data from the protocol
        //        for (int i = 0; i < 3; i++)
        //        {
        //            if (j < 6)
        //            {
        //                payload[i] = buf[j];
        //                ++j;
        //            }
        //        }
        //        return appSendMsg(payload);
        //    }
        //    return "Isnt Valid packet";
        //}

        //public string appSendMsg(byte[] payload)
        //{
        //    string outPut = "";
        //    for (int i = 0; i < payload.Length; i++)
        //    {
        //        Console.WriteLine(payload[i]);
        //    }
        //    switch (payload[0])
        //    {
        //        case 1:// wind speed -up to 255 km/h
        //            outPut = "Wind speed: " + payload[2];
        //            break;
        //        case 2: //wind direction between 0-360 degrees
        //            outPut = "Wind direction: " + payload[2];
        //            break;
        //        case 3: //Height in meters
        //            outPut = "Height: " + payload[2];
        //            break;
        //        default:
        //            outPut = "Error: Type is Wrong";
        //            break;
        //    }
        //    return outPut;
        //}
        static void Main(string[] args)
        {
           
           // byte[] buf = new byte[] { 0xAA, 0x07, 0x01, 0x02, 0x02, 0x27, 0x00, 0x33, 0xAB };
            Packet p = new Packet(0xAA, 0x06, 0x01, new byte[] { 0x01, 0x01, 0xA0 }, 0xA9, 0xAB);
           // byte[] p = new byte[] { 0xAA, 0x06 };
            //string res =p.parseMsg(buf);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(p.Payload[i]);

            }
        }
    }
}
