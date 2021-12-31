using System;

namespace Protocol2021
{
    class Program
    {

        static void Main(string[] args)
        {
            //send


            //reciver
            Packet packet = new Packet(0xAA, 0x06, 0x01, new byte[] { 0x01, 0x01, 0xA0 }, 0xA9, 0xAB);
            string res = packet.parseMsg(packet,8);
            Console.WriteLine(res);
        }
    }
}
