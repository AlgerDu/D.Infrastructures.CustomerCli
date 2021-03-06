using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace D.VersionTool
{
    public static class XmlDocumentExtensions
    {
        public static XmlDocument GetXmlData(this ProjectModel project)
        {
            var xml = new XmlDocument();
            xml.Load(project.Path);

            return xml;
        }

        public static void SaveXmlData(this ProjectModel project, XmlDocument xml)
        {
            xml.Save(project.Path);
        }

        public static ProjectVersionModel GetCurrVersion(this XmlDocument xml)
        {
            var node = xml.SelectSingleNode("Project/PropertyGroup/Version");
            var version = new ProjectVersionModel();

            if (node == null)
            {
                version.Version = "1.0.0.0";
            }
            else
            {
                version.Version = node.InnerText;
            }


            return version;
        }

        public static string GetPackageName(this XmlDocument xml, string projectName)
        {
            var version = "";
            var pakName = "";

            var node = xml.SelectSingleNode("Project/PropertyGroup/Version");
            if (node == null)
            {
                version = "1.0.0.0";
            }
            else
            {
                version = node.InnerText;
            }

            node = xml.SelectSingleNode("Project/PropertyGroup/AssemblyName");
            if (node == null)
            {
                pakName = projectName;
            }
            else
            {
                pakName = node.InnerText;
            }

            var tmp = version.Split('.');

            for (var i = 0; i < tmp.Length; i++)
            {
                tmp[i] = Convert.ToInt32(tmp[i]).ToString();
            }

            return $"{pakName}.{string.Join('.', tmp)}.pak";
        }

        public static void SetVersion(this XmlDocument xml, ProjectVersionModel version)
        {
            xml.SetNodeInnerText("Project/PropertyGroup", "Version", version.Version);
            xml.SetNodeInnerText("Project/PropertyGroup", "AssemblyVersion", version.AssemblyVersion);
            xml.SetNodeInnerText("Project/PropertyGroup", "FileVersion", version.FileVersion);
        }

        private static void SetNodeInnerText(this XmlDocument xml, string parent, string name, string value)
        {
            var node = xml.SelectSingleNode($"{parent}/{name}");

            if (node == null)
            {
                node = xml.CreateElement(name);

                var parentNode = xml.SelectSingleNode(parent);
                parentNode.AppendChild(node);
            }

            node.InnerText = value;
        }
    }
}
