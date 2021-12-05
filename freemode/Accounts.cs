using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GTANetworkAPI;

namespace freemode
{
    class Accounts
    {
        private const string _accountKey = "Player_Data";
        public int _id;
        public string _name;
        public long _cash;
        public Player _player;

        public Accounts()
        {
            this._name = "";
            this._cash = 1000;
        }

        public Accounts(string name, Player player, long cash = 1000)
        {
            this._name = name;
            this._player = player;
            this._cash = cash;
        }

        public static bool IsPlayerLoggedIn(Player player)
        {
            if (player != null) return player.HasData(_accountKey);
            return false;
        }

        public void Register(string name, string password)
        {
            mysql.NewAccountRegister(this, password);
            Login(_player, true);
        }

        public void Login(Player player, bool isFirstLogin)
        {
            mysql.LoadAccount(this);
            if(isFirstLogin)
            {
                player.SendChatMessage("Вы успешно зарегистрированы!");
            }
            else
            {
                player.SendChatMessage("Вы успешно авторизовались!");
            }
            
            player.SetData(Accounts._accountKey, this);
        }

    }
}
