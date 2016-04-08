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

namespace CGbR.Benchmarks
{
    /// <summary>
    /// Auto generated class by CGbR project
    /// </summary>
    public partial class Root
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
                var size = 20;
                // Add size for collections and strings
                size += Description.Length;
                size += PartialsList.Sum(entry => entry.Size);
                size += PartialsArray.Sum(entry => entry.Size);
  
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

            // Convert Number
            Include(Number, bytes, index);;
            index += 4;
            // Convert Price
            Include(Price, bytes, index);;
            index += 8;
            // Convert Description
            // Two bytes length information for each dimension
            Include((ushort)(Description == null ? 0 : Description.Length), bytes, index);
            index += 2;
            if (Description != null)  Buffer.BlockCopy(_encoder.GetBytes(Description), 0, bytes, index, Description.Length);;
            index += Description.Length;
            // Convert PartialsList
            // Two bytes length information for each dimension
            Include((ushort)(PartialsList == null ? 0 : PartialsList.Count), bytes, index);
            index += 2;
            // Skip null collections
            if (PartialsList != null)
            for(var i = 0; index < PartialsList.Count; index++)
            {
                var value = PartialsList[i];
            	value.ToBytes(bytes, ref index);
            }
            // Convert PartialsArray
            // Two bytes length information for each dimension
            Include((ushort)(PartialsArray == null ? 0 : PartialsArray.Length), bytes, index);
            index += 2;
            // Skip null collections
            if (PartialsArray != null)
            foreach(var value in PartialsArray)
            {
            	value.ToBytes(bytes, ref index);
            }
            // Convert SmallNumber
            Include(SmallNumber, bytes, index);;
            index += 2;
            return bytes;
        }

        /// <summary>
        /// Create object from byte array
        /// </summary>
        public Root FromBytes(byte[] bytes)
        {
            var index = 0;            
            return FromBytes(bytes, ref index); 
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Root FromBytes(byte[] bytes, ref int index)
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

            writer.Write("\"Number\":");
            writer.Write(Number.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Price\":");
            writer.Write(Price.ToString(CultureInfo.InvariantCulture));
    
            writer.Write(",\"Description\":");
            writer.Write(string.Format("\"{0}\"", Description));
    
            writer.Write(",\"PartialsList\":");
            if (PartialsList == null)
                writer.Write("null");
            else
            {
                writer.Write('[');
                foreach (var value in PartialsList)
                {
            		value.IncludeJson(writer);
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"PartialsArray\":");
            if (PartialsArray == null)
                writer.Write("null");
            else
            {
                writer.Write('[');
                foreach (var value in PartialsArray)
                {
            		value.IncludeJson(writer);
                    writer.Write(',');
                }
                writer.Write(']');
            }
    
            writer.Write(",\"SmallNumber\":");
            writer.Write(SmallNumber.ToString(CultureInfo.InvariantCulture));
    
            writer.Write('}');
        }

        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public Root FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public Root FromJson(JsonReader reader)
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
                    case "Number":
                        reader.Read();
                        Number = Convert.ToInt32(reader.Value);
                        break;

                    case "Price":
                        reader.Read();
                        Price = Convert.ToDouble(reader.Value);
                        break;

                    case "Description":
                        reader.Read();
                        Description = Convert.ToString(reader.Value);
                        break;

                    case "SmallNumber":
                        reader.Read();
                        SmallNumber = Convert.ToUInt16(reader.Value);
                        break;

                    case "PartialsList":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialslist = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialslist.Add(new Partial().FromJson(reader));
                        PartialsList = partialslist;
                        break;

                    case "PartialsArray":
                        reader.Read(); // Read token where array should begin
                        if (reader.TokenType == JsonToken.Null)
                            break;
                        var partialsarray = new List<Partial>();
                        while (reader.Read() && reader.TokenType == JsonToken.StartObject)
                            partialsarray.Add(new Partial().FromJson(reader));
                        PartialsArray = partialsarray.ToArray();
                        break;

                }
            }

            return this;
        }

        
        #endregion

    }
}