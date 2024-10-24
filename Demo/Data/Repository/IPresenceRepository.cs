
using Demo.domain.Models;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public interface IPresenceRepository
    {

        List<PresenceLocalEntity> GetPresenceByDateAndGroup(DateTime date, int groupId);
        void SavePresence(List<PresenceLocalEntity> presences);
    }
}
