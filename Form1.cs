using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace revcom_bot
{
    public partial class Form1 : Form
    {

        public BackgroundWorker bw;
        public long chatID;
        public float balance;
        public float startBonus;
 
        List<string> Commands;
        public Form1()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            this.bw = new BackgroundWorker();
            this.bw.DoWork += bw_DoWork;
        }

        

       

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
        	
            /*Commands.Add("/start"); 
            Commands.Add("/balance"); 
            Commands.Add("/chatID"); 
            Commands.Add("/ОРЁЛ"); 
            Commands.Add("/РЕШКА"); 
            Commands.Add("/0,2"); 
            Commands.Add("/0,4"); 
            Commands.Add("/0,6"); 
            Commands.Add("/0,8");*/

            var worker = sender as BackgroundWorker;
            var key = "400994008:AAF_AngoYyaakmuAhsv63kSR_fXkO6NA8ek"; // получаем ключ из аргументов

            bool rate = false;
            int rateCount; //ОРЁЛ - 1 :РЕШКА - 2.
            int randomizeCount;
            Random rand = new Random();

            try
            {

                var Bot = new Telegram.Bot.TelegramBotClient(key); // инициализируем API
                await Bot.SetWebhookAsync("");
                //Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset); // получаем массив обновлений

                    foreach (var update in updates) // Перебираем все обновления
                    {
                        var message = update.Message;

                        chatID = message.Chat.Id;
                        
                        const string connStr = "server=localhost;user=root;database=bot_1;password = 000000;";

                        MySqlConnection conn = new MySqlConnection(connStr);

                        conn.Open();

                        string blnc = "SELECT balance FROM bot_1.user where id = " + chatID;

                        MySqlCommand commandCheckBalance = new MySqlCommand(blnc, conn);

                        balance = (float)Convert.ToDouble(commandCheckBalance.ExecuteScalar());
                        conn.Clone();

                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                        {
                        	/*for (int i = 0; i < 9;i++)
                            {
                        		if (message.Text.Substring(0, 1) != Commands[i])
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Я тебя не понимаю..	Напиши /start !");
                                }
                            }*/



                            if (message.Text == "/start")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Начнём💸	" +
                                                               "\r\n\r\nДля начала я даю тебе " + startBonus.ToString() + " рублей." +
                                                              "\r\nА благодаря этому боту можно влёгкую поднять денег!👑 " +
                                                              "\r\nВсеголишь угадывая монету. " +
                                                              "\r\nПрямо сейчас можешь начать зарабатывать!");
                                // reply buttons
                                var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                {
                                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/0,2"),
                                                    new Telegram.Bot.Types.KeyboardButton("/0,4"),
                                                    new Telegram.Bot.Types.KeyboardButton("/0,6"),
                                                    new Telegram.Bot.Types.KeyboardButton("/0,8")
                                                },
                                            },
                                    ResizeKeyboard = true
                                };

                                await Bot.SendTextMessageAsync(message.Chat.Id, "Сделай ставку:", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                            }

                            if (message.Text == "/0,2" || message.Text == "/0,4" || message.Text == "/0,6" || message.Text == "/0,8")
                            {
                                
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Ставки приняты💰");
                                 var keyboard2 = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("/ОРЁЛ"),
                                                    new Telegram.Bot.Types.KeyboardButton("/РЕШКА")
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                                 
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Испытай удачу!💸", false, false, 0, keyboard2, Telegram.Bot.Types.Enums.ParseMode.Default);
                            }

                           

                            if (message.Text == "/balance")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Твой баланс💸:" + balance);

                            }
                            if (message.Text == "/chatID")
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Твой chatID:" + chatID);

                            }

                            // обработка reply кнопок
                            if (message.Text == "/ОРЁЛ")
                            {
                                rate = true;
                                rateCount = 1;
                                randomizeCount = rand.Next(0, 2);
                                if (randomizeCount == 0)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ии этооо... ОРЁЛ \r\nУгадал!😇");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Тебе зачислено💸:");
                                }
                                if (randomizeCount == 1)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ии этооо... РЕШКА \r\nНе угадал!😈");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "С чёта списано💵:");

                                }
                            }
                            if (message.Text == "/РЕШКА")
                            {

                                rate = true;
                                rateCount = 2;
                                randomizeCount = rand.Next(0, 2);
                                if (randomizeCount == 1)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ии этооо... РЕШКА \r\nУгадал!😇");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Тебе зачислено💸:");
                                }
                                if (randomizeCount == 0)
                                {

                                    await Bot.SendTextMessageAsync(message.Chat.Id, "Ии этооо... ОРЁЛ \r\nНе угадал!😈");
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "С чёта списано💵:");
                                }
                            }
                            Bot.StartReceiving();
                        }

                        offset = update.Id + 1;
                    }

                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }
        }





        async void button1Click(Object sender, EventArgs e)
        {
            var Bot = new Telegram.Bot.TelegramBotClient("400994008:AAF_AngoYyaakmuAhsv63kSR_fXkO6NA8ek"); // инициализируем API 
            await Bot.SetWebhookAsync("");
            //Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
            await Bot.SendTextMessageAsync(chatID, "Менты!! Мы закроемся не на долго🚔(Ведутся тех.работы)");
            Application.Exit();
        }


        void button2Click(object sender, EventArgs e)
        {
            startBonus = (float)Convert.ToDouble(textBox1.Text);

        }
        void BtnRunClick(object sender, EventArgs e)
        {
            this.bw.RunWorkerAsync("400994008:AAF_AngoYyaakmuAhsv63kSR_fXkO6NA8ek"); // передаем эту переменную в виде аргумента методу bw_DoWork

        }




    }
}

