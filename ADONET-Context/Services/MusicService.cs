using ADONET_Context.Abstractions;
using ADONET_Context.Helper;
using ADONET_Context.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADONET_Context.Services
{
    internal class MusicService : IService<Music>
    {
        public void Create(Music model)
        {
            Sql.ExecCommand($"INSERT INTO Musics Values(N'{model.Name}','{model.Id}','{model.Duration}')");
        }

        public void Delete(int id)
        {
            Sql.ExecCommand($"DELETE Musics WHERE ID = {id}");
        }

        public List<Music> GetAll()
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Musics");
            List<Music> musics = new List<Music>();
            foreach (DataRow dr in dt.Rows)
            {
                musics.Add(new Music { Id = Convert.ToInt32(dr["id"]), Name = dr["Name"].ToString(), Duration = Convert.ToInt32(dr["duration"]) });
            }
            return musics;
        }

        public Music GetByID(int id)
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Musics");
            DataRow dr = dt.Rows[0];
            Music musics = new Music()
            {
                Id = Convert.ToInt32(dr["id"]),
                Name = dr["Name"].ToString(),
                Duration = Convert.ToInt32(dr["duration"])
            };
            return musics;
        }

        public void Update(Music model)
        {
            Sql.ExecCommand($"UPDATE Music SET Name {model.Name} WHERE id {model.Id}");
        }
    }
}
