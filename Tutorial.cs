using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using Insight.Database;
using Insight.Database.Providers.MySql;
using MySql.Data.MySqlClient;
using System;

namespace NewServer
{
    public class Tutorial : Script
    {
        private static MySqlConnectionStringBuilder _database;
        private static IUserRepository _userRepository;

        [Flags]
        public enum AnimationFlags
        {
            Loop = 0 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        }

        public Tutorial()
        {
            API.onResourceStart += API_onResourceStart;
        }

        private void API_onResourceStart()
        {
            MySqlInsightDbProvider.RegisterProvider();
            _database = new MySqlConnectionStringBuilder("server=x;user=x;database=x;password=x");
            _userRepository = _database.Connection().As<IUserRepository>();
        }

        public interface IUserRepository
        {
            UserAccount RegisterAccount(UserAccount userAccount);
            UserAccount GetAccount(string name);
            UserAccount ChangeAusweiss(string aname, string ausweiss);
            UserAccount ChangeSkin(string aname, string skin);
        }

        public class UserAccount
        {
            public string Benutzername { get; set; }
            public string Passwort { get; set; }
            public string Cop { get; set; }
            public string Medic { get; set; }
            public string Ausweiss { get; set; }
        }

        public void ZivTutorial(Client player)
        {
            API.onClientEventTrigger += OnClientEventTrigger;
            //API.sendChatMessageToPlayer(sender, "[DEBUG]:Noobtutorial gestartet");
            API.setEntityPosition(player, new Vector3(-1038, -2738, 20));
            Random rnd = new Random();
            int Zufallszahl = rnd.Next(1, 20);
            switch (Zufallszahl)
            {
                case 1:
                    API.setPlayerSkin(player, (PedHash)(-781039234));
                    _userRepository.ChangeSkin(player.name,"-781039234");
                    break;

                case 2:
                    API.setPlayerSkin(player, (PedHash)68070371);
                    _userRepository.ChangeSkin(player.name, "68070371");
                    break;

                case 3:
                    API.setPlayerSkin(player, (PedHash)(-2077764712));
                    _userRepository.ChangeSkin(player.name, "-2077764712");
                    break;

                case 4:
                    API.setPlayerSkin(player, (PedHash)(-9308122));
                    _userRepository.ChangeSkin(player.name, "-9308122");
                    break;

                case 5:
                    API.setPlayerSkin(player, (PedHash)436345731);
                    _userRepository.ChangeSkin(player.name, "436345731");
                    break;

                case 6:
                    API.setPlayerSkin(player, (PedHash)(-37334073));
                    _userRepository.ChangeSkin(player.name, "-37334073");
                    break;

                case 7:
                    API.setPlayerSkin(player, (PedHash)1674107025);
                    _userRepository.ChangeSkin(player.name, "1674107025");
                    break;

                case 8:
                    API.setPlayerSkin(player, (PedHash)131961260);
                    _userRepository.ChangeSkin(player.name, "131961260");
                    break;

                case 9:
                    API.setPlayerSkin(player, (PedHash)377976310);
                    _userRepository.ChangeSkin(player.name, "377976310");
                    break;

                case 10:
                    API.setPlayerSkin(player, (PedHash)712602007);
                    _userRepository.ChangeSkin(player.name, "712602007");
                    break;

                case 11:
                    API.setPlayerSkin(player, (PedHash)(-88831029));
                    _userRepository.ChangeSkin(player.name, "-88831029");
                    break;

                case 12:
                    API.setPlayerSkin(player, (PedHash)1641152947);
                    _userRepository.ChangeSkin(player.name, "1641152947");
                    break;

                case 13:
                    API.setPlayerSkin(player, (PedHash)1165780219);
                    _userRepository.ChangeSkin(player.name, "1165780219");
                    break;

                case 14:
                    API.setPlayerSkin(player, (PedHash)(-1386944600));
                    _userRepository.ChangeSkin(player.name, "-1386944600");
                    break;

                case 15:
                    API.setPlayerSkin(player, (PedHash)(-782401935));
                    _userRepository.ChangeSkin(player.name, "-782401935");
                    break;

                case 16:
                    API.setPlayerSkin(player, (PedHash)355916122);
                    _userRepository.ChangeSkin(player.name, "355916122");
                    break;

                case 17:
                    API.setPlayerSkin(player, (PedHash)452351020);
                    _userRepository.ChangeSkin(player.name, "452351020");
                    break;

                case 18:
                    API.setPlayerSkin(player, (PedHash)832784782);
                    _userRepository.ChangeSkin(player.name, "832784782");
                    break;

                case 19:
                    API.setPlayerSkin(player, (PedHash)228715206);
                    _userRepository.ChangeSkin(player.name, "228715206");
                    break;

                case 20:
                    API.setPlayerSkin(player, (PedHash)919005580);
                    _userRepository.ChangeSkin(player.name, "919005580");
                    break;

                default:
                    API.sendChatMessageToPlayer(player, "[Error]: Fehler im Skinauswahlsystem");
                    API.consoleOutput("[Error]: Fehler im Skinauswahlsystem");
                    break;
            }
            API.sleep(5000);
            API.sendPictureNotificationToPlayer(player, "Freut mich, dass du in einem Stück angekommen bist. Ich habe ein Paket mit einer Waffe versteckt.", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
            API.sleep(5000);
            API.sendPictureNotificationToPlayer(player, "Ich markiere es dir. Denk an deine Mission!", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
            var shape = API.createSphereColShape(new Vector3(-235.0747, -1280.617, 31.29598), 1f);


            shape.onEntityEnterColShape += (s, ent) =>
            {

                API.playPlayerAnimation(player, (int)AnimationFlags.Loop, "amb@prop_human_bum_bin@enter", "enter");
                API.sleep(4000);
                API.playPlayerAnimation(player, (int)AnimationFlags.Loop, "amb@prop_human_bum_bin@exit", "exit");
                API.givePlayerWeapon(player, (WeaponHash)453432689, 60, false, false);
                API.sleep(10000);
                API.sendPictureNotificationToPlayer(player, "Super, du hast die Waffe. Ich hab dir ein Treffen auf dem GPS markiert.", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
                API.sleep(3000);
                API.sendPictureNotificationToPlayer(player, "Dort gibt es eine Drogenübergabe von einem korrupten Bullen.", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
                API.sleep(3000);
                API.sendPictureNotificationToPlayer(player, "Töte alle bei der Übergabe, hol dir die Packung. Ich melde mich wieder. Viel Glück!", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
                API.deleteColShape(shape);
                Drogenübergabe(player);
            };

            API.triggerClientEvent(player, "PaketGPS", "1");
        }

        public void Drogenübergabe(Client player)
        {
            NetHandle DrogenübergabeGangster = API.createPed((PedHash)648372919, new Vector3(-31,-1236,29.33503), 270, 0);
            API.setEntityInvincible((NetHandle) DrogenübergabeGangster, false);
            NetHandle DrogenübergabeCop = API.createPed((PedHash)(-681004504), new Vector3(-27,-1236,29.33503), 90, 0);
            API.setEntityInvincible((NetHandle)DrogenübergabeCop, false);
            API.triggerClientEvent(player, "drogengps", "1");
        }

        public void Drogenübergabe2(Client player)
        {
            var shape2 = API.createSphereColShape(new Vector3(-38.5, -1252, 29.2), 10f);
            shape2.onEntityEnterColShape += (s, ent) =>
            {
                API.sendPictureNotificationToPlayer(player, "Der Cop sollte das Paket dabei haben. Durchsuche ihn!", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
                API.deleteColShape(shape2);
            };

            var shapeCop = API.createSphereColShape(new Vector3(-27, -1236, 29.33503), 1f);
            shapeCop.onEntityEnterColShape += (s, ent) =>
            {
                API.playPlayerAnimation(player, (int)AnimationFlags.Loop, "amb@prop_human_bum_bin@enter", "enter");
                API.sleep(4000);
                API.playPlayerAnimation(player, (int)AnimationFlags.Loop, "amb@prop_human_bum_bin@exit", "exit");
                API.sleep(4000);
                API.sendChatMessageToPlayer(player, "Du hast das Paket gefunden. Du solltest dich jetzt erstmal in Sicherheit bringen.");
                API.deleteColShape(shapeCop);
                API.sleep(10000);
                API.sendPictureNotificationToPlayer(player, "Du hast Paket? Gut! Wir treffen uns am Pier.", "CHAR_JOSEF", 1, 1, "Josef", "Besorg das Paket!");
                API.triggerClientEvent(player, "piergps", "1");
            };
        }

        public void Piereinleitung(Client player)
        {
            NetHandle TutPier = API.createPed((PedHash)(- 1427838341), new Vector3(-1005.608, -1397.951, 1.595391), -164, 0);
            API.setEntityInvincible((NetHandle)TutPier, false);

            var shapePier = API.createSphereColShape(new Vector3(-1005.608, -1397.951, 1.595391), 1f);
            shapePier.onEntityEnterColShape += (s, ent) =>
            {
                API.sendChatMessageToPlayer(player, "[" + player.name +"]: Hier ist das Paket. Jetzt bist du dran.");
                API.sleep(5000);
                API.sendChatMessageToPlayer(player, "[Josef]: Vielen Dank. Nimm deinen Ausweiß. Wir sind quit.");
                API.sleep(5000);
                API.sendChatMessageToPlayer(player, "[" + player.name + "]: Hau rein.");
                API.sleep(5000);
                API.sendChatMessageToPlayer(player, "Du hast nun deinen Ausweiß. Am besten suchst du dir einen Job. Schaue am besten in der Stadthalle vorbei.");
                _userRepository.ChangeAusweiss(player.name,"1");
                API.removeAllPlayerWeapons(player);
                API.deleteColShape(shapePier);
                API.call("SpawnManager", "ZivSpawnnachTuT", player);
            };
        }


        public void OnClientEventTrigger(Client player, string name, object[] args)
        {
            if (name == "drogen2")
            {
                Drogenübergabe2(player);
            }

            if (name == "pierb")
            {
                Piereinleitung(player);
            }
        }
    }
}
