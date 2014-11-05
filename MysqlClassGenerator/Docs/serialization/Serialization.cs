using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace it.furinfo.dll
{
    public static class Serialization
    {
        public static int VERSION = 1;

        #region save binary

        public static void SaveBin(object objToSerialize, FileInfo OutPutFile)
        {
            if (!Directory.Exists(OutPutFile.DirectoryName))
            {
                Directory.CreateDirectory(OutPutFile.DirectoryName);
            }
            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();

            String fullFilePath = OutPutFile.DirectoryName + "\\" + OutPutFile.Name;
            if (Path.GetExtension(fullFilePath) != ".bin")
            {
                fullFilePath += ".bin";
            }


            stream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, VERSION);
            formatter.Serialize(stream, objToSerialize);
            stream.Close();
        }

        public static object LoadBin(FileInfo FileName)
        {
            Stream stream = null;
            object OutPutClass = null;
            IFormatter formatter = new BinaryFormatter();

            String fullFilePath = FileName.DirectoryName + "\\" + FileName.Name;
            if (Path.GetExtension(fullFilePath) != ".bin")
            {
                fullFilePath += ".bin";
            }

            stream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
            int version = (int)formatter.Deserialize(stream);
            Debug.Assert(version == VERSION);
            OutPutClass = formatter.Deserialize(stream);
            stream.Close();
            return OutPutClass;
        }

        #endregion

        #region save XML

        public static void SaveXml(object obj, FileInfo OutPutFile)
        {
            if (!Directory.Exists(OutPutFile.DirectoryName))
            {
                Directory.CreateDirectory(OutPutFile.DirectoryName);
            }

            #region Save the object

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(obj.GetType());

            String fullFilePath = OutPutFile.DirectoryName + "\\" + OutPutFile.Name;
            if (Path.GetExtension(fullFilePath) != ".xml")
            {
                fullFilePath += ".xml";
            }

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(fullFilePath, false);
            SerializerObj.Serialize(WriteFileStream, obj);

            // Cleanup
            WriteFileStream.Close();

            #endregion

        }

        public static object LoadXml(FileInfo fileName, Type type)
        {
            object OutPutClass = null;
            XmlSerializer s = new XmlSerializer(type);


            String fullFilePath = fileName.DirectoryName + "\\" + fileName.Name;
            if (Path.GetExtension(fullFilePath) != ".xml")
            {
                fullFilePath += ".xml";
            }

            TextReader r = new StreamReader(fullFilePath);
            OutPutClass = s.Deserialize(r);
            r.Close();
            return OutPutClass;
        }

        #endregion
    }
}
