﻿namespace CGbR
{
    /// <summary>
    /// Class representing a property
    /// </summary>
    public class PropertyModel : CodeElementModel
    {
        /// <summary>
        /// Initialize property model with its name
        /// </summary>
        /// <param name="name">Name of the property</param>
        public PropertyModel(string name) : base(name)
        {
        }

        /// <summary>
        /// Access modifier of this type
        /// </summary>
        public AccessModifier AccessModifier { get; set; }

        /// <summary>
        /// Flag if this property is a collection
        /// </summary>
        public bool IsCollection { get; set; }

        /// <summary>
        /// Type of collection that was used
        /// </summary>
        public string CollectionType { get; set; }

        /// <summary>
        /// Number of dimensions the collection has
        /// </summary>
        public int Dimensions { get; set; }

        /// <summary>
        /// Type of the property
        /// </summary>
        public string ElementType { get; set; }

        /// <summary>
        /// Simple enum representation
        /// </summary>
        public ModelValueType ValueType { get; set; }

        /// <summary>
        /// Value of the property if set
        /// </summary>
        public string Value { get; set; }
    }
}