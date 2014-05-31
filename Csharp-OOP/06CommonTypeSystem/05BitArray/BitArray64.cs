using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BitArray
{
    public class BitArray64 : IEnumerable<int>
    {
        private readonly int[] bits64 = new int[64];
        public ulong number64 { get; set; }
        public BitArray64(ulong number = 0)
        {
            this.bits64 = GetBits(number);
            this.number64 = number;
        }

        private static int[] GetBits(ulong number)
        {
            int[] bits = new int[64];
            int counter = 63;

            while (number > 0)
            {
                bits[counter] = (int)number % 2;
                number = number / 2;
                counter--;
            }
            do
            {
                bits[counter] = 0;
                counter--;
            }
            while (counter >= 0);

            return bits;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < bits64.Length; i++)
            {
                yield return bits64[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            BitArray64 comparedNum = obj as BitArray64;
            bool result = true;
            for (int i = 0; i < 64; i++)
            {
                if (this.bits64[i] != comparedNum.bits64[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public override int GetHashCode()
        {
            return this.bits64.GetHashCode();
        }

        public int this[int index]
        {
            get
            {
                return this.bits64[index];
            }
        }

        public static bool operator ==(BitArray64 fNum, BitArray64 sNum)
        {
            return fNum.Equals(sNum);
        }

        public static bool operator !=(BitArray64 fNum, BitArray64 sNum)
        {
            return !fNum.Equals(sNum);
        }
    }
}
