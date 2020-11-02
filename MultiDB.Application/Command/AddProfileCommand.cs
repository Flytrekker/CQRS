using MediatR;
using MultiDB.Database;
using MultiDB.MSSQLDatabase;
using MultiDB.MySQLDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiDB.Application.Command
{
    public class AddProfileCommand: IRequest<Dictionary<string, string>>
    {
        public string Name { get; set; }
    }
    public class AddProfileHandler : IRequestHandler<AddProfileCommand, Dictionary<string, string>>
    {
        private List<IApplicationDBContext> applicationDBContexts;
        public AddProfileHandler(IMSSQLApplicationDBContext mssql, IMySQLApplicationDBContext mysql)
        {
            applicationDBContexts = new List<IApplicationDBContext>
            {
                mysql,
                mssql
            };
        }
        public async Task<Dictionary<string, string>> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, string>();
            Parallel.ForEach(applicationDBContexts, (db) =>
            {
                var profile = db.Profiles.Add(new DatabaseModels.Profile { Name = request.Name }).Entity;
                db.SaveChanges();
                result.Add($"{db.GetType().Name} Id: { profile.Id}", profile.Name);
            });
            return result;
        }
    }
}
