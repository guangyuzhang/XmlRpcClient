using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace XMLRPCClient
{
    public static class XmlHelper
    {
        //XmlRpc requires tags for int's http://www.xmlrpc.com/spec
        public static string getFullXML(XDocument xdoc)
        {
            try
            {
                string xml;
                using (System.IO.MemoryStream memStream = new System.IO.MemoryStream())
                {
                    XmlWriter writer = XmlWriter.Create(memStream);
                    xdoc.Save(writer);
                    writer.Close();
                    memStream.Position = 0;

                    xml = System.Text.Encoding.ASCII.GetString(memStream.GetBuffer(), 0, Convert.ToInt32(memStream.Length)).TrimEnd('\0');
                    xml = xml.Trim();
                    memStream.Close();
                    xml = xml.Replace("&lt;", "<");
                    xml = xml.Replace("&gt;", ">");
                    return xml;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string removeXMLNodeTags(string message)
        {
            message = message.Replace("<", "&lt;");
            message = message.Replace(">", "&gt;");

            return message;
        }
        public static string ReplaceXmlTag(string message)
        {
            message = message.Replace("<", "[");
            message = message.Replace(">", "]");
            return message;

        }
        public static string getFullXML(XElement xElement)
        {
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "ISO-8859-1", String.Empty), xElement);

            //xdoc.AddAfterSelf(xElement);
            return getFullXML(xdoc);
        }

        public static string ConvertDataContractToText(object dataContractOjbect)
        {
            string value = "";
            value = getFullXML(RemoveAllNamespaces(dataContractOjbect));

            return value;
        }
        public static XElement RemoveAllNamespaces(object dataContractObject)
        {
            try
            {
                Type objectType = dataContractObject.GetType();
                DataContractSerializer dcs = new DataContractSerializer(objectType);

                String text;
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    dcs.WriteObject(memoryStream, dataContractObject);
                    text = System.Text.Encoding.ASCII.GetString(memoryStream.ToArray());
                    XElement xelement = XmlHelper.RemoveAllXElementNamespaces(XElement.Parse(text));

                    return xelement;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static XElement RemoveAllXElementNamespaces(XElement xmlDocument)
        {
            try
            {
                if (!xmlDocument.HasElements)
                {
                    XElement xElement = new XElement(xmlDocument.Name.LocalName);
                    xElement.Value = xmlDocument.Value;
                    return xElement;
                }
                return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllXElementNamespaces(el)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static String RemoveXmlDeclarations(string possibleXmlText)
        {

            try
            {
                if (possibleXmlText.Contains("<?xml version"))
                {
                    int startTagLocation = possibleXmlText.IndexOf("<?xml version");
                    int endTagLocation = possibleXmlText.IndexOf(">", startTagLocation);
                    possibleXmlText = possibleXmlText.Remove(startTagLocation, endTagLocation - startTagLocation + 1);
                    possibleXmlText = RemoveXmlDeclarations(possibleXmlText);

                }
                return possibleXmlText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    [DataContract(Name = "methodCall")]
    public class MethodCall
    {
        public MethodCall(string username, string password, string methodName)
        {
            MethodName = methodName;
            methodParameterList = new List<MethodParameter>();
            methodParameterList.Add(new MethodParameter(username));
            methodParameterList.Add(new MethodParameter(password));
        }

        [DataMember(Name = "methodName", Order = 1)]
        public string MethodName { get; set; }

        [DataMember(Name = "params", Order = 2)]
        public List<MethodParameter> methodParameterList { get; set; }

        public string Request
        {
            get
            {
                XElement xElement = XmlHelper.RemoveAllNamespaces(this);
                return XmlHelper.getFullXML(xElement);
            }
        }
    }

    [DataContract(Name = "param")]
    public class MethodParameter
    {
        public MethodParameter()
        { }
        public MethodParameter(string valueToSet)
        {
            value = valueToSet;
        }


        [DataMember(IsRequired = true)]
        public string value { get; set; }
    }

    [DataContract(Name = "param")]
    public class MethodIntArrayParameter : MethodParameter
    {
        public MethodIntArrayParameter()
        { }
        public MethodIntArrayParameter(string[] valueToSet)
        {
            StringBuilder sb = new StringBuilder("<array><data>");
            foreach (string x in valueToSet)
            {
                sb.Append("<value><i4>");
                sb.Append(x);
                sb.Append("</i4></value>");
            }
            sb.Append("</data></array>");
            value = sb.ToString();
        }

        public MethodIntArrayParameter(int[] valueToSet)
        {
            StringBuilder sb = new StringBuilder("<array><data>");
            foreach (int x in valueToSet)
            {
                sb.Append("<value><i4>");
                sb.Append(x.ToString());
                sb.Append("</i4></value>");
            }
            sb.Append("</data></array>");
            value = sb.ToString();
        }
    }

    [DataContract(Name = "param")]
    public class MethodStringArrayParameter : MethodParameter
    {
        public MethodStringArrayParameter()
        { }
        public MethodStringArrayParameter(string[] valueToSet)
        {
            StringBuilder sb = new StringBuilder(valueToSet.Count());
            foreach (string x in valueToSet)
            {
                sb.Append(x + ",");
                //value = "<i4>" + valueToSet.ToString() + "</i4>"; 
            }
            value = sb.ToString();
        }
    }

    [DataContract(Name = "param")]
    public class MethodDateTimeArrayParameter : MethodParameter
    {
        public MethodDateTimeArrayParameter(DateTime [] valueToSet)
        {
            StringBuilder sb = new StringBuilder("<array><data>");
            foreach (DateTime x in valueToSet)
            {
                sb.Append("<value><dateTime.iso8601>");
                sb.Append(x.ToString("yyyyMMddTHH:mm:ss"));
                sb.Append("</dateTime.iso8601></value>");
            }
            sb.Append("</data></array>");
            value = sb.ToString();
        }
        public MethodDateTimeArrayParameter(string[] valueToSet)
        {
            StringBuilder sb = new StringBuilder("<array><data>");
            foreach (string x in valueToSet)
            {
                sb.Append("<value><dateTime.iso8601>");
                sb.Append(x);
                sb.Append("</dateTime.iso8601></value>");
            }
            sb.Append("</data></array>");
            value = sb.ToString();
        }
    }

    [DataContract(Name = "param")]
    public class MethodIntegerParameter : MethodParameter
    {
        public MethodIntegerParameter(int valueToSet)
        {
            value = "<i4>" + valueToSet.ToString() + "</i4>"; 
        }
        public MethodIntegerParameter(string valueToSet)
        {
            value = "<i4>" + valueToSet + "</i4>"; 
        }
    }


    [DataContract(Name = "param")]
    public class MethodDateTimeParameter : MethodParameter
    {
        public MethodDateTimeParameter(DateTime valueToSet)
        {
            value = "<dateTime.iso8601>" + valueToSet.ToString("yyyyMMddTHH:mm:ss") + "</dateTime.iso8601>"; 
        }
        public MethodDateTimeParameter(string valueToSet)
        {
            value = "<dateTime.iso8601>" + valueToSet + "</dateTime.iso8601>"; 
        }
    }
}

