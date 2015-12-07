using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ClientManager
{
    public class XmlManageList<T>: IManageList<T> where T: new()
    {
        private const string FileName = "serverList.xml";

        public void SaveList(BindingList<T> serverList)
        {
            if (File.Exists(FileName)) File.Delete(FileName);

            XmlSerializer serialiser = new XmlSerializer(typeof(List<T>));
            using (TextWriter fileStream = new StreamWriter(FileName))
            {
                try
                {
                    serialiser.Serialize(fileStream, serverList.ToList());
                }
                catch (IOException e)
                {
                    throw new Exception(string.Format("{0} - {1}",
                        "Не удалось сохранить список серверов ", e.Message));
                }
            }
        }

        public BindingList<T> ReadList()
        {
            BindingList<T> serversList = new BindingList<T>();

            if (!File.Exists(FileName)) return serversList;

            using (StreamReader streamReader = new StreamReader(FileName))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(BindingList<T>));
                    serversList = (BindingList<T>)serializer.Deserialize(streamReader);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("{0} - {1}",
                        "Ошибка в списке серверов, удалите XML файл со списком серверов", e.Message));
                }
            }

            return serversList;
        }


    }
}
