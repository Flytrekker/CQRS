using MediatR;
using MultiDB.Database;
using MultiDB.MSSQLDatabase;
using MultiDB.MySQLDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiDB.Application.Queries
{
    public class GetProfilesQuery: IRequest<Dictionary<string, string>>
    {
    }
    public class GetProfilesHandler : IRequestHandler<GetProfilesQuery, Dictionary<string, string>>
    {
        private List<IApplicationDBContext> applicationDBContexts;

        public GetProfilesHandler(IMSSQLApplicationDBContext mssql, IMySQLApplicationDBContext mysql)
        {
            applicationDBContexts = new List<IApplicationDBContext>
            {
                mysql,
                mssql
            };
        }
        public async Task<Dictionary<string, string>> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, string>();
            Parallel.ForEach(applicationDBContexts, (db) =>
            {
                var profiles = db.Profiles.ToList();
                Parallel.ForEach(profiles, (profile) => { result.Add($"{db.GetType().Name} Id: { profile.Id}", profile.Name); });
            });
            return result;
        }
    }


}
