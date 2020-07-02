using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tests;

namespace MarksManager
  {
  //--------------------------------------------------------------------------------------------------------------------------------------
  public partial class CheckMarcks : Form
    {
    int currLine = 0;

    int src1, des1;                                 // Idiomas del primer diccionario
    int src2, des2;                                 // Idiomas del segundo diccionario

    int idx1, idx2;                                 // Indice al idioma común en los 2 diccionario

    string path1, path2;

    List<string> lines1, lines2;                    // Entradas de los dos diccionarios

    List<string> linCmp1, linCmp2;

    List<string[]> marks1, marks2;

    //string txt1Save;                                // Salva del texto para saber si se modifico
    //--------------------------------------------------------------------------------------------------------------------------------------
    // Carga el formulario
    private void CheckMarcks_Load( object sender, EventArgs e )
      {
      CheckEditText();
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    public CheckMarcks()
      {
      InitializeComponent();
      LBCurrLine.Text = currLine.ToString();
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void AnalizeBT_Click( object sender, EventArgs e )
      {
      List<string> l1, l2;
      try
        {
        path1 = TxtPathIni1.Text;
        path2 = TxtPathIni2.Text;

        l1 = File.ReadAllLines( path1 ).ToList();
        l2 = File.ReadAllLines( path2 ).ToList();

        LangUtils.CodeLangsFromPath(path1, out src1, out des1 );
        LangUtils.CodeLangsFromPath(path2, out src2, out des2 );

        idx1 = GetLangsIdx( out idx2);
        if( idx2<0 ) return;

        lines1 = GetMarksLines( l1 );
        lines2 = GetMarksLines( l2 );

        linCmp1 = SplitLine( lines1, idx1, out marks1 );
        linCmp2 = SplitLine( lines2, idx2, out marks2 );

        currLine = -1;
        NextLine();
        }
      catch( Exception ex )
        {
        MessageBox.Show( "*** SE PRODUJO UN ERROR AL CARGAR EL DICCIONARIO:\r\n*** " + ex.Message );
        return;
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Continua analizando los diccionarios ya cargados </summary>
    private void NextLine()
      {
      txtBLine1.Text = txtBLine2.Text = "";

      for( int i = currLine + 1; i < lines1.Count; i++ )
        {
        Dictionary<int, string> l2 = Contradiction(i);
        if( l2 != null )
          {
          currLine = i;
          LBCurrLine.Text = i.ToString() + "/" + lines1.Count;
          txtBLine1.Text = ShowMarks( lines1[i], src1, des1 );
          foreach( var line in l2 )
            txtBLine2.AppendText( line.Key + ":" + ShowMarks( line.Value, src2, des2 ) + "\r\n" );

          return;
          }
        }

      MessageBox.Show( "El diccionario se ha terminado de analizar" );
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    // Se llama al cambiar el modo como se muestran las marcas
    private void chkMarkText_CheckedChanged( object sender, EventArgs e )
      {
      char[] sep = {':'};

      CheckEditText();

      LBCurrLine.Text = currLine.ToString() + "/" + lines1.Count;
      txtBLine1.Text = ShowMarks( lines1[currLine], src1, des1 );

      string[] text = txtBLine2.Lines;

      txtBLine2.Text = "";
      foreach( var line in text )
        {
        if( line == "" ) continue;

        var aux = line.Trim();
        var l = aux.Split(sep, 2 );

        int idx;
        int.TryParse( l[0], out idx );

        txtBLine2.AppendText( l[0] + ":" + ShowMarks( lines2[idx], src2, des2 ) + "\r\n" );
        }

      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void CheckEditText()
      {
      if( chkMarkText.Checked )
        {
        txtBLine1.ReadOnly = true;
        txtBLine2.ReadOnly = true;
        }
      else
        {
        txtBLine1.ReadOnly = false;
        txtBLine2.ReadOnly = false;
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    // Sustitulle las marcas o no en una lines de acuerdo al modo activo
    private string ShowMarks( string line, int src, int des )
      {
      if( chkMarkText.Checked == false ) return line;

      var parts = line.Split('\\');

      string sKey = parts[0], sData = parts[1];

      Dictionary<string, string> actMark;

      int err = MarksMng.Current.ResplaceMarks(ref sKey, ref sData, src, des, out actMark);
      if( err != 0 )
        {
        MessageBox.Show( "ERROR: Sustituyendo las marcas -> " + MarksMng.Current.ErrorMsg( err ) );
        return line;
        }

      return sKey + '\\' + sData;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Busca por una contradicción en los diccionarios: si dos lineas son iguales pero tienen las marcas diferentes </summary>                                                                                                  
    private Dictionary<int, string> Contradiction( int idx )
      {
      var res = new Dictionary<int, string>();

      string line1 = lines1[idx];
      string[] m1 = marks1[idx];
      string compLine = linCmp1[idx];

      for( int i = 0; i < lines2.Count; i++ )
        {
        var means = linCmp2[i].Split( ';' );                             // Separa los significados

        for( int j = 0; j<means.Length; ++j )
          {
          if( compLine == means[j] && DifferentMarks( m1, marks2[i] ) )
            {
            res.Add( i, lines2[i] );
            break;
            }
          }
        }

      return res.Count > 0 ? res : null;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Busca si las marcas son diferentes </summary>                        
    private bool DifferentMarks( string[] marks1, string[] marks2 )
      {
      if( marks1.Length != marks2.Length ) return false;
      foreach( var m in marks1 )
        {
        if( !marks2.Contains( m ) )
          return true;
        }

      return false;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Busca las marcas que matchean con la línea </summary>                               
    private string[] GetMatches( string line )
      {
      var a = MarksMng.reMark.Matches(line);
      string[] marks = new string[a.Count];

      for( int i = 0; i < marks.Length; i++ )
        marks[i] = a[i].ToString();

      return marks;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Divide la linea para el idioma elegido, elimina las marcas ya que no son necesarias para la comparación y pone las marcas 
    /// encontradas </summary>                                                                                                                           
    private List<string> SplitLine( List<string> lines, int idx, out List<string[]> marks )
      {
      var cmpLines = new List<string>();
      marks = new List<string[]>();

      foreach( var line in lines )
        {
        var part  = line.Split( '\\' )[idx];                       // Separa las partes y se queda con la del idioma comun
        var means = part.Split( ';' );                             // Separa los significados

        marks.Add( GetMatches( means[0] ) );                       // Adiciona las marcas en el primer significado al arreglo

        var compOra = "";
        for( int i=0; i<means.Length; ++i )
          {
          var cmpMean = MarksMng.reMark.Replace( means[i], "" );  // Le quita todas las marcas del significado
          cmpMean = cmpMean.Trim( " . x¿?¡!".ToCharArray() );     // Quita caracteres de inicio y fin que sobran
          cmpMean = cmpMean.ToLower();                            // Lleva toda la cadena a minusculas  

          compOra += cmpMean;
          if( i < means.Length-1 ) compOra += ';';
          }

        cmpLines.Add( compOra );                                     // Adiciona la parte de la linea al arreglo
        }

      return cmpLines;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void BTCont_Click( object sender, EventArgs e )
      {
      try
        {
        CheckMarksOK();
        NextLine();
        }
      catch( Exception exc)
        {
        MessageBox.Show( exc.Message );
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Cheque si las marcas esta OK en la lines aque se esta editando </summary>
    private void CheckMarksOK()
      {
      string textNew = txtBLine1.Text;

      var parts = textNew.Split('\\');
      if( parts.Length<2 )
        throw new Exception( "ERROR Texto 1: No hay separación entre oraciones" );

      var src = (idx1==0)? src1 : des1;
      var des = (idx1==0)? des1 : src1;
      int err = CheckMarks( textNew, src, des );
      if( err != 0 )
        throw new Exception( "ERROR Texto 1:" + MarksMng.Current.ErrorMsg( err ) );

      string[] text = txtBLine2.Lines;
      foreach( var line in text )                                           // Recorre todas las líneas del texto
        {
        var str = line.Trim();
        if( str.Length == 0 ) continue;

        parts = str.Split(sep,2);                                    // Sapara el indice a la linea y el texto
        if( parts.Length<2 )
          throw new Exception( "ERROR Texto 2: No hay separación entre oraciones" );

        var sNum = parts[0];                                                // Toma el número  
        textNew = parts[1];                                                 // Toma el texto

        src = (idx2==0)? src2 : des2;                                       // Obtiene los idiomas de cada parte
        des = (idx2==0)? des2 : src2;                          
        err = CheckMarks( textNew, src, des );                              // Chequea el formato de la línea  
        if( err != 0 )
          throw new Exception( "ERROR Texto 2:" + MarksMng.Current.ErrorMsg( err ) );

        int idxLine;
        if( !int.TryParse( sNum, out idxLine ) )
          throw new Exception( "ERROR Texto 2: El número de la línea tiene un formato incorrecto" );
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void txtBLine1_TextChanged( object sender, EventArgs e )
      {
      string textNew = txtBLine1.Text;
      if( textNew == "" || chkMarkText.Checked ) return;

      var parts = textNew.Split('\\');
      if( parts.Length<2 ) return;

      var textOld  = lines1[currLine];
      if( textOld != textNew )
        {
        if( !textNew.EndsWith( "\\C-" ) )
          textNew += "\\C-";
        }

      lines1[currLine] = textNew;
      var split         = parts[idx1];
      linCmp1[currLine] = MarksMng.reMark.Replace( split, "" );
      marks1[currLine]  = GetMatches( split );
      }

    static char[] sep = { ':' };
    //--------------------------------------------------------------------------------------------------------------------------------------
    private void txtBLine2_TextChanged( object sender, EventArgs e )
      {
      if( txtBLine2.Text == "" || chkMarkText.Checked ) return;

      string[] text = txtBLine2.Lines;
      foreach( var line in text )                                           // Recorre todas las líneas del texto
        {
        var parts = line.Trim().Split(sep,2);                               // Sapara el indice a la linea y el texto
        if( parts.Length<2 ) return;                                        // Tiene que tener al menos dos partes

        var sNum = parts[0];                                                // Toma el número  
        var textNew = parts[1];                                             // Toma el texto

        int idxLine;
        if( !int.TryParse( sNum, out idxLine ) ) return;                    // Obtiene el indice a la oracion

        var textOld =  lines2[idxLine];
        if( textOld != textNew )
          {
          if( !textNew.EndsWith( "\\C-" ) )
            textNew += "\\C-";
          }

        lines2[idxLine] = textNew;

        var showOra = textNew.Split( '\\' )[idx2];                          // Obtiene la oración que se esta mostrando

        var compOra = MarksMng.reMark.Replace( showOra, "" );               // Le quita todas las marcas
        compOra = compOra.Trim( " . x¿?¡!".ToCharArray() );                 // Quita caracteres de inicio y fin que sobran
        compOra = compOra.ToLower();                                        // Lleva toda la cadena a minusculas  

        linCmp2[idxLine] = compOra;                                         // Oración sin marcas
        marks2[idxLine]  = GetMatches( showOra );                           // Marcas en la oración
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Chequa si la linea de texto tiene puesta las marcas correstamente </summary>
    private int CheckMarks( string text, int src, int des )
      {
      var parts = text.Split( '\\' );                                      // Divide la oracion, en fuente y traducida
      if( parts.Length<2 ) return 11;

      Dictionary<string, string> actMark;

      var sKey = parts[0];
      var sDatos = parts[1];

      return MarksMng.Current.ResplaceMarks( ref sKey, ref sDatos, src, des, out actMark );    // Chequea las marcas
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    // Actualiza la informacion sobre las marcas
    private void btnMarksInfo_Click( object sender, EventArgs e )
      {
      MarksMng.Load( "Marcas.txt" );
      }

    private void btnSetAutoOk_Click( object sender, EventArgs e )
      {
      if( lines1==null || lines2==null ) 
        {
        MessageBox.Show( "Primero hay que cargar los diccionarios" );
        return;
        }

      int num = 0;

      for( int i = 0 + 1; i < lines1.Count; i++ )
        {
        int j = 0;

        for(;;)
          {
          int idx = NextIgualLine( i, j );
          if( idx < 0 ) break;

          var Rev1 = lines1[i  ].EndsWith( "\\C-" );
          var Rev2 = lines2[idx].EndsWith( "\\C-" );

          if( Rev1 && !Rev2 )
            {
            lines2[idx] += "\\C-";
            ++num;
            }
          else if( !Rev1 && Rev2 )
            {
            lines1[i] += "\\C-";
            ++num;
            }

          j = idx + 1;
          }
        }

      MessageBox.Show( "Se encontraron " + num + " líneas iguales" );
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void BTSave_Click( object sender, EventArgs e )
      {
      try{ CheckMarksOK(); } catch { }

      try
        {
        List<string> newLines1 = GetNewLines(File.ReadAllLines(path1), 1);
        List<string> newLines2 = GetNewLines(File.ReadAllLines(path2), 2);

        File.WriteAllLines( path1, newLines1.ToArray() );
        File.WriteAllLines( path2, newLines2.ToArray() );
        }
      catch( Exception exc )
        {
        MessageBox.Show( exc.Message );
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void btnHome_Click( object sender, EventArgs e )
      {
      try
        {
        CheckMarksOK();

        currLine = -1;
        NextLine();
        }
      catch( Exception exc )
        {
        MessageBox.Show( exc.Message );
        }
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private List<string> GetNewLines( string[] oldLines, int mode )
      {
      var lines = mode == 1 ? lines1 : lines2;
      List<string> nLines = new List<string>();
      int idx = 0;
      foreach( var line in oldLines )
        {
        if( MarksMng.ContainsMark( line ) )
          nLines.Add( lines[idx++] );
        else
          nLines.Add( line );
        }
      return nLines;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void BtnPathIni_Click( object sender, EventArgs e )
      {
      SelFileDlg.Title = "Seleccione el diccionario para buscar nombres";
      SelFileDlg.Filter = "Diccionario con datos para mostrar (*.dcv)|*.dcv";

      if( SelFileDlg.ShowDialog( this ) == DialogResult.OK )
        TxtPathIni1.Text = SelFileDlg.FileName;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    private void button2_Click( object sender, EventArgs e )
      {
      SelFileDlg.Title = "Seleccione el diccionario para buscar nombres";
      SelFileDlg.Filter = "Diccionario con datos para mostrar (*.dcv)|*.dcv";

      if( SelFileDlg.ShowDialog( this ) == DialogResult.OK )
        TxtPathIni2.Text = SelFileDlg.FileName;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Segun los idiomas de los diccionarios busca el índice para que sean iguales </summary>                                                                 
    private int GetLangsIdx( out int des )
      {
      int src = -1;
      des =-1;

      if( src1 == src2 ) {src=0; des=0;}
      if( src1 == des2 ) {src=0; des=1;}
      if( des1 == src2 ) {src=1; des=0;}
      if( des1 == des2 ) {src=1; des=1;}

      if( src<0 )
        MessageBox.Show( "Los diccionarios no tienen idiomas comun, imposible compararlos" );

      return src;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Obtiene las líneas del texto que tengan marcas</summary>                                 
    private List<string> GetMarksLines( List<string> lines )
      {
      List<string> res = new List<string>();
      foreach( var line in lines )
        {
        if( MarksMng.ContainsMark( line ) )
          res.Add( line );
        }
      return res;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    /// <summary> Busca para la linea i en el primer diccionario si hay una linea igual en el segundo </summary>
    private int NextIgualLine( int i, int j )
      {
      string line1 = lines1[i];
      string[] m1  = marks1[i];
      string comp1 = linCmp1[i];

      for( ; j < lines2.Count; j++ )
        {
        string comp2 = linCmp2[j];

        if( comp1 == comp2 && !DifferentMarks( m1, marks2[j] ) )
           return j;
        }

      return -1;
      }

    //--------------------------------------------------------------------------------------------------------------------------------------
    }

  }
