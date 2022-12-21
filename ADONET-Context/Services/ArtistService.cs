using ADONET_Context.Abstractions;
using ADONET_Context.Helper;
using ADONET_Context.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADONET_Context.Services
{
    internal class ArtistService : IService<Artist>
    {
        public void Create(Artist model)
        {
            Sql.ExecCommand($"INSERT INTO Artists Values(N'{model.Name}','{model.Id}','{model.Surname}','{model.Gender}')");
        }

        public void Delete(int id)
        {
            Sql.ExecCommand($"DELETE Artists WHERE ID = {id}");
        }

        public List<Artist> GetAll()
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Artists");
            List<Artist> artists = new List<Artist>();
            foreach (DataRow dr in dt.Rows)
            {
                artists.Add(new Artist { Id = Convert.ToInt32(dr["id"]), Name = dr["Name"].ToString(), Surname = dr["Surname"].ToString(), Gender = dr["Gender"].ToString() });
            }
            return artists;
        }

        public Artist GetByID(int id)
        {
            DataTable dt = Sql.ExecQuery("SELECT * FROM Musics");
            DataRow dr = dt.Rows[0];
            Artist artists = new Artist()
            {
                Id = Convert.ToInt32(dr["id"]),
                Name = dr["Name"].ToString(),
                Surname = dr["Surname"].ToString(),
                Gender = dr["Gender"].ToString()
            };
            return artists;
        }

        public void Update(Artist model)
        {
            Sql.ExecCommand($"UPDATE Artist SET Name {model.Name} WHERE id {model.Id}");
        }
    }
}
