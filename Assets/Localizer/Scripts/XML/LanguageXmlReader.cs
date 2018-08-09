using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace IndigoBunting.Lang
{
    public class LanguageXmlReader
    {
        public static bool IssetLangFile(string rootPath, Language lang)
        {
            string path = rootPath + lang.ToString() + "/" + lang.ToString();
            TextAsset xmlAsset = Resources.Load(path) as TextAsset;
            return xmlAsset;
        }
        
        public static Dictionary<string, string> Read(string rootPath, Language lang)
        {
            string path = rootPath + lang.ToString() + "/" + lang.ToString();
            TextAsset xmlAsset = Resources.Load(path) as TextAsset;

            if (!xmlAsset)
            {
                Debug.LogError("File not found at path " + path);
                return null;
            }

            var reader = XmlReader.Create(new StringReader(xmlAsset.text));

            Dictionary<string, string> data = new Dictionary<string, string>();

            var key = string.Empty;
            var value = string.Empty;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        key = reader["key"];
                        break;
                    case XmlNodeType.Text:
                        value = reader.Value;
                        break;
                    case XmlNodeType.EndElement:
                        if (!string.IsNullOrEmpty(key))
                        {
                            if (data.ContainsKey(key))
                            {
                                throw new Exception("Key " + key + " already exists in string dictionary!");
                            }

                            data.Add(key, value);
                            key = string.Empty;
                            value = string.Empty;
                        }
                        break;
                }
            }

            reader.Close();

            return data;
        }
    }
}
