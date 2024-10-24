using Demo.Data.LocalData;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Data.Repository
{
    public class PresenceRepositoryImpl : IPresenceRepository
    {
        private List<PresenceLocalEntity> _presences;

        public PresenceRepositoryImpl()
        {
            _presences = LocalStaticData.presences;
        }

        // Метод для сохранения посещаемости
        public void SavePresence(List<PresenceLocalEntity> presences)
        {
            foreach (var presence in presences)
            {
                var existingPresence = _presences.FirstOrDefault(p =>
                    p.Date == presence.Date &&
                    p.UserId == presence.UserId &&
                    p.LessonNumber == presence.LessonNumber);

                if (existingPresence == null)
                {
                    _presences.Add(presence);
                }
                else
                {
                    // Обновление существующего значения посещаемости
                    existingPresence.IsAttedance = presence.IsAttedance;
                }
            }
        }

        // Метод для получения всех дат посещаемости по группе
        public List<DateTime> GetAllDatesByGroup(int groupId)
        {
            return _presences
                .Where(p => LocalStaticData.users.Any(u => u.GroupID == groupId && u.ID == p.UserId))
                .Select(p => p.Date.Date)
                .Distinct()
                .ToList();
        }

        // Метод для получения посещаемости по дате и группе
        public List<PresenceLocalEntity> GetPresenceByDateAndGroup(DateTime date, int groupId)
        {
            return _presences.Where(p => p.Date.Date == date.Date &&
                                         LocalStaticData.users.Any(u => u.GroupID == groupId && u.ID == p.UserId)).ToList();
        }
    }
}
