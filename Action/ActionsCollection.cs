using System;
using System.Collections.Generic;
using System.IO;
using Common;

namespace Action
{
    public class ActionsCollection
    {
        public string FolderLocation = AppDomain.CurrentDomain.BaseDirectory;
        private List<Action> mActions = new List<Action>();

        public List<Action> Actions
        {
            get { return mActions; }
            set { mActions = value; }
        }

        public void Load()
        {
            mActions.Clear();
            DirectoryInfo d = new DirectoryInfo(Settings.SaveLocation);
            if (!d.Exists)
            {
                d.Create();
                return;
            }
            FileInfo[] Files = d.GetFiles("*.act");
            foreach (FileInfo file in Files)
            {
                Action action = new Action();
                action.Name = Path.GetFileNameWithoutExtension(file.Name);
                action.FileName = file.FullName;
                if (!action.Load())
                {
                    //TODO: Return error;
                    continue;
                }

                mActions.Add(action);
            }            
        }
    }

}
