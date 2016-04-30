/*
 * This code was generated by the CGbR generator on 30.04.2016. Any manual changes will be lost on the next build.
 * 
 * For questions or bug reports please refer to https://github.com/Toxantron/CGbR or contact the distributor of the
 * 3rd party generator target.
 */
using CGbR.Lib;
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
    public partial class Partial : IByteSerializable
    {
        #region BinarySerializer

        /// <summary>
        /// Binary size of the object
        /// </summary>
        public int Size
        {
            get 
            { 
                var size = 4;
                // Add size for collections and strings
                size += Name == null ? 0 : Name.Length;
  
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
        void IByteSerializable.ToBytes(byte[] bytes, ref int index)
        {
            ToBytes(bytes, ref index);
        }

        /// <summary>
        /// Convert object to bytes within object tree
        /// </summary>
        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            if (index + Size > bytes.Length)
                throw new ArgumentOutOfRangeException("index", "Object does not fit in array");

            // Convert Id
            GeneratorByteConverter.Include(Id, bytes, ref index);
            // Convert Name
            GeneratorByteConverter.Include(Name, bytes, ref index);
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
        void IByteSerializable.FromBytes(byte[] bytes, ref int index)
        {
            FromBytes(bytes, ref index);
        }

        /// <summary>
        /// Create object from segment in byte array
        /// </summary>
        public Partial FromBytes(byte[] bytes, ref int index)
        {
            // Read Id
            Id = BitConverter.ToInt16(bytes, index);
            index += 2;
            // Read Name
            Name = GeneratorByteConverter.GetString(bytes, ref index);

            return this;
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