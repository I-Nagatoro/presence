using Demo.Domain.UseCase;
using System;
using System.Text;

namespace Demo.UI
{
    public class UserConsoleUI
    {
        private readonly UserUseCase _userUseCase;

        public UserConsoleUI(UserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        // Метод для отображения всех пользователей
        public void DisplayAllUsers()
        {
            Console.WriteLine("\n=== Список всех пользователей ===");
            StringBuilder userOutput = new StringBuilder();

            foreach (var user in _userUseCase.GetAllUsers())
            {
                userOutput.AppendLine($"{user.ID}\t{user.Guid}\t{user.FIO}\t{user.Group.Name}");
            }

            Console.WriteLine(userOutput);
            Console.WriteLine("===============================\n");
        }

        // Метод для удаления пользователя по ID
        public void RemoveUserById(int userId)
        {
            string output = _userUseCase.RemoveUserById(userId) ? "Пользователь удален" : "Пользователь не найден";
            Console.WriteLine($"\n{output}\n");
        }

        // Метод для обновления пользователя по ID
        public void UpdateUserById(int userId)
        {
            try
            {
                var user = _userUseCase.FindUserById(userId);

                Console.WriteLine($"Текущие данные: {user.FIO}, {user.Group.Name}");
                Console.Write("\nВведите новое ФИО: ");
                string newFIO = Console.ReadLine();

                user.FIO = newFIO;
                _userUseCase.UpdateUser(user);

                Console.WriteLine("\nПользователь обновлен.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
        }

        // Метод для поиска пользователя по ID
        public void FindUserById(int userId)
        {
            var user = _userUseCase.FindUserById(userId);
            if (user != null)
            {
                Console.WriteLine($"\nПользователь найден: {user.Guid}, {user.FIO}, {user.Group.Name}\n");
            }
            else
            {
                Console.WriteLine("\nПользователь не найден.\n");
            }
        }
    }
}
