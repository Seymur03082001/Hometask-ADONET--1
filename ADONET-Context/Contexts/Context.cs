using ADONET_Context.Abstractions;
using ADONET_Context.Models;
using ADONET_Context.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Context.Contexts
{
    internal class Context
    {
        IService<Music> _musics;
        IService<Artist> _artist;

        
        public IService<Music> Music
        {
            get 
            {
                if(_musics == null)
                {
                    _musics = new MusicService();
                }
                return _musics;
            }

            
        }
        public IService<Artist> Artist
        {
            get
            {
                if(_artist == null)
                {
                    _artist = new ArtistService();
                }
                return _artist;
            }
        }

    }
}
