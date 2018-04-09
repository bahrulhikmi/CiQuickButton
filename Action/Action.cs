using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;

namespace Action
{
    public class Action : Common.IAction
    {
        private ActionData data;
        private String fileName;

        public Action()
        {
            data = new ActionData();
        }
        
        public string Name
        {
            get { return data.Name; }
            set { data.Name = value; }
        }

        public string Script
        {
            get { return data.Script; }
            set { data.Script = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public void Save()
        {
            if (String.IsNullOrEmpty(FileName))
            {
                fileName = Path.Combine(Common.Settings.SaveLocation, Name);
                fileName += ".act";
            }

            XmlSerializer serializer =
            new XmlSerializer(typeof(ActionData));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, data);
            writer.Close();
        }

        public bool Load()
        { 
            XmlSerializer serializer = new XmlSerializer(typeof(ActionData)); 
 
            FileStream fs = new FileStream(FileName, FileMode.Open); 
            data = (ActionData)serializer.Deserialize(fs);
            fs.Close();
            return (data != null);
        }

        public void Delete()
        {

        }

        public string GetCommand()
        {
            return Script;
        }
    }
}
