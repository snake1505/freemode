using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace freemode
{
    class Connections : Script
    {
        [RemoteEvent("authOnRegister")]
        private void OnRegister(Player player, string login, string email, string password)
        {
            if(mysql.IsAccountExist(login))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "showTextError", "Аккаунт с таким именем существует");
                return;
            }


            Accounts account = new Accounts(login, player);
            account.Register(login, email, password);
            NAPI.ClientEvent.TriggerClientEvent(player, "closeLoginWindow");
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", false);
        }
    }
}
