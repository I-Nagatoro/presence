using Demo.domain.Models;
using Demo.Domain.UseCase;
using System;

namespace Demo.UI
{
    public class MainMenuUI
    {
        private readonly UserConsoleUI _userConsoleUI;
        private readonly GroupConsoleUI _groupConsoleUI;
        private readonly PresenceConsole _presenceConsoleUI;

        public MainMenuUI(UserUseCase userUseCase, GroupUseCase groupUseCase, UseCaseGeneratePresence presenceUseCase)
        {
            _userConsoleUI = new UserConsoleUI(userUseCase);
            _groupConsoleUI = new GroupConsoleUI(groupUseCase);
            _presenceConsoleUI = new PresenceConsole(presenceUseCase);
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=-= Главное меню =-=\n");

                Console.WriteLine("=-= Команды с Пользователями =-=");
                Console.WriteLine("1. Вывести всех пользователей");
                Console.WriteLine("2. Удалить пользователя по id");
                Console.WriteLine("3. Обновить пользователя по id");
                Console.WriteLine("4. Найти пользователя по id");
                Console.WriteLine();

                Console.WriteLine("=-= Команды с Группами =-=");
                Console.WriteLine("5. Вывести все группы");
                Console.WriteLine("6. Добавить группу");
                Console.WriteLine("7. Удалить группу");
                Console.WriteLine("8. Изменить название группы");
                Console.WriteLine("9. Поиск группы по ID");
                Console.WriteLine();
                Console.WriteLine("=-= Команды Presence =-=");
                Console.WriteLine("10. Сгенерировать посещаемость на день");
                Console.WriteLine("11. Сгенерировать посещаемость на неделю");
                Console.WriteLine("12. Показать посещаемость");
                Console.WriteLine("13. Отметить пользователя как отсутствующего");
                Console.WriteLine();
                Console.WriteLine("0. Выход");

                Console.Write("\nВаш выбор: ");
                string comand = Console.ReadLine();
                Console.WriteLine();

                switch (comand)
                {
                    case "1":
                        // Отображение всех пользователей
                        _userConsoleUI.DisplayAllUsers();
                        break;

                    case "2":
                        // Удаление пользователя по ID
                        Console.Write("Введите ID пользователя для удаления: ");
                        string inputId = Console.ReadLine();
                        if (int.TryParse(inputId, out int userId))
                        {
                            _userConsoleUI.RemoveUserById(userId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID");
                        }
                        break;

                    case "3":
                        // Обновление пользователя по ID
                        Console.Write("Введите ID пользователя для обновления: ");
                        string updateIdInput = Console.ReadLine();
                        if (int.TryParse(updateIdInput, out int updateUserId))
                        {
                            _userConsoleUI.UpdateUserById(updateUserId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID");
                        }
                        break;

                    case "4":
                        // Поиск пользователя по ID
                        Console.Write("Введите ID пользователя для поиска: ");
                        string findIdInput = Console.ReadLine();
                        if (int.TryParse(findIdInput, out int findUserId))
                        {
                            _userConsoleUI.FindUserById(findUserId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID");
                        }
                        break;

                    case "5":
                        // Отображение всех групп
                        _groupConsoleUI.DisplayAllGroups();
                        break;

                    case "6":
                        // Добавление новой группы
                        Console.Write("Введите название новой группы: ");
                        string newGroupName = Console.ReadLine();
                        _groupConsoleUI.AddGroup(newGroupName);
                        break;

                    case "7":
                        // Удаление группы
                        Console.Write("Введите ID группы  для удаления: ");
                        string groupIdForDelete = Console.ReadLine();
                        _groupConsoleUI.RemoveGroup(groupIdForDelete);
                        break;

                    case "8":
                        // Изменение названия группы
                        Console.Write("Введите ID группы для изменения: ");
                        if (int.TryParse(Console.ReadLine(), out int groupId))
                        {
                            Console.Write("Введите новое название группы: ");
                            string newName = Console.ReadLine();
                            _groupConsoleUI.UpdateGroupName(groupId, newName);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID группы");
                        }
                        break;

                    case "9":
                        // Поиск группы
                        Console.Write("Введите ID группы для поиска : ");
                        if (int.TryParse(Console.ReadLine(), out int IdGroup))
                        {
                            _groupConsoleUI.FindGroupById(IdGroup);
                        }
                        break;

                    case "10":
                        // Генерация посещаемости на день
                        Console.Write("Введите номер первого занятия: ");
                        int firstLesson = int.Parse(Console.ReadLine());
                        Console.Write("Введите номер последнего занятия: ");
                        int lastLesson = int.Parse(Console.ReadLine());
                        Console.Write("Введите ID группы: ");
                        int groupIdForPresence = int.Parse(Console.ReadLine());

                        _presenceConsoleUI.GeneratePresenceForDay(DateTime.Now, groupIdForPresence, firstLesson, lastLesson);
                        Console.WriteLine("Посещаемость на день сгенерирована.");
                        break;

                    case "11":
                        // Генерация посещаемости на неделю
                        Console.Write("Введите номер первого занятия: ");
                        int firstLessonForWeek = int.Parse(Console.ReadLine());
                        Console.Write("Введите номер последнего занятия: ");
                        int lastLessonForWeek = int.Parse(Console.ReadLine());
                        Console.Write("Введите ID группы: ");
                        int groupIdForWeekPresence = int.Parse(Console.ReadLine());

                        _presenceConsoleUI.GeneratePresenceForWeek(DateTime.Now, groupIdForWeekPresence, firstLessonForWeek, lastLessonForWeek);
                        Console.WriteLine("Посещаемость на неделю сгенерирована.");
                        break;

                    case "12":
                        // Отображение посещаемости
                        Console.Write("Введите дату (гггг-мм-дд): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Введите ID группы: ");
                        int groupForPresenceView = int.Parse(Console.ReadLine());

                        _presenceConsoleUI.DisplayPresence(date, groupForPresenceView);
                        break;

                    case "13":
                        // Отметить пользователя как отсутствующего
                        Console.Write("Введите ID пользователя: ");
                        userId = int.Parse(Console.ReadLine());
                        Console.Write("Введите номер первого занятия: ");
                        int firstAbsLesson = int.Parse(Console.ReadLine());
                        Console.Write("Введите номер последнего занятия: ");
                        int lastAbsLesson = int.Parse(Console.ReadLine());
                        Console.Write("Введите ID группы: ");
                        int absGroupId = int.Parse(Console.ReadLine());

                        _presenceConsoleUI.MarkUserAbsent(DateTime.Now, absGroupId, userId, firstAbsLesson, lastAbsLesson);
                        Console.WriteLine("Пользователь отмечен как отсутствующий.");
                        break;

                    case "0":
                        Console.WriteLine("Выход...");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}