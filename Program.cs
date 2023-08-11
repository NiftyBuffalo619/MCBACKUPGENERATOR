using System;
using Terminal.Gui;

namespace MCBACKUPGENERATOR
{
    class Program
    {
        public static MinecraftServer SELECTED_SERVER = null;
        static void ChooseOptionForBackup(Toplevel top)
        {
            var MenuWindow = new Window("Choose Backup")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = Dim.Percent(50),
                Height = Dim.Percent(50)
            };
            top.Add(MenuWindow);

            int i = 0;
            foreach (MinecraftServer server in MinecraftServer.ServerList)
            {
                i++;
                var button = new Button(server.Name)
                {
                    X = Pos.Center(),
                    Y = 2 + i,
                };

                button.Clicked += () =>
                {
                    SELECTED_SERVER = server;
                    MessageBox.Query("Info", "You have choosen " + server.Name, "OK");
                    top.Remove(MenuWindow);
                    selectedLabel.Text = "Choosen Server: " + server.Name;
                    Application.RequestStop();
                };
                MenuWindow.Add(button);
            }

            var option2Button = new Button("Cancel")
            {
                X = Pos.Center(),
                Y = Pos.Percent(60),
            };
            MenuWindow.Add(option2Button);

            option2Button.Clicked += () =>
            {
                MessageBox.Query("Cancel", "Backup Choosal Canceled", "OK");
                top.Remove(MenuWindow);
                Application.RequestStop();
            };
            Application.Run(MenuWindow);
        }


        public static Label selectedLabel = new Label("Backup not selected yet")
        {
            X = 0,
            Y = 0,
        };
        static void Main(string[] args)
        {
            Config.LoadConfig();
            // DEBUG ONLY MinecraftServer.LoopList();
            Console.Title = "BackupGenerator " + Reference.Version;
            Application.Init();
            var top = Application.Top;
            var window = new Window("Terminal")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            top.Add(window);

            var menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem("_File", new MenuItem[]
                {
                    new MenuItem("_Reload Config" , "" , () =>
                    {

                    }),
                    new MenuItem("_Quit", "" , () =>
                    {
                        Application.RequestStop();
                    })
                })
            });
            top.Add(menu);

            /*var statusBar = new StatusBar(new StatusItem[]
            {
                new StatusItem(Key.CtrlMask | Key.Q, "Quit", () =>
                {
                    top.Running = false;
                })
            });
            statusBar.Frame = new Rect(0, 0, top.Frame.Width, 1);
            top.Add(statusBar);*/
            var label = new Label("Welcome to backup generator!")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            var button = new Button("Choose a backup")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(label) + 1,
            };
            button.Clicked += () => {
                ChooseOptionForBackup(top);
            };
            var MakeBackupButton = new Button("Make Backup")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(label) + 2,
            };
            MakeBackupButton.Clicked += () =>
            {
                if (SELECTED_SERVER == null)
                {
                    MessageBox.ErrorQuery("Error", "No Backup selected", "OK");
                    return;
                }

                MessageBox.Query("Info", "Backup successfully made!", "OK");
            };
            window.Add(MakeBackupButton);
            window.Add(selectedLabel);
            if (SELECTED_SERVER != null)
            {
                selectedLabel.Text = SELECTED_SERVER.Name;
            }
            window.Add(button);
            window.Add(label);
            Application.Run();
        }
    }
}