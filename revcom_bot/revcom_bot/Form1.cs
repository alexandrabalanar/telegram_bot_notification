using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace revcom_bot
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw;
        String level;
        String name;
        Timer timer = new Timer();
       
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
            var worker = sender as BackgroundWorker;
            int Answer = 0;

            var key = e.Argument as String;
            try
            {
                var Bot = new Telegram.Bot.TelegramBotClient(key); 
                await Bot.SetWebhookAsync(""); 
                Bot.OnUpdate += async (object su, Telegram.Bot.Args.UpdateEventArgs evu) =>
                {
                    if (evu.Update.CallbackQuery != null || evu.Update.InlineQuery != null) return; 
                    var update = evu.Update;
                    var message = update.Message;
                    if (message == null) return;
                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage)
                    {
                        if (Answer == 0)
                        {
                            if (message.Text == "Начал" | message.Text == "начал")
                            {

                                await Bot.SendTextMessageAsync(message.Chat.Id, "Над чем Вы начали работать?", replyToMessageId: message.MessageId);
                                Answer = 1;
                                return;
                            }
                            if (message.Text == "Готово" | message.Text == "готово")
                            {

                                await Bot.SendTextMessageAsync(message.Chat.Id, "Молодец");
                                DBConnect qwe = new DBConnect();
                                qwe.Update(name);

                                return;
                            }
                            if (message.Text == "Отчет" | message.Text == "отчет")
                            {
                                DBConnect dsa = new DBConnect();
                                dsa.Select();

                            }
                        }
                        if (Answer == 1)
                        {

                            name = message.Text;
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Окей, какая сложность задачи (от 0 до 10)?!");

                            Answer = 2;
                            return;
                        }
                        if (Answer == 2)
                        {
                            String s = message.Chat.Id.ToString();
                            level = message.Text;
                            Regex regex = new Regex("[0-9]");
                         //   int nlevel = int.Parse(level.ToString());
                            bool check;
                            Validation qw = new Validation();
                            check = qw.ValidLevel(level);
                            if (check == false)
                            {
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Неверный формат, попробуйте еще раз");
                                return;
                            }
                            else
                            {

                                DBConnect qwe = new DBConnect();
                                qwe.Insert(message.Chat.FirstName, message.Chat.LastName, s, name, level, DateTime.Now);

                                Answer = 0;
                                await Bot.SendTextMessageAsync(message.Chat.Id, "Напишите 'Готово', как закончите");
                               
                                return;
                            }
                        }
                    
                    }
                };

               
                Bot.StartReceiving();
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            var text = @txtKey.Text; 
            if (text != "" && this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync(text); 
                BtnRun.Text = "Бот запущен...";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
