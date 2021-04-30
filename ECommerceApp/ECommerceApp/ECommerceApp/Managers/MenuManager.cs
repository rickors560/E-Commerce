using ECommerceApp.Menu.Login_Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Managers
{
    public class MenuManager
    {
        public bool CreateMenu()
        {
            LoginMenu loginMenu = new LoginMenu();
            bool showmenu = true;
            do
            {
                showmenu = loginMenu.ShowLoginMenu();
            }
            while (showmenu);
            return true;
        }
    }
}