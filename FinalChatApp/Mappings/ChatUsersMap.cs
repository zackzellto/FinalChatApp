    using FluentNHibernate.Mapping;
using ReactChatApp.Models;
using System; 
using System.Collections.Generic; 
using System.Linq; using System.Text; 
using System.Threading.Tasks;

namespace ReactChatApp.Mappings
{
    class ChatUsersMap : ClassMap<ChatUsers>
    {
        public ChatUsersMap()
        {
            Id(x => x.id);
            Map(x => x.first_name);
            Map(x => x.last_name);
            Table("users");
        }
    }
}