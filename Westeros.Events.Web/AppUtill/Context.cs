using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Service
{
    public class Context
    {
 
        public IGenericRepository<LogRecord> log_repository { get; private set; }
        public IGenericRepository<Profile> profile_repository { get; private set; }
        public IGenericRepository<Message> message_repository { get; private set; }

        public Context(IGenericRepository<LogRecord> l_ctx, IGenericRepository<Profile> p_ctx, IGenericRepository<Message> m_ctx)
        {
            log_repository = l_ctx;
            profile_repository = p_ctx;
            message_repository = m_ctx;
        }
 

    }
}
