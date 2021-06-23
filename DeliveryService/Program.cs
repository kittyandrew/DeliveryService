using System;
using System.Collections.Generic;
using DeliveryService.Dao;
using DeliveryService.Model;
using DeliveryService.Logic;
using DeliveryService.ConsoleView;

namespace DeliveryService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DaoObject dao = new DaoObject();
            IProductProc productProc = new ProductProc(dao);
            IDeliveryProc deliveryProc = new DeliveryProc(dao);

            MainMenuView mainMenu = new MainMenuView(productProc, deliveryProc);
            mainMenu.Menu();
        }
    }
}
