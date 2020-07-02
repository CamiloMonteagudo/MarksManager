using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tests
  {
  /// <summary>Maneja todas las marcas utilizadas en los diccionarios</summary>
  public class MarksMng
    {
    /// <summary>Diccionario para obtener la información con el código de la marca</summary>
    public Dictionary<string/*code*/, MarkInfo> Marks = new Dictionary<string, MarkInfo>();

    /// <summary>Diccionario para obtener el código de la marca, con la cadena de sustitución en Español</summary>
    public Dictionary<string, string/*code*/> EsSust = new Dictionary<string, string>();

    /// <summary>Diccionario para obtener el código de la marca, con la cadena de sustitución en Inglés</summary>
    public Dictionary<string, string/*code*/> EnSust = new Dictionary<string, string>();

    /// <summary>Diccionario para obtener el código de la marca, con la cadena de sustitución en Italiano</summary>
    public Dictionary<string, string/*code*/> ItSust = new Dictionary<string, string>();

    /// <summary>Diccionario para obtener el código de la marca, con la cadena de sustitución en Francés</summary>
    public Dictionary<string, string/*code*/> FrSust = new Dictionary<string, string>();

    /// <summary>Ultima información sobre las marcas utilizada en el programa</summary>
    public static MarksMng Current = null;

    /// <summary>Carga la información de las marcas desde un fichero</summary>
    public static int Load( string fileName )
      {
      int nErr = 0;
      var lines = File.ReadAllLines(fileName);

      var lstMarks = new MarksMng();
      for( int i = 0; i < lines.Length; ++i )
        {
        var ln = lines[i].Trim();
        if( ln.Length == 0 ) continue;
        if( ln[0] == '/' ) continue;

        var data = ln.Split('|');
        if( data.Length != 6 )
          {
          MessageBox.Show( "ERROR: (" + i + ") La cantidad de datos es incorrecta" );
          ++nErr;
          continue;
          }

        var code = data[0].Trim();
        if( lstMarks.Marks.ContainsKey( code ) )
          {
          MessageBox.Show( "ERROR: (" + i + ") Ya hay una marca con ese código" );
          ++nErr;
          continue;
          }

        lstMarks.AddMark( code, data );
        }

      Current = lstMarks;
      return nErr;
      }

    public bool AddMark( string code, MarkInfo info )
      {
      if( Marks.ContainsKey( code ) )
        {
        MessageBox.Show( "ERROR: Ya hay una marca con ese código" );
        return false;
        }
      if( Contains( info.Es, EsSust ) || Contains( info.En, EnSust ) || Contains( info.It, ItSust ) || Contains( info.Fr, FrSust ) )
        return false;

      Marks.Add( code, info );
      EsSust[info.Es] = code;
      EnSust[info.En] = code;
      ItSust[info.It] = code;
      FrSust[info.Fr] = code;
      return true;
      }

    /// <summary>Adiciona una marca con el código y toda la información</summary>
    private void AddMark( string code, string[] data )
      {
      var info = new MarkInfo(data);

      Marks[code] = info;

      AddSustMark( info.Es, EsSust, code );
      AddSustMark( info.En, EnSust, code );
      AddSustMark( info.It, ItSust, code );
      AddSustMark( info.Fr, FrSust, code );
      }

    /// <summary>Adiciona una marca para un idioma especifico</summary>
    private bool AddSustMark( string sLng, Dictionary<string, string> lngSust, string code )
      {
      if( Contains( sLng, lngSust ) )
        return false;

      lngSust[sLng] = code;
      return true;
      }

    private bool Contains( string sLng, Dictionary<string, string> lngSust )
      {
      if( lngSust.ContainsKey( sLng ) )
        {
        MessageBox.Show( "ERROR: La marca '" + sLng + "' está repetida" );
        return true;
        }
      return false;
      }

    /// <summary>Determina si existe una marca con el codigo dado</summary>
    public bool Exist( string code )
      {
      return Marks.ContainsKey( code );
      }

    /// <summary>Obtiene informacion asociada a la marca con el codigo dado</summary>
    public MarkInfo Info( string code )
      {
      return Marks[code];
      }

    public static bool ContainsMark( string line )
      {
      return reMark.IsMatch( line );
      }

    public static Regex reMark = new Regex(@"((?<m><)|\[)([A-Z][A-Z][a-z]?[1-9])?(?(m)>|\])", RegexOptions.Compiled);

    private string lastMark = "";

    /// <summary>Sustituye las marcas por palabras en el idioma de la cadena</summary>
    public int ResplaceMarks( ref string sKey, ref string sDat, int src, int des, out Dictionary<string, string> marks )
      {
      var keyMarks = new HashSet<string>();                             // Marcas que hay en la llave
      marks = new Dictionary<string, string>();

      var matches = reMark.Matches(sKey);                               // Busca todas las marcas en la llave
      foreach( Match match in matches )                                  // Recorre todas las marcas encontradas
        {
        lastMark = match.Groups[2].Value;                              // Obtiene el codigo de la marca

        if( !Marks.ContainsKey( lastMark ) ) return 1;                    // ERROR: La marca no esta registrada
        if( keyMarks.Contains( lastMark ) ) return 2;                     // ERROR: La marca aparece duplicada

        keyMarks.Add( lastMark );                                        // Adiciona la marca al conjunto
        }

      sKey = ResplaceMarks( sKey, src, matches, marks );                  // Sustituye todas las marcas, por la palabra correspondiente

      var s = new StringBuilder(sDat.Length + keyMarks.Count * 15);     // Cadena para guardar los datos con las marcas sustituidas

      var types = sDat.Split('|');                                      // Separa los distintos tipos gramaticales de la entrada
      for( int i = 0; i < types.Length; ++i )                            // Recorre todos los tipos gramaticales
        {
        if( i > 0 ) s.Append( '|' );                                      // Si no es primer tipo, pone separador

        var Means = types[i].Split(';');                               // Separa los distintos significados del tipo
        for( int j = 0; j < Means.Length; ++j )                         // Recorre todos los significados
          {
          matches = reMark.Matches( Means[j] );                         // Busca todas las marcas en el significado
          if( matches.Count != keyMarks.Count ) return 5;              // ERROR: Un significado no tiene la misma cantidad de marcas

          var meanMarks = new HashSet<string>();                      // Marcas que hay en el significado
          foreach( Match match in matches )                            // Recorre todas las marcas del significado
            {
            lastMark = match.Groups[2].Value;                        // Obtiene el codigo de la marca

            if( !keyMarks.Contains( lastMark ) ) return 3;              // ERROR: La marca no aparece en la llave
            if( meanMarks.Contains( lastMark ) ) return 4;              // ERROR: La marca aparece duplicada en el significado

            meanMarks.Add( lastMark );                                 // Adiciona la marca al conjunto
            }

          if( j > 0 ) s.Append( ';' );                                   // Si no es primer significado, pone separador

          string mean = ResplaceMarks(Means[j], des, matches, marks);
          s.Append( mean );            // Adiciona el significado con las marcas sustituidas
          }
        }

      sDat = s.ToString();                                              // Restaura la cadena de los datos
      return 0;                                                         // Retorna 'No error'
      }

    ///-----------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Sustituye las marcas localizadas con 'matches' en la cadenada 'str' según el idioma 'str'</summary>
    private string ResplaceMarks( string str, int lng, MatchCollection matches, Dictionary<string, string> keyMark )
      {
      var s = new StringBuilder(str);                      // Convierte a StringBuilder (para eficiencia)

      for( int i = matches.Count - 1; i >= 0; i-- )         // Sustituyes las marcas, desde atras hacia adelante                         
        {
        Match m = matches[i];                             // Obtiene los datos de la marca encontrada

        var mark = m.Groups[2].Value;                     // Obtiene el código de la marca
        var info = Marks[mark];                           // Obtiene la informacion de la marca
        var sMark = info.ForLang(lng);                    // Obtiene cadena de sustitución de la marca en el idioma dado
        if( !keyMark.ContainsKey( m.Value ) )
          keyMark.Add( m.Value, sMark );

        s.Replace( m.Value, sMark, m.Index, m.Length );     // Sustituye la marca
        }

      return s.ToString();
      }

    /// <summary>Busca todas las marcas que existan en la cadena y las resplaza por su código</summary>
    public string RetoreMarks( string str, int lng )
      {
      var lst = GetMarksLng(lng);

      var s = new StringBuilder(str);

      foreach( var item in lst )
        s.Replace( item.Key, '['+item.Value+']' );

      return s.ToString();
      }

    public Dictionary<string, string> GetMarksLng( int lng )
      {
      switch( lng )
        {
        case 0: return EsSust;
        case 1: return EsSust;
        case 2: return EsSust;
        case 3: return EsSust;
        }

      return null;
      }

    ///-----------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Obtiene una cadena la la descripcion del ultimo error producido</summary>
    public string ErrorMsg( int code )
      {
      if( code == 0 ) return "No error";

      switch( code )
        {
        case 1: return "La marca [" + lastMark + "] no esta registrada";
        case 2: return "La marca [" + lastMark + "] aparece duplicada en la llave";
        case 3: return "La marca [" + lastMark + "] no aparece en la llave de la entrada";
        case 4: return "La marca [" + lastMark + "] aparece duplicada en un significado";
        case 5: return "Un significado no tiene la misma cantidad de marcas";
        }

      return "Error desconocido";
      }
    }

  //===================================================================================================================================
  /// <summary>Mantiene la información relacionada con una marca</summary>
  public class MarkInfo
    {
    public string Desc;                     // Descripción de la marca (siempre en el idioma español)

    public string Es;                       // Cadena para mostrar la marca cuando los datos son en Español
    public string En;                       // Cadena para mostrar la marca cuando los datos son en Inglés
    public string It;                       // Cadena para mostrar la marca cuando los datos son en Italiano
    public string Fr;                       // Cadena para mostrar la marca cuando los datos son en Francés

    /// <summary>Crea informacion de la marca con un arreglo de cadenas</summary>
    public MarkInfo( string[] data )
      {
      Desc = data[1].Trim();

      Es = data[2].Trim();
      En = data[3].Trim();
      It = data[4].Trim();
      Fr = data[5].Trim();
      }

    /// <summary>Obtiene la cadena de sustitución para un idioma dado</summary>
    public string ForLang( int lng )
      {
      switch( lng )
        {
        case 0: return Es;
        case 1: return En;
        case 2: return It;
        case 3: return Fr;
        }
      return "";
      }
    }
  }
