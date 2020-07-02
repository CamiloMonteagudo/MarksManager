using System.Collections.Generic;
using System.IO;

namespace MarksManager
  {
  public static class LangUtils
    {
    static Dictionary<string, int> lngIdx = new Dictionary<string, int>() { { "Es", 0 }, { "En", 1 }, { "It", 2 }, { "Fr", 3 } };

    /// <summary>Obtiene los idiomas fuente y destino a partir del nombre del fichero</summary>
    public static bool CodeLangsFromPath( string path, out int src, out int des )
      {
      src = -1;
      des = -1;

      string abrvSrc, abrvDes;
      if( !AbrevLangsFromPath(path, out abrvSrc, out abrvDes) )
        return false;

      if( !lngIdx.TryGetValue( abrvSrc, out src ) ) return false;
      if( !lngIdx.TryGetValue( abrvDes, out des ) ) return false;

      return true;
      }

    /// <summary>Obtiene los lenguajes del diccionario de acuerdo a su nombre</summary>       
    public static bool AbrevLangsFromPath( string path, out string src, out string des  )
      {
      src = "";
      des = "";

      var name = Path.GetFileNameWithoutExtension(path);
      var idxFind = name.IndexOf('2');
      if( idxFind < 2 || idxFind + 2 >= name.Length ) return false;

      src = name.Substring(idxFind - 2, 2);
      des = name.Substring(idxFind + 1, 2);

      return true;
      }

    }
  }
