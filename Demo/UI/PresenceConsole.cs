using Demo.domain.Models;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;

namespace Demo.UI
{
    public class PresenceConsole
    {
        private readonly UseCaseGeneratePresence _presenceUseCase;

        public PresenceConsole(UseCaseGeneratePresence presenceUseCase)
        {
            _presenceUseCase = presenceUseCase;
        }

        // Метод для генерации посещаемости на день
        public void GeneratePresenceForDay(DateTime date, int groupId, int firstLesson, int lastLesson)
        {
            try
            {
                _presenceUseCase.GeneratePresenceDaily(firstLesson, lastLesson, groupId,date);
                Console.WriteLine("Посещаемость на день успешно сгенерирована.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации посещаемости: {ex.Message}");
            }
        }

        // Метод для генерации посещаемости на неделю
        public void GeneratePresenceForWeek(DateTime date, int groupId, int firstLesson, int lastLesson)
        {
            try
            {
                _presenceUseCase.GenerateWeeklyPresence(firstLesson, lastLesson, groupId, date);
                Console.WriteLine("Посещаемость на неделю успешно сгенерирована.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации посещаемости: {ex.Message}");
            }
        }

        // Метод для отображения посещаемости на конкретную дату и группу
        public void DisplayPresence(DateTime date, int groupId)
        {
            try
            {
                List<PresenceLocalEntity> presences = _presenceUseCase.GetPresenceByDateAndGroup(date, groupId);

                if (presences == null || presences.Count == 0)
                {
                    Console.WriteLine("Посещаемость на выбранную дату отсутствует.");
                    return;
                }

                Console.WriteLine($"\nПосещаемость на {date.ToShortDateString()} для группы с ID {groupId}:");
                Console.WriteLine("---------------------------------------------");
                int a = presences[0].LessonNumber;
                foreach (var presence in presences)
                {
                    if (a != presence.LessonNumber)
                    {
                        Console.WriteLine("---------------------------------------------");
                        a=presence.LessonNumber;
                    }
                    string status = presence.IsAttedance ? "Присутствует" : "Отсутствует";
                    Console.WriteLine($"Пользователь ID: {presence.UserId}, Занятие {presence.LessonNumber}: {status}");
                }
                Console.WriteLine("---------------------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выводе посещаемости: {ex.Message}");
            }
        }

        public void MarkUserAbsent(DateTime date, int groupId, int userId, int firstLesson, int lastLesson)
        {
            _presenceUseCase.MarkUserAbsentForLessons(userId, groupId, firstLesson, lastLesson, date);
        }

    }
}
