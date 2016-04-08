/*
 * This code was generated by the CGbR generator on 08.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CGbR.GeneratorTests
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class Partial
    {
        #region BinarySerializer

        private static Encoding _encoder = new UTF8Encoding();

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 4;
                // Add size for collections and strings
                size += Name.Length;
  
                return size;              
            }
        }

        /// <summary>
        /// Convert object to bytes
        /// </summary>
        public byte[] ToBytes()
        {
            var index = 0;
            var bytes = new byte[Size];

            return ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("");

            // Convert Id
            Include(Id, bytes, index);;
            index += 2;
            // Convert Name
            // Two bytes length information for each dimension
            Include((ushort)(Name == null ? 0 : Name.Length), bytes, index);
            index += 2;
            if (Name != null)  Buffer.BlockCopy(_encoder.GetBytes(Name), 0, bytes, index, Name.Length);;
            index += Name.Length;
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public Partial FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Partial FromBytes(byte[] bytes, ref int index)
        {
            return this;
        }

        /// <summary>
        /// Writer property of type Int16 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Int16 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Int16*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type UInt16 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(UInt16 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((UInt16*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Int32 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Int32 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Int32*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type UInt32 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(UInt32 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((UInt32*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Single to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Single value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Single*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Double to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Double value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Double*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type Int64 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(Int64 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((Int64*)(b + index)) = value;
        }
        /// <summary>
        /// Writer property of type UInt64 to bytes by using pointer opertations
        /// </summary>
        private static unsafe void Include(UInt64 value, byte[] bytes, int index)
        {
            fixed(byte* b = bytes)
                *((UInt64*)(b + index)) = value;
        }

        
        #endregion

        #region JsonSerializer

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public string ToJson()
        {
            var builder = new StringBuilder();
            using(var writer = new StringWriter(builder))
            {
                IncludeJson(writer);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(TextWriter writer)
        {
            writer.Write('{');

            writer.Write("\"Id\":");
            writer.Write(Id.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Name\":");
            writer.Write(string.Format("\"{0}\"", Name));
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public Partial FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public Partial FromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                // Break on EndObject
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                // Only look for properties
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                switch ((string) reader.Value)
                {
                    case "Id":
                        reader.Read();
                        Id = Convert.ToInt16(reader.Value);
                        break;

                    case "Name":
                        reader.Read();
                        Name = Convert.ToString(reader.Value);
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}