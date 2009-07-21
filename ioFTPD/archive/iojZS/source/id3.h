#define MAXGENRE   147
char *typegenre [MAXGENRE+2] = {
   "Blues","Classic Rock","Country","Dance","Disco","Funk","Grunge",
   "Hip-Hop","Jazz","Metal","New Age","Oldies","Other","Pop","R&B",
   "Rap","Reggae","Rock","Techno","Industrial","Alternative","Ska",
   "Death Metal","Pranks","Soundtrack","Euro-Techno","Ambient",
   "Trip-Hop","Vocal","Jazz+Funk","Fusion","Trance","Classical",
   "Instrumental","Acid","House","Game","Sound Clip","Gospel","Noise",
   "Alt. Rock","Bass","Soul","Punk","Space","Meditative",
   "Instrumental Pop","Instrumental Rock","Ethnic","Gothic",
   "Darkwave","Techno-Industrial","Electronic","Pop-Folk","Eurodance",
   "Dream","Southern Rock","Comedy","Cult","Gangsta Rap","Top 40",
   "Christian Rap","Pop/Funk","Jungle","Native American","Cabaret",
   "New Wave","Psychedelic","Rave","Showtunes","Trailer","Lo-Fi",
   "Tribal","Acid Punk","Acid Jazz","Polka","Retro","Musical",
   "Rock & Roll","Hard Rock","Folk","Folk/Rock","National Folk",
   "Swing","Fast-Fusion","Bebob","Latin","Revival","Celtic",
   "Bluegrass","Avantgarde","Gothic Rock","Progressive Rock",
   "Psychedelic Rock","Symphonic Rock","Slow Rock","Big Band",
   "Chorus","Easy Listening","Acoustic","Humour","Speech","Chanson",
   "Opera","Chamber Music","Sonata","Symphony","Booty Bass","Primus",
   "Porn Groove","Satire","Slow Jam","Club","Tango","Samba",
   "Folklore","Ballad","Power Ballad","Rhythmic Soul","Freestyle",
   "Duet","Punk Rock","Drum Solo","A Cappella","Euro-House",
   "Dance Hall","Goa","Drum & Bass","Club-House","Hardcore","Terror",
   "Indie","BritPop","Negerpunk","Polsk Punk","Beat",
   "Christian Gangsta Rap","Heavy Metal","Black Metal","Crossover",
   "Contemporary Christian","Christian Rock","Merengue","Salsa",
   "Thrash Metal","Anime","JPop","Synthpop",""
};

void text_genre(unsigned char *genre,char *buffer)
{
  int genre_num = (int) genre[0];
  
  if(genre_num <= MAXGENRE) {
    sprintf(buffer,"%s",typegenre[genre_num]);
  } else if(genre_num < 255) {
    sprintf(buffer,"(UNKNOWN) [%d]",genre_num);
  } else {
    buffer[0]='\0';
  }
}

void get_id3 ( char *f )
{
  HANDLE 		file = CreateFile(f, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_FLAG_RANDOM_ACCESS, NULL);;
  DWORD			dwError, temp;
  int 			dwPtr;
  char			fbuf[4];
  
  sprintf(var.mp3.artist,"N/A");
  sprintf(var.mp3.album,"N/A");
  sprintf(var.mp3.title,"N/A");
  sprintf(var.mp3.year,"N/A");
  sprintf(var.mp3.comment,"N/A");
  sprintf(var.mp3.genre,"N/A");
  var.mp3.track		= 0;
  var.mp3.genre_num[0]	= 255;
  
  dwPtr			= SetFilePointer(file, -128, NULL, FILE_END);
  if (dwPtr == INVALID_SET_FILE_POINTER)
  {
    error (" -[ get_id3 -> %s\n -[ dwPtr == INVALID_SET_FILE_POINTER\n",file);
  }
  else
  {
    if ((ReadFile(file, &fbuf, 3, &temp, NULL)) != 0)
    {
      fbuf[3] = '\0';
      
      if (!strcmp((const char *)"TAG",(const char *)fbuf))
      {
        SetFilePointer(file, -125, NULL, FILE_END);
        ReadFile(file, var.mp3.title, 30, &temp, NULL); var.mp3.title[30] = '\0';
        ReadFile(file, var.mp3.artist, 30, &temp, NULL); var.mp3.artist[30] = '\0';
        ReadFile(file, var.mp3.album, 30, &temp, NULL); var.mp3.album[30] = '\0';
        ReadFile(file, var.mp3.year, 4, &temp, NULL); var.mp3.year[4] = '\0';
        ReadFile(file, var.mp3.comment, 30, &temp, NULL); var.mp3.comment[30] = '\0';
        if (var.mp3.comment[28] == '\0') {
          var.mp3.track = (int)var.mp3.comment[29];
        }
        ReadFile(file, var.mp3.genre_num,1, &temp, NULL); var.mp3.genre_num[1] = '\0';
        text_genre(var.mp3.genre_num,var.mp3.genre);
      }
      else
      {
        //error (" -[ get_id3 -> %s\n -[ id3 TAG not found\n",file);
      }
    }
    else
    {
      error (" -[ get_id3 -> %s\n -[ ERROR %u\n -[ Couldn't read file\n",file, GetLastError());
    }
  }  
  
}