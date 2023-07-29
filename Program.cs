using System;
using Terminal.Gui;

namespace MCBACKUPGENERATOR
{
    class Program
    {
        MinecraftServer SELECTED_SERVER = null;
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

            var option1Button = new Button("Option 1")
            {
                X = Pos.Center(),
                Y = Pos.Percent(40),
            };
            MenuWindow.Add(option1Button);

            var option2Button = new Button("Cancel")
            {
                X = Pos.Center(),
                Y = Pos.Percent(60),
            };
            MenuWindow.Add(option2Button);

            option1Button.Clicked += () =>
            {
                MessageBox.Query("Option 1", "You clicked Option 1!", "OK");
                top.Remove(MenuWindow);
            };

            option2Button.Clicked += () =>
            {
                MessageBox.Query("Cancel", "Backup Choosal Canceled", "OK");
                top.Remove(MenuWindow);
                Application.RequestStop();
            };
            Application.Run(MenuWindow);
        }
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
                    new MenuItem("_Load Config" , "" , () =>
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
            var button = new Button("Button")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(label) + 1,
            };
            button.Clicked += () => {
                ChooseOptionForBackup(top);
            };
            window.Add(button);
            window.Add(label);
            Application.Run();
        }
    }
}