using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        string password = null;
        while (string.IsNullOrEmpty(password))
        {
            password = ConfigurationManager.AppSettings["Password"];
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("\n   ╔══════════════════════════════════════════════════════╗ ");
                Console.WriteLine("   ║      Bienvenue dans Gestionnaire Mot de Passe        ║ ");
                Console.WriteLine("   ╚══════════════════════════════════════════════════════╝ \n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   Créez votre mot de passe: ");
                Console.ForegroundColor = ConsoleColor.White;
                password = Console.ReadLine();
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configFile.AppSettings.Settings.Add("Password", password);
                configFile.Save(ConfigurationSaveMode.Modified);
            }
        }

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n          ■      ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ■      ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ■      ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ■      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ■      ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ■     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   ╔══════════════════════════════════════════════════════╗ ");
            Console.WriteLine("   ║      Bienvenue dans Gestionnaire Mot de Passe        ║ ");
            Console.WriteLine("   ╚══════════════════════════════════════════════════════╝ ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n   Entrez votre mot de passe: ");
            Console.ForegroundColor = ConsoleColor.White;
            string inputPassword = Console.ReadLine();


            if (inputPassword == password)
            {
                break;
                Console.WriteLine(" Veuillez ressayer.");
            }
            else
            {
                Console.SetCursorPosition(10, 7);
                Console.Write("\r   Mot de passe");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Incorrect.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Veuillez ressayer.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   Appuyez sur Enter");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
        Start(password);
    }

    public static void Start(string password)
    {
        Console.SetCursorPosition(5, Console.CursorTop);
        //Console.SetWindowSize(100, 40);
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        //Titre de la console.
        Console.Title = ("Gestionnaire Mot de Passe");

        // Déclaration des Initialisation des Variables.
        char reponse = ' ';
        int intValUser = 0;
        string valUser;
        int valMax = 6;
        int valMin = 1;

        do
        {

            // Titre du Programme
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            //Console.BufferWidth = Console.WindowWidth;
            Console.WriteLine("\n   ╔════════════════════════════════════════╗ ");
            Console.WriteLine("   ║       Gestionnaire Mot de Passe        ║ ");
            Console.WriteLine("   ╚════════════════════════════════════════╝ \n");

            Console.ForegroundColor = ConsoleColor.DarkGray; // Méthode qui change la couleur du texte en Gris foncé.
            Console.WriteLine(" ■   Choissisez une action"); // Demande à l'utilisateur de rentrer une valeur.
            Console.ForegroundColor = ConsoleColor.White; // Méthode qui change la couleur du texte en Blanc.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ■ 1 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Liste Mot de Passe");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ■ 2 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ajouter un Mot de Passe");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ■ 3 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Modifier un mot de Passe");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" ■ 4 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Supprimer un mot de passe");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ■ 5 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Changer le Mot de passe Maître");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" ■ 6 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Quitter le Programme");
            Credits();

            do
            {
                Console.SetCursorPosition(10, 16); // Remets le curseur à la position 10.7.
                Console.SetCursorPosition(0, Console.CursorTop - 1); // remonte d'une ligne le curseur.
                suppligneActuelle(); // Appelle une fonction.
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" ■   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Action : ");
                Console.ForegroundColor = ConsoleColor.Gray; // Méthode qui change la couleur du texte en Vert.
                valUser = Console.ReadLine(); // Méthode qui va lire la valeur entrée par l'utilisateur.
                Console.ForegroundColor = ConsoleColor.White; // Méthode qui change la couleur du texte en Blanc.
            } while (!int.TryParse(valUser, out intValUser) || ((intValUser < valMin || intValUser > valMax)));

            if (intValUser == 1)
            {
                readPassword(password);
            }

            if (intValUser == 2)
            {
                addPassword(password);
            }

            if (intValUser == 3)
            {
                editPassword(password);
            }

            if (intValUser == 4)
            {
                deletePassword(password);
            }

            if (intValUser == 5)
            {
                editPassword();
            }

            if (intValUser == 6)
            {
                Environment.Exit(0); // Quitte le programme
            }

            do
            {
                reponse = Console.ReadKey(true).KeyChar; // Va lire le caractère entré par l'utilisateur.
            } while (reponse != 'r'); // Si l'utilisateur ne rentre pas la valeur 'o' ou 'n' l'utilisateur reste coincé dans la boucle.

            Console.Clear(); // Nettoie la console.

        } while (reponse == 'r'); // Si l'utilisateur rentre le caractère 'o' le programme recommence.
    }

    static byte[] Encrypt(byte[] plainBytes, string password)
    {
        using (Aes aes = Aes.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(passwordBytes, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1000);
            aes.Key = derivedKey.GetBytes(16);
            aes.IV = derivedKey.GetBytes(16);

            using (MemoryStream output = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
                return output.ToArray();
            }
        }
    }

    static byte[] Decrypt(byte[] encryptedBytes, string password)
    {
        using (Aes aes = Aes.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(passwordBytes, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1000);
            aes.Key = derivedKey.GetBytes(16);
            aes.IV = derivedKey.GetBytes(16);

            using (MemoryStream input = new MemoryStream(encryptedBytes))
            using (CryptoStream cs = new CryptoStream(input, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (MemoryStream output = new MemoryStream())
            {
                cs.CopyTo(output);
                return output.ToArray();
            }
        }
    }
    static void DecryptAndDisplay(string password)
    {
        string inputFile = "Encrypted.txt";
        byte[] encryptedBytes = File.ReadAllBytes(inputFile);

        while (true)
        {
            try
            {
                byte[] decryptedBytes = Decrypt(encryptedBytes, password);
                string decryptedSentence = Encoding.UTF8.GetString(decryptedBytes);
                Console.WriteLine("Decrypted sentence: {0}", decryptedSentence);
                break;
            }
            catch (CryptographicException)
            {
                Console.WriteLine("Incorrect password. Please try again.");
                Console.Write("Enter the password to decrypt: ");
                password = Console.ReadLine();
            }
        }
    }
    static void editPassword()
    {
        Console.Clear();
        Console.WriteLine("\n   ╔══════════════════════════════════════════╗ ");
        Console.WriteLine("   ║        Changer le mot de passe           ║ ");
        Console.WriteLine("   ╚══════════════════════════════════════════╝ \n");
        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\r   Il est conseillé de choisir un mot de passe");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Solide.");
        Console.SetCursorPosition(10, 7);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\r  ■ ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Entrez votre nouveau mot de passe: ");
        string password = Console.ReadLine();

        configFile.AppSettings.Settings["Password"].Value = password;
        configFile.Save(ConfigurationSaveMode.Modified);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(1, 9);
        Console.WriteLine(" Mot de passe Modifié !");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(10, 10);
        Console.WriteLine("\r  Appuyez sur Enter");

        RetourMenu(password);
    }

    public static void addPassword(string password)
    {
        Console.Clear();
        Console.WriteLine("\n   ╔════════════════════════════════════════╗ ");
        Console.WriteLine("   ║        Ajouter un Mot de Passe         ║ ");
        Console.WriteLine("   ╚════════════════════════════════════════╝ \n");
        Console.ForegroundColor = ConsoleColor.DarkGray; // Méthode qui change la couleur du texte en Gris foncé.
        Console.WriteLine("   Entrez les Informations demandées "); // Demande à l'utilisateur de rentrer une valeur.
        Console.ForegroundColor = ConsoleColor.White; // Méthode qui change la couleur du texte en Blanc.
        Console.WriteLine();
        string websitename = "";
        do
        {
            Console.SetCursorPosition(10, 8); // Remets le curseur à la position 10.7.
            Console.SetCursorPosition(0, Console.CursorTop - 1); // remonte d'une ligne le curseur.
            suppligneActuelle(); // Appelle une fonction.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ■ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Entrez le Nom du Site : ");
            websitename = Console.ReadLine();
        } while (string.IsNullOrEmpty(websitename));

        string strlogin = "";
        do
        {
            Console.SetCursorPosition(10, 9); // Remets le curseur à la position 10.7.
            Console.SetCursorPosition(0, Console.CursorTop - 1); // remonte d'une ligne le curseur.
            suppligneActuelle(); // Appelle une fonction.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ■ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Entrez le Login : ");
            strlogin = Console.ReadLine();
        } while (string.IsNullOrEmpty(strlogin));

        string strRiez = "";
        do
        {
            Console.SetCursorPosition(10, 10); // Remets le curseur à la position 10.7.
            Console.SetCursorPosition(0, Console.CursorTop - 1); // remonte d'une ligne le curseur.
            suppligneActuelle(); // Appelle une fonction.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ■ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Entrez le Mot de Passe : ");
            strRiez = Console.ReadLine();
        } while (string.IsNullOrEmpty(strRiez));
        Validation();
        string userEntry;
        while (true)
        {
            Console.SetCursorPosition(10, 11); // Remets le curseur à la position 10.7.
            Console.SetCursorPosition(0, Console.CursorTop - 1); // remonte d'une ligne le curseur.
            suppligneActuelle(); // Appelle une fonction.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" ■ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enregister ? ");
            userEntry = Console.ReadLine();

            if (userEntry.ToLower() == "n")
            {
                Console.Clear();
                Start(password);
            }

            else if (userEntry.ToLower() == "y")
            {
                byte[] sentenceBytes = Encoding.UTF8.GetBytes("\n    Login: " + strlogin + "\n    Mot de passe: " + strRiez);

                byte[] encryptedBytes = Encrypt(sentenceBytes, password);

                byte[] encryptedFilenameBytes = Encrypt(Encoding.UTF8.GetBytes(websitename), password);
                string encryptedFilename = Convert.ToBase64String(encryptedFilenameBytes);

                string outputFile = @"MDP/" + encryptedFilename + ".txt";

                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(encryptedBytes);
                }
                Sauv();
                Valid();
                RetourMenu(password);
            }

            else
            {
                continue; // re pose la question si l'entrée est invalide
            }

        }
    }

    public static void readPassword(string password)
    {
        Console.Clear();
        Console.WriteLine("\n   ╔══════════════════════════════════════════════╗ ");
        Console.WriteLine("   ║            Liste Mot de passe                ║ ");
        Console.WriteLine("   ╚══════════════════════════════════════════════╝ \n");

        DirectoryInfo directory = new DirectoryInfo("MDP");
        FileInfo[] files = directory.GetFiles("*.txt");

        int count = 1;
        foreach (FileInfo file in files)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ■ ");
            byte[] encryptedFilenameBytes = Convert.FromBase64String(Path.GetFileNameWithoutExtension(file.Name));
            string decryptedFilename = Encoding.UTF8.GetString(Decrypt(encryptedFilenameBytes, password));

            Console.Write($"{count}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" Site Web : {decryptedFilename}");
            byte[] encryptedBytes = File.ReadAllBytes(file.FullName);

            string base64Encrypted = Convert.ToBase64String(encryptedBytes);
            byte[] cipherText = Convert.FromBase64String(base64Encrypted);

            byte[] decryptedBytes = Decrypt(cipherText, password);
            string sentence = Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine(sentence);
            Console.WriteLine("   ---------------------");
            Console.WriteLine();
            count++;
        }

        if (count == 1) // Si l'utilisateur n'a pas enregistré de mot de passe dans sa liste 
        {
            Console.WriteLine("   Vous n'avez encore pas enregistré de mot de passe");
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("   Appuyez sur Enter pour retourner au Menu ");
        RetourMenu(password);
    }

    public static void RetourMenu(string password) // Fonction qui ramène l'utilisateur au menu avec la touche Enter
    {
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Start(password);
            }
        } while (true);
    }

    public static void suppligneActuelle() // Fonction qui permets de "nettoyer" la ligne si l'utilisateur rentre une donnée incorrecte.
    {
        int ligneCurseurActuel = Console.CursorTop; // Variable Curseur.
        Console.SetCursorPosition(0, Console.CursorTop); // Remets la valeur à 0.
        Console.Write(new string(' ', Console.WindowWidth)); // va remplacer la valeur entrée par ' '.
        Console.SetCursorPosition(0, ligneCurseurActuel); // Remets le curseur sur la ligne de base.
    }

    public static void Validation() // Fonction de mise en page qui demande à l'utilisateur de choisir entre oui et non
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(10, 11);
        Console.WriteLine();
        Console.WriteLine(" Oui / Non");
        Console.WriteLine(" (y/n)");
    }
    public static void Sauv() // Fonction de mise en page qui confirme à l'utilisateur la sauvegarde
    {
        Console.SetCursorPosition(1, 12);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Sauvegardé !");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void Valid() // Fonction de mise en page qui demande à l'utilisateur d'appuyer sur enter
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(10, 13);
        Console.WriteLine("\r Appuyez sur Enter");

    }


    public static void deletePassword(string password)
    {
        Console.Clear();
        Console.WriteLine("\n   ╔══════════════════════════════════════════════════════╗ ");
        Console.WriteLine("   ║              Supprimer un mot de passe               ║ ");
        Console.WriteLine("   ╚══════════════════════════════════════════════════════╝ \n");

        Console.ForegroundColor = ConsoleColor.DarkGray; // Méthode qui change la couleur du texte en Gris foncé.
        Console.WriteLine(" ■   Appuyez deux fois sur Enter pour retourner au Menu\n"); // Demande à l'utilisateur de rentrer une valeur.
        Console.ForegroundColor = ConsoleColor.White; // Méthode qui change la couleur du texte en Blanc.

        DirectoryInfo directory = new DirectoryInfo("MDP");
        FileInfo[] files = directory.GetFiles("*.txt");

        int count = 1;
        foreach (FileInfo file in files)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ■ ");
            byte[] encryptedFilenameBytes = Convert.FromBase64String(Path.GetFileNameWithoutExtension(file.Name));
            string decryptedFilename = Encoding.UTF8.GetString(Decrypt(encryptedFilenameBytes, password));

            Console.Write($"{count}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" Nom du Site Web : {decryptedFilename}");
            byte[] encryptedBytes = File.ReadAllBytes(file.FullName);

            string base64Encrypted = Convert.ToBase64String(encryptedBytes);
            byte[] cipherText = Convert.FromBase64String(base64Encrypted);

            byte[] decryptedBytes = Decrypt(cipherText, password);
            string sentence = Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine(sentence);
            Console.WriteLine("   ---------------------");
            Console.WriteLine();
            count++;
        }

        int promptRow = Console.CursorTop; // store the row position of the prompt
        Console.Write(" ■   Entrez le numéro du Mot de passe que vous souhaitez supprimer: ");
        string input = Console.ReadLine();

        int choice;
        while (!int.TryParse(input, out choice) || choice < 1 || choice > files.Length)
        {
            Console.SetCursorPosition(1, promptRow); // reset cursor position to prompt row
            Console.Write(new string(' ', Console.WindowWidth)); // clear previous prompt
            Console.SetCursorPosition(0, promptRow); // reset cursor position to prompt row
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ■   Entrez le numéro du Mot de passe que vous souhaitez supprimer: ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                RetourMenu(password);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        File.Delete(files[choice - 1].FullName);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Mot de passe supprimé avec succès");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" Appuyez sur Enter");
        Console.ForegroundColor = ConsoleColor.White;
        RetourMenu(password);
    }

    public static void editPassword(string password)
    {
        Console.Clear();
        Console.WriteLine("\n   ╔════════════════════════════════════════╗ ");
        Console.WriteLine("   ║         Modifier un Mot de Passe       ║ ");
        Console.WriteLine("   ╚════════════════════════════════════════╝ \n");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("   Entrez les informations demandées ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

        string websitename = "";
        do
        {
            Console.SetCursorPosition(10, 8);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            suppligneActuelle();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ■ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Entrez le Nom du Site : ");
            websitename = Console.ReadLine();
        } while (string.IsNullOrEmpty(websitename));

        string filename = @"MDP/" + Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(websitename), password)) + ".txt";

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Désolé, le fichier n'existe pas.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("   Appuyez sur une touche pour retourner au menu principal.");
            Console.ReadKey(true);
            Start(password);
        }

        using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            BinaryReader br = new BinaryReader(fs);
            byte[] encryptedBytes = br.ReadBytes((int)fs.Length);

            byte[] decryptedBytes = Decrypt(encryptedBytes, password);

            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            string[] lines = decryptedText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            string strlogin = lines[1].Replace("Login: ", "");
            string strRiez = lines[2].Replace("Mot de passe: ", "");

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   Le fichier a été trouvé.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();

            Console.SetCursorPosition(10, 10);
            Console.Write("Entrez le nouveau login : ");
            string newlogin = Console.ReadLine();

            Console.SetCursorPosition(10, 11);
            Console.Write("Entrez le nouveau mot de passe : ");
            string newpassword = Console.ReadLine();

            Console.SetCursorPosition(10, 12);
            Console.Write("Voulez-vous vraiment enregistrer les modifications ? (y/n) : ");

            string userEntry = Console.ReadLine();

            if (userEntry.ToLower() == "n")
            {
                RetourMenu(password);
            }

            else if (userEntry.ToLower() == "y")
            {
                byte[] sentenceBytes = Encoding.UTF8.GetBytes("\n    Login: " + newlogin + "\n    Mot de passe: " + newpassword);

                byte[] encryptedBytesEDIT = Encrypt(sentenceBytes, password);

                using (FileStream fs2 = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs2);
                    bw.Write(encryptedBytesEDIT);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n   Les modifications ont été enregistrées.");
            }
        }
    }

    public static void Credits()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray; // Méthode qui change la couleur du texte en Gris foncé.
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.WriteLine("   Thibaud Racine - ETML 2023");
    }
}
