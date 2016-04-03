﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CGbR
{
    /// <summary>
    /// <see cref="IParser"/> implementation that uses only regex to extract the most basic syntax elements
    /// like properties or attributes
    /// </summary>
    internal class RegexParser : IParser
    {
        // Regex used to parse source file
        private readonly Regex _namespaceRegex = new Regex(@"namespace (?<namespace>(?:\w\.?)*)");
        private readonly Regex _attributeRegex = new Regex(@"\[(?<attributeName>\w+)\(?(?:(?<parameter>\d+),? ?)*(?:(?<property>\w+) ?= ?(?<value>\d+),? ?)*");
        private readonly Regex _classRegex = new Regex(@"(?<accessModifier>[public|internal]) partial class (?<className>\w+)(?: : )?(?<baseType>\w+)?(?:, )?(?:(?<interface>I\w+)(?:, )?)*");
        private readonly Regex _propRegex = new Regex(@" public (?<type>\w+)(?<isCollection>\[(?<dimensions>, ?)*\])? (?<name>\w+)");

        /// <seealso cref="IParser"/>
        public string Name { get; } = "Regex";

        /// <seealso cref="IParser"/>
        public ClassModel ParseFile(string filePath)
        {
            // Read the file
            var file = File.ReadAllLines(filePath);

            ClassModel model = null;
            var @namespace = string.Empty;
            for (var i = 0; i < file.Length; i++)
            {
                var line = file[i];

                // First find the namespace
                var match = _namespaceRegex.Match(line);
                if (match.Success)
                    @namespace = match.Groups["namespace"].Value;

                // First we must find the class definition
                if (model == null)
                {
                    ParseClass(file, i, @namespace, out model);
                    continue;
                }
                    

                // Look for attributes that mark payload fields
                ParseProperty(file, i, model);
            }

            return model;
        }

        /// <summary>
        /// Try parsing the class definition and its attributes
        /// </summary>
        /// <param name="file">Text lines of the file</param>
        /// <param name="index">Index in the file</param>
        /// <param name="namespace">Namespace of the class</param>
        /// <param name="model">Result model</param>
        /// <returns>True if parsing succeeded</returns>
        private void ParseClass(string[] file, int index, string @namespace, out ClassModel model)
        { 
            model = null;

            // Try to match current line as class definition
            var match = _classRegex.Match(file[index]);
            if (!match.Success)
                return;

            // Get base type and interfaces
            var baseGroup = match.Groups["baseType"];
            var baseType = baseGroup.Success ? baseGroup.Value : string.Empty;

            var interfaceGroup = match.Groups["interface"];
            var interfaces = new string[interfaceGroup.Captures.Count];
            for (var i = 0; i < interfaceGroup.Captures.Count; i++)
            {
                interfaces[i] = interfaceGroup.Captures[i].Value;
            }

            // Create class model
            model = new ClassModel(match.Groups["className"].Value)
            {
                Namespace = @namespace,
                BaseClass = baseType,
                Interfaces = interfaces
            };

            // Add attributes by moving up the lines
            ParseAttributes(file, index, model);
        }

        /// <summary>
        /// Try parsing a property from the current line
        /// </summary>
        /// <param name="file">All text lines of the file</param>
        /// <param name="index">Current index in the file</param>
        /// <param name="model">Class model</param>
        private void ParseProperty(string[] file, int index, ClassModel model)
        {
            // Try parsing property
            var match = _propRegex.Match(file[index]);
            if (!match.Success)
                return;

            // Create property model
            var property = new PropertyModel(match.Groups["name"].Value)
            {
                PropertyType = match.Groups["type"].Value,
                IsCollection = match.Groups["isCollection"].Success,
                Dimensions = match.Groups["dimensions"].Captures.Count + 1
            };

            // Add attributes by moving up the lines
            ParseAttributes(file, index, property);

            model.Properties.Add(property);
        }

        /// <summary>
        /// Look for attributes in the previous lines
        /// </summary>
        /// <param name="file">All lines of the fie</param>
        /// <param name="index">Current index in file</param>
        /// <param name="model">Model to add attributes to</param>
        private void ParseAttributes(string[] file, int index, CodeElementModel model)
        {
            // Keep going back in the file to look for attributes
            for (var line = index - 1; line >= 0; line--)
            {
                var match = _attributeRegex.Match(file[line]);
                if (!match.Success)
                    break;

                // Create attribute
                var attribute = new AttributeModel(match.Groups["attributeName"].Value);
                model.Attributes.Add(attribute);

                // Set parameters
                var parameterGroup = match.Groups["parameter"];
                for (int i = 0; i < parameterGroup.Captures.Count; i++)
                {
                    attribute.Parameters.Add(parameterGroup.Captures[i].Value);
                }

                // Set properties
                var propertygroup = match.Groups["property"];
                var valueGroup = match.Groups["value"];
                for (int i = 0; i < parameterGroup.Captures.Count; i++)
                {
                    var property = new PropertyModel(propertygroup.Captures[i].Value)
                    {
                        Value = valueGroup.Captures[i].Value
                    };
                    attribute.Properties.Add(property);
                }
            }
        }
    }
}