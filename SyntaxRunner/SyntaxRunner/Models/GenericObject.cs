using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxRunner.Models
{
    public class GenericObject
    {

        private readonly byte[] StringContentAsBytes;
        private readonly StringBuilder stringBuilderInternal;
        public readonly StringBuilder StringBuilderReadOnly;

        public GenericObject()
        {
            this.StringBuilderReadOnly = new StringBuilder("Initial Value");
            this.stringBuilderInternal = new StringBuilder(this.StringBuilderReadOnly.ToString());
            this.StringContentAsBytes = Encoding.ASCII.GetBytes(this.stringBuilderInternal.ToString());
        }

        public void Add(string value)
        {
            this.StringBuilderReadOnly.Append(value);
        }

        //public void Renew()
        //{
        //    // reassignment is illegal for readonly objects
        //    this.StringBuilderReadOnly = new StringBuilder();
        //}

        public string GetContents()
        {
            return this.stringBuilderInternal.ToString();
        }

        public byte[] GetContentAsBytes()
        {
            return this.StringContentAsBytes;
        }

        public string GetContentsImmutable()
        {
            return this.stringBuilderInternal.ToString();
        }

        public string GetContentsMutable()
        {
            return Encoding.ASCII.GetString(this.StringContentAsBytes);
        }

        public byte[] GetCopyOfBytes()
        {
            byte[] results = new byte[this.StringContentAsBytes.Length];

            for (int i = 0; i < this.StringContentAsBytes.Length; i++)
            {
                results[i] = this.StringContentAsBytes[i];
            }

            return results;
        }

        public byte[] GetCopyOfBytesImmutable()
        {
            byte[] source = Encoding.ASCII.GetBytes(this.GetContentsImmutable());
            byte[] results = new byte[source.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = source[i];
            }

            return results;
        }
    }
}
