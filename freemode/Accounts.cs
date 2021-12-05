using System;
using System.Collections.Generic;
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

        public Accounts()
        {
            this._name = "";
            this._cash = 1000;
        }

        public Accounts(string name, long cash = 1000)
        {
            this._name = name;
            this._cash = cash;
        }

        public static bool IsPlayerLoggedIn(Player player)
        {
            if (player != null) return player.HasData(_accountKey);
            return false;
        }

    }
}
