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
        private byte[] payload;
        private byte checksum;
        private byte eom;

        public Packet()
        {
                
        }
        public Packet(byte som, byte len, byte seq, byte[] payload, byte checksum, byte eom)
        {
            this.som = som;
            this.len = len;
            this.seq = seq;
            this.payload = payload;
            this.checksum = checksum;
            this.eom = eom;
        }

        public byte Som { get => som; set => som = value; }
        public byte Len { get => len; set => len = value; }
        public byte Seq { get => seq; set => seq = value; }
        public byte[] Payload { get => payload; set => payload = value; }
        public byte Checksum { get => checksum; set => checksum = value; }
        public byte Eom { get => eom; set => eom = value; }

        public override bool Equals(object obj)
        {
            return obj is Packet packet &&
                   som == packet.som &&
                   len == packet.len &&
                   seq == packet.seq &&
                   EqualityComparer<byte[]>.Default.Equals(payload, packet.payload) &&
                   checksum == packet.checksum &&
                   eom == packet.eom;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
