using System;
using System.IO;
using System.Xml;
using UnityEngine;
using System.Collections;

namespace IndigoBunting.Lang
{
    public static class XmlParserUtils
    {
        public static XmlReader CreateReader(string filePath, bool isExternalLocation = false)
        {
            if (isExternalLocation)
            {
                return XmlReader.Create(filePath);
            }
            else
            {
                var textAsset = (TextAsset)Resources.Load(filePath);
                if (textAsset == null) Debug.LogError("Can't load local resource from " + filePath);
                return XmlReader.Create(new StringReader(textAsset.text));
            }
        }

        public static void TryGetFloatValue(XmlReader reader, string attribute, out float value)
        {
            var av = reader[attribute];
            value = av != null ? (float)Double.Parse(av) : -1f;
        }
    }
}

