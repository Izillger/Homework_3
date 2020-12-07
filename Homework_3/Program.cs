using System;
using System.Threading;

namespace Homework_3
    {
    class Program
    {
        #region // Переменные
        static string user1, user2;             // Переменные для двух игроков
        static string comp = "SKYNET";          // Имя компьютера-противника
        static byte turnUser; // 1 - игрок1, 2 - игрок2, 3 - игрок для режима AI, 4 - SKYNET (комп)
        static Random randNum = new Random();   // Для рандомного числа
        static int gameNumber;                  // Случайное число
        static int userTry;                     // Диапазон разрешённых чисел для игры
        private static bool isTwelve = false;      // Для использования числа 12 в userTry
        #endregion

        static void Main(string[] args)
        {
            GameMode();            // Выбор режима игры
        }

        static void GameMode()
        { 
            string start = null;
            // Предложение дополнительного условия в игре
            Console.WriteLine($"Разрешить использовать число 12 в игре? \nВведите: 'y' или 'n'");
            start = Console.ReadLine();
            if (start == "y")
            {
                isTwelve = true;
            }
            else if (start == "n")
            {
                isTwelve = false;
            }

            Sleep();
            // Выбор режима игры
            Console.WriteLine($"Выбирите режим игры: 1. Компьютер 2. Другой игрок \nВведите: '1' или '2'");
                start = Console.ReadLine();
                if (start == "1")
                {
                    ModeAI();
                }
                else if (start == "2")
                {
                    ModePVP();
                }
            
        }         // Выбор режима игры

        static void RandomNumber()
        {
            gameNumber = randNum.Next(12, 121);                                          // Генерируем число от 12 до 120
            Console.WriteLine($"Игра началась! Стартовое число: {gameNumber}\n");        // Вывод полученнного числа
            Sleep();
            if (isTwelve == true) Console.WriteLine("Используйте числа: 1, 2, 3, 4, + (12)\n");
            else Console.WriteLine("Используйте числа: 1, 2, 3, 4\n");
            }     // Генерация случайного числа

        static void ModeAI()
        {
            Console.WriteLine($"Введите ваше имя:");
            user1 = Convert.ToString(Console.ReadLine());
            Sleep();
            Console.WriteLine($"Игрок {user1} готов к игре!\n");

            RandomNumber();                                                                 // Генерация случайного числа

            // Определение первого хода
            if (gameNumber >= 61)
            {
                turnUser = 3;
                TurnPlayer();
            }
            else
            {
                turnUser = 4;
                TurnSkynet();
            }
            }           // Режим игры AI (автоматический интелект)

        static void ModePVP()
        {
            Console.WriteLine($"Введите имя первого игрока:");
            user1 = Convert.ToString(Console.ReadLine());
            Sleep();
            Console.WriteLine($"Игрок {user1} готов к игре!\n");

            Console.WriteLine($"Введите имя второго игрока:");
            user2 = Convert.ToString(Console.ReadLine());
            Sleep();
            Console.WriteLine($"Игрок {user2} готов к игре!\n");

            RandomNumber();                                                             // Генерация случайного числа

            // Определение первого хода
            if (gameNumber >= 61)
            {
                turnUser = 1;
                TurnUser1();
            }
            else
            {
                turnUser = 2;
                TurnUser2();
            }
        }          // Режим игры PVP

        static void Sleep()
        {
            Thread.Sleep(1000);
        }            // Задержка на 1 секунду

        static void TurnUser1()            // Ход первого игрока в PVP режиме
        {
            if (turnUser == 1 && gameNumber >= 0)
            {
                Console.WriteLine($"Текущее число {gameNumber} >>> Ходит {user1} \nВведите число:");
                userTry = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------------------------------\n");
                Sleep();
                CountNumber();
                // Передача хода
                turnUser = 2;
                TurnUser2();
                Sleep();
            }
        }
        static void TurnUser2()            // Ход второго игрока в PVP режиме
        {
            if (turnUser == 2 && gameNumber >= 0)
            {
                Console.WriteLine($"Текущее число {gameNumber} >>> Ходит {user2} \nВведите число:");
                userTry = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------------------------------\n");
                Sleep();
                CountNumber();
                // Передача хода
                turnUser = 1;
                TurnUser1();
                Sleep();
            } 
                
        }

        static void TurnPlayer()           // Ход компа в AI режиме
        {
            if (turnUser == 3 && gameNumber >= 0)
            {
                Console.WriteLine($"Текущее число {gameNumber} >>> Ходит {user1} \nВведите число:");
                userTry = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------------------------------\n");
                Sleep();
                CountNumberAI();
                // Передача хода
                turnUser = 4;     
                TurnSkynet();
            }
        }
        static void TurnSkynet()           // Ход игрока в AI режиме
        {
            if (turnUser == 4 && gameNumber >= 0)
            {
                // Если нет выигрышной комбинации, то берется случайное число от 1 до 4
                Console.WriteLine($"Текущее число {gameNumber} >>> Ходит {comp}:");
                switch (gameNumber)
                {
                    case 1:
                        userTry = 1;
                        break;
                    case 2:
                        userTry = 2;
                        break;
                    case 3:
                        userTry = 3;
                        break;
                    case 4:
                        userTry = 4;
                        break;
                    case 12:
                        if (isTwelve == true && gameNumber >= 12)
                        {
                            userTry = 12;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    default:
                        if (isTwelve == false)
                        { 
                            userTry = randNum.Next(1, 5);
                        }
                        else if (isTwelve == true)
                        {
                            switch (randNum.Next(1, 6)) // Дополнительное условие для числа 12
                            {
                                case 1:
                                    userTry = 1;
                                    break;
                                case 2:
                                    userTry = 2;
                                    break;
                                case 3:
                                    userTry = 3;
                                    break;
                                case 4:
                                    userTry = 4;
                                    break;
                                case 5:     // если выпадает 5-ка, то комп вводит число 12 
                                    userTry = 12;
                                    break;
                                }
                        }
                        break;
                }
                Sleep();
                Console.WriteLine($"Ввёл: {userTry}\n");
                Console.WriteLine("-------------------------------------\n");
                Sleep();
                CountNumberAI();
                // Передача хода
                turnUser = 3;      
                TurnPlayer();
                Sleep();
            }
        }

        static void CountNumber()
        {
            if (userTry <= 4 && userTry >= 1)   // Проверка введёного числа
            {
                gameNumber -= userTry;
                if (turnUser == 1)
                {
                    EndGame();
                    turnUser = 2;
                    TurnUser2();
                }
                else if (turnUser == 2)
                {
                    EndGame();
                    turnUser = 1;
                    TurnUser1();
                }
                
            }
            else if (isTwelve == false && (userTry > 4 || userTry < 1))
            {
                Console.WriteLine("Используйте числа 1, 2, 3 или 4");
                if (turnUser == 1) TurnUser1();
                else if (turnUser == 2) TurnUser2();
            }
            else if (isTwelve == true && (userTry > 4 || userTry < 1 || userTry != 12))
            {
                Console.WriteLine("Используйте числа 1, 2, 3, 4 или 12");
                if (turnUser == 1) TurnUser1();
                else if (turnUser == 2) TurnUser2();
            }
        }       // Подсчёт текущего числа в PVP режиме
        static void CountNumberAI()        // Подсчёт текущего числа в AI режиме
        {
            if (userTry <= 4 && userTry >= 1 || (isTwelve == true && userTry == 12))   // Проверка введёного числа
            {
                gameNumber -= userTry;
                if (turnUser == 3)
                {
                    EndGame();
                    turnUser = 4;
                    TurnSkynet();
                }
                else if (turnUser == 4)
                {
                    EndGame();
                    turnUser = 3;
                    TurnPlayer();
                }

            }
            else if (isTwelve == false && (userTry > 4 || userTry < 1))
            {
                Console.WriteLine("Используйте числа 1, 2, 3 или 4");
                if (turnUser == 3) TurnPlayer();
                else if (turnUser == 4) TurnSkynet();
            }
            else if (isTwelve == true && (userTry > 4 || userTry < 1 || userTry != 12))
            {
                Console.WriteLine("Используйте числа 1, 2, 3, 4 или 12");
                if (turnUser == 3) TurnPlayer();
                else if (turnUser == 4) TurnSkynet();
            }
        }

        static void EndGame()                // Проверка на выигрыш
        {
            string end = null;
            if (gameNumber == 0 && turnUser == 1)
            {
                Console.WriteLine($"Игра окончена! >>> Победил {user1}! <<<\n Сыграть ещё раз? (y / n)");
                end = Console.ReadLine();
                if (end == "n")
                {
                    Sleep();
                    Environment.Exit(0);
                }
                else if (end == "y")
                {
                    Sleep();
                    RestartGame();
                }
            
            }
            else if (gameNumber == 0 && turnUser == 2)
            {
                Console.WriteLine($"Игра окончена! >>> Победил {user2}! <<<\n Сыграть ещё раз? (y / n)");
                end = Console.ReadLine();
                if (end == "n")
                {
                    Sleep();
                    Environment.Exit(0);
                }
                else if (end == "y")
                {
                    Sleep();
                    RestartGame();
                }
            }
            else if (gameNumber == 0 && turnUser == 3)
            {
                Console.WriteLine($"Игра окончена! >>> Победил {user1}! <<<\n Сыграть ещё раз? (y / n)");
                end = Console.ReadLine();
                if (end == "n")
                {
                    Sleep();
                    Environment.Exit(0);
                }
                else if (end == "y")
                {
                    Sleep();
                    RestartGame();
                }
            }
            else if (gameNumber == 0 && turnUser == 4)
            {
                Console.WriteLine($"Игра окончена! >>> Победил {comp}! <<<\n Сыграть ещё раз? (y / n)");
                end = Console.ReadLine();
                if (end == "n")
                {
                    Sleep();
                    Environment.Exit(0);
                }
                else if (end == "y")
                {
                    Sleep();
                    RestartGame();
                }
            }
            else if (gameNumber < 0)
            {
                Console.WriteLine($"Игра окончена! Нет победителя!\n Сыграть ещё раз? (y / n)");
                end = Console.ReadLine();
                if (end == "n")
                {
                    Sleep();
                    Environment.Exit(0);
                }
                else if (end == "y")
                {
                    Sleep();
                    RestartGame();
                }
            }
        }
        static void RestartGame()
        {
            // Сброс переменных по умолчанию
            Console.Clear();
            userTry = 0;
            user1 = null;
            user2 = null;
            gameNumber = 0;
            isTwelve = false;

            GameMode();
            Console.ReadKey();    
        }         // Перезапуск игры
    }
}
