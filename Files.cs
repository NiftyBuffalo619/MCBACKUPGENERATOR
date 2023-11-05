using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using System.IO;
using System.Data;

namespace MCBACKUPGENERATOR
{
    class Files
    {
        public static void WriteAllFilesFromDirectory(string path, Window files_window)
        {
            if (Directory.Exists(path))
            {
                var textView = new TextView()
                {
                    X = 0,
                    Y = 0,
                    Width = Dim.Fill(),
                    Height = Dim.Fill(),
                };
                DataTable dt = new DataTable();
                dt.Columns.Add("File Name", typeof(string));
                TableView view = new TableView()
                {
                    X = 0,
                    Y = 0,
                    Width = Dim.Fill(),
                    Height = Dim.Fill(),
                };
                view.Table = dt;
                string[] files = Directory.GetFiles(path);
                view.Style.GetOrCreateColumnStyle(dt.Columns["File Name"])
                    .RepresentationGetter = (v) => files [(int)v];
                foreach (string file in files)
                {
                    textView.Text += Path.GetFileName(file) + Environment.NewLine;
                }
                files_window.Add(textView);
            }
            else
            {
                MessageBox.ErrorQuery("Error", "The Path isn't existing", "OK");
            }
        }
    }
}
