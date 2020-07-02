using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tests;

namespace MarksManager
  {
  public partial class Main : Form
    {
    /// <summary>Marcas de las líneas (ordenadas por índice)</summary>
    Dictionary<int, Dictionary<string, string>> marks;

    /// <summary>Líneas con marcadores para sustitución</summary> 
    List<MrkEntry> mrkLines;

    /// <summary>Lineas originales cargadas desde fichero</summary>
    string[] Lines;

    /// <summary>Camino de archivo abierto</summary>
    string path;

    /// <summary>índice de la línea seleccionada</summary>
    int selEntry;

    /// <summary>Código que indica de que idioma a otro se realiza la traducción</summary>
    int src, des;
    private bool ShowDes;

    public Main()
      {
      InitializeComponent();
      MarksMng.Load( "Marcas.txt" );

      CBFilter.SelectedItem = CBFilter.Items[0];
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Selecciona el fichero de trabajo
    private void BtnPathIni_Click( object sender, EventArgs e )
      {
      SelFileDlg.Title = "Seleccione el diccionario para buscar nombres";
      SelFileDlg.Filter = "Diccionario con datos para mostrar (*.dcv)|*.dcv";

      if( SelFileDlg.ShowDialog( this ) == DialogResult.OK )
        TxtPathIni.Text = SelFileDlg.FileName;
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Carga el contedido del fichero a trabajar
    private void BtnLoad_Click( object sender, EventArgs e )
      {
      if( !UpLoad() ) return;

      string lng1, lng2;
      LangUtils.AbrevLangsFromPath( path, out lng1, out lng2 );

      LstMarks.Columns[2].Text = lng1;
      LstMarks.Columns[3].Text = lng2;

      FillMarksList();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Pone las marcas en la lista dependiendo de los idiomas del diccionario</summary>
    private void FillMarksList()
      {
      LstMarks.Items.Clear();
      foreach( var l in MarksMng.Current.Marks )
        {
        MarkInfo info = l.Value;
        string a = GetInfo(src, info);
        string b = GetInfo(des, info);
        string[] subItem = { l.Key, info.Desc, a, b };
        LstMarks.Items.Add( new ListViewItem( subItem ) );
        }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Obtiene el idioma de acuerdo a su código</summary>         
    private string GetInfo( int s, MarkInfo info )
      {
      switch( s )
        {
        case 0: return info.Es;
        case 1: return info.En;
        case 2: return info.It;
        case 3: return info.Fr;
        }
      return null;
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Carga el archivo de acuerdo a un filtro, en caso de ocurrir un error retorna false</summary>     
    private bool UpLoad( )
      {
      TxtMsgBox.Text = "";

      Lines    = new string[0];
      mrkLines = new List<MrkEntry>();
      marks    = new Dictionary<int, Dictionary<string, string>>();

      selEntry = 0;
      try
        {
        path = TxtPathIni.Text;
        if( !LangUtils.CodeLangsFromPath( path, out src, out des ) )
          {
          MessageBox.Show( "No se puedo obtener los idiomas del nombre del fichero:\r\n" + path );
          return false;
          }

        Lines = File.ReadAllLines( path );
        for( int i = 0; i < Lines.Length; i++ )
          {
          var parts = Lines[i].Split('\\').ToList();

          if( parts.Count>=2 && MarksMng.ContainsMark(parts[0]) )
            mrkLines.Add( new MrkEntry( i, parts ) );
          }

        lstLines.BackColor = SystemColors.Window;
        lstLines.VirtualListSize = mrkLines.Count;
        lstLines.Refresh();
        }
      catch( Exception ex )
        {
        MessageBox.Show( "*** SE PRODUJO UN ERROR AL CARGAR EL DICCIONARIO:\r\n*** " + ex.Message );
        return false;
        }

      return true;
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cuando se selecciona una de las opciones en el combobox de filtrado
    private void CBFilter_SelectedValueChanged( object sender, EventArgs e )
      {
      if( Lines==null || Lines.Length==0 ) return;

      Predicate<string> filter;

      string f = (string)CBFilter.SelectedItem;
      switch( f )
        {
        case "Checked"  : filter = x => x.Contains( "\\C-" );   break;
        case "Unchecked": filter = x => !x.Contains( "\\C-" );  break;
        default:          filter = x => x.Length > 0 ;          break;
        }

      mrkLines = new List<MrkEntry>();
      marks    = new Dictionary<int, Dictionary<string, string>>();

      selEntry = 0;
      for( int i = 0; i < Lines.Length; i++ )
        {
        var line  = Lines[i];
        var parts = line.Split('\\').ToList();

        if( parts.Count>=2 && MarksMng.ContainsMark(parts[0]) && filter(line) )
          mrkLines.Add( new MrkEntry( i, parts ) );
        }

      lstLines.VirtualListSize = mrkLines.Count;
      lstLines.Refresh();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Pone un mensaje para información del usuario</summary>
    private void SetMessage( string msg )
      {
      TxtMsgBox.Text += msg + "\r\n";
      Application.DoEvents();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Sustituye una línea del diccionario</summary>     
    private List<string> SustLineMarks( List<string> parts, int idx, bool noMsg=false )
      {
      string sKey = parts[0], sData = parts[1];
      Dictionary<string, string> actMark;
      int err = MarksMng.Current.ResplaceMarks(ref sKey, ref sData, src, des, out actMark);
      if( err != 0 )
        {
        if( noMsg==false )
          MessageBox.Show( "Línea: " + idx + " -> " + MarksMng.Current.ErrorMsg( err ) );
        }
      else
        {
        marks[idx] = actMark;

        var sustParts = new List<string>(parts);

        sustParts[0] = sKey;
        sustParts[1] = sData;

        return sustParts;
        }

      return null;
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Obtiene las líneas necesarias para mostrar en el listView</summary>   
    private void lstLines_RetrieveVirtualItem( object sender, RetrieveVirtualItemEventArgs e )
      {
      int idx = e.ItemIndex;
      if( idx<0 || idx>=mrkLines.Count ) return;

      var entry = mrkLines[ idx ];
      List<string> sust = SustLineMarks(entry.Parts, idx);
      if( sust == null ) return;

      e.Item = new ListViewItem( ShowDes? sust[1] : sust[0] );

      if( entry.Parts.Contains( "C-" ) )
        e.Item.ForeColor = Color.DarkGreen;
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Cuando se selecciona un elemento, se muestran las marcas presentes en la línea</summary> 
    private void lstLines_SelectedIndexChanged( object sender, EventArgs e )
      {
      var i = (sender as ListView).SelectedIndices;
      if( i.Count == 0 ) return;
      selEntry = i[0];

      FillNowMarks();                                         // Llena la lista con las marcas en la entrada
      if( ListBMarks.Items.Count>0 )
        {
        ListBMarks.SelectedItem = ListBMarks.Items[0];          // Selecciona la primera marca

        EditActualEntry();
        }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Pone los datos del la entrada actual en el cuadro de edicción</summary>
    private void EditActualEntry()
      {
      TxtMsgBox.Text = "";                                    // Pone las oraciones debajo

      var entry = mrkLines[selEntry];
      var parts = Lines[entry.Idx].Split('\\').ToList();

      SetMessage( parts[0] );
      SetMessage( parts[1] );
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Pone las sustituciones de las marcas en el listBox</summary>
    private void FillNowMarks()
      {
      ListBMarks.Items.Clear();
      foreach( var item in marks[selEntry] )
        ListBMarks.Items.Add( item.Key + " -> " + item.Value );
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Guarda el contenido del fichero a disco
    private void BtSave_Click( object sender, EventArgs e )
      {
      File.WriteAllLines( path, Lines );
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cuando de oprime return sobre una entrada
    private void lstLines_KeyPress( object sender, KeyPressEventArgs e )
      {
      if( e.KeyChar == '\r' || e.KeyChar == ' ')
        {
        e.Handled = true;
        TougleRevisedMark();

        if( selEntry < mrkLines.Count-1 )
          lstLines.Items[++selEntry].Selected = true;
        }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Cambia el estado de la revision de la entrada seleccionada
    private void TougleRevisedMark()
      {
      var i = lstLines.SelectedIndices;
      if( i.Count == 0 ) return;
      int idx = i[0];

      var entry = mrkLines[idx];
      entry.ToggleRevised();

      Lines[entry.Idx] = entry.GetText();                         // Actualiza la entada sin marcas
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Adiciona una nueva marca a la lista de marcas
    private void BtAddMark_Click( object sender, EventArgs e )
      {
      MessageBox.Show("Falta implemantar");
      //var frm = new AddMarkFrm();
      //frm.NewMark = new KeyValuePair<string, MarkInfo>("", null);

      //if( frm.ShowDialog() == DialogResult.OK )
      //  {
      //  var res = frm.NewMark;
      //  var info = res.Value;

      //  string[] a = { res.Key + " |" + info.Desc + " |" + info.Es + " |" + info.En + " |" + info.It + " |" + info.Fr };
      //  File.AppendAllLines( "Marcas.txt", a );
      //  FillMarksList();
      //  }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Edita el contenido de la marca seleccionada
    private void btnEditMark_Click( object sender, EventArgs e )
      {
      var items = LstMarks.SelectedItems;
      if( items.Count == 0 ) return;

      var code1 = items[0].Text;
      var info1 = MarksMng.Current.Info(code1);

      var frm = new AddMarkFrm();
      frm.NewMark = new KeyValuePair<string, MarkInfo>(code1, info1);

      if( frm.ShowDialog() == DialogResult.OK )
        {
        var code2 = frm.NewMark.Key;
        var info2 = frm.NewMark.Value;

        if( code1 != code2 )
          {
          // Buscar por todos los diccionarios y modificar su valor
          }

//        FillMarksList();
        MessageBox.Show("Falta implemantar");
        }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Borra al marcador seleccionado
    private void btnDelMark_Click( object sender, EventArgs e )
      {
      var items = LstMarks.SelectedItems;
      if( items.Count == 0 ) return;

      var code = items[0].Text;

      // Buscar que no se use en ningún diccionario
      MessageBox.Show("Falta implemantar");
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cuando se presione return en la lista informacion de las marcas
    private void LstMarks_KeyPress( object sender, KeyPressEventArgs e )
      {
      if( e.KeyChar != '\r' ) return;
      ChageMark();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cuando se da doble click en la lista informacion de las marcas
    private void LstMarks_DoubleClick( object sender, EventArgs e )
      {
      ChageMark();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    /// <summary>Sustituye la marca seleccionada por otra</summary>
    private void ChageMark()
      {
      var item = ListBMarks.SelectedItem;
      if( item == null ) return;

      var t = item.ToString().Split('-');
      string oldMrk = t[0].Trim();
      oldMrk = oldMrk.Trim( ']', '[' );

      var itm = LstMarks.SelectedItems;
      if( itm.Count == 0 ) return;
      string newMrk = itm[0].Text;

      var Entry   = mrkLines[selEntry];
      string line = Entry.GetText();
      line = line.Replace( oldMrk, newMrk );

      var s = line.Split('\\');
      List<string> Parts = line.Split('\\').ToList();

      List<string> sust = SustLineMarks(Parts, selEntry);           // Sustitulle las marcas en la entada
      if( sust == null ) return;
      
      Entry.Parts = Parts;

      Lines[Entry.Idx] = line;

      FillNowMarks();
      EditActualEntry();

      lstLines.Invalidate();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Atiende la opcion del menu de revisar las marcas
    private void checkMarksToolStripMenuItem_Click( object sender, EventArgs e )
      {
      var form = new CheckMarcks();
      form.ShowDialog();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cuando se cambia la marca seleccionada
    private void ListBMarks_SelectedIndexChanged( object sender, EventArgs e )
      {
      FindSelMark();            // Busca la marca seleccionada en la lista de marcas y la selecciona
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Busca la marca actual seleccionada y la selecciona en la lista de informacio de las marcas
    private void FindSelMark()
      {
      var item = ListBMarks.SelectedItem;
      if( item == null ) return;

      var t = item.ToString().Split('-');
      string key = t[0].Trim();
      key = key.Trim( ']', '[' );

      for( int i=0; i<LstMarks.Items.Count; i++ )
        {
        var mkInfo = LstMarks.Items[i];
        var key2 = mkInfo.SubItems[0].Text;

        if( key2==key )
          {
          mkInfo.Selected = true;
          mkInfo.EnsureVisible();
          break;
          }
        }
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Marca la entrada como que esta revisada o viseversa
    private void btnMarkRevised_Click( object sender, EventArgs e )
      {
      TougleRevisedMark();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Le quita la marca de revisada a todas las oraciones
    private void btnClearRevised_Click( object sender, EventArgs e )
      {
      for( int i=0; i < mrkLines.Count; i++ )
        {
        var item = mrkLines[i];

        item.DelRevised();
        Lines[item.Idx] = item.GetText();
        }

      lstLines.Invalidate();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Actualiza la informacion sobre las marcas desde un fichero
    private void btnUpdateFromFile_Click( object sender, EventArgs e )
      {
      MarksMng.Load( "Marcas.txt" );

      FillMarksList();
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Decide el idioma de las oraciones que se muestran en la lista
    private void chkShowDes_CheckedChanged( object sender, EventArgs e )
      {
      ShowDes = chkShowDes.Checked;
      lstLines.Invalidate();                                          // Manda a redibujar la lista
      }

    // -------------------------------------------------------------------------------------------------------------------------------
    // Se llama cada vez que se edita el contenido de la entrada actua, en la parte de abajo del formulario
    private void TxtMsgBox_TextChanged( object sender, EventArgs e )
      {
      string[] txt = TxtMsgBox.Lines;
      if( txt.Length < 3 || mrkLines.Count == 0 ) return;

      var entry = mrkLines[selEntry];
      if( entry.Parts[0]==txt[0] && entry.Parts[1]==txt[1] ) return;

      var parts = new List<string>() { txt[0], txt[1] };              // Forma la entrada con las 2 lines de texto

      List<string> sust = SustLineMarks(parts, selEntry, true);       // Sustitulle las marcas en la entada
      if( sust == null ) return;
      
      if( entry.Parts.Count==3 )                                      // Si la entrada estaba marcada como revisada
        parts.Add( "C-" );                                            // Le pone la marca

      entry.Parts = parts;                                            // Actualiza la entada con marcas
      Lines[entry.Idx] = entry.GetText();                             // Actualiza la entada sin marcas

      lstLines.Invalidate();                                          // Manda a redibujar la lista
      }
    }
  }

  //=====================================================================================================================================
  public class MrkEntry
    {
    public int Idx;
    public List<string> Parts;

    public MrkEntry(int idx, List<string> parts)
      {
      Idx = idx;
      Parts = parts;
      }

    // Pone la marca de entrada revisada
    public bool AddRevised()
      {
      if( Parts.Count!=2 ) return false;

      Parts.Add("C-");
      return true;
      }

    // Pone la marca de entrada revisada
    public bool DelRevised()
      {
      if( Parts.Count!=3 || Parts[2]!="C-" )  return false;

      Parts.RemoveAt( 2 );
      return true;
      }

    // Cambia la marca de entrada revisada
    public void ToggleRevised()
      {
      if( !AddRevised() ) DelRevised();
      }

    // Obtiene la información de la entrada en una línea de texto
    public string GetText()
      {
      string l = Parts[0] + "\\" + Parts[1];

      if( Parts.Count == 3 )
        l += "\\" + Parts[2];

      return l;
      }
    }

