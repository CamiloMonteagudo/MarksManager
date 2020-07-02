using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tests;

namespace MarksManager
  {
  public partial class AddMarkFrm : Form
    {
    public KeyValuePair<string, MarkInfo> NewMark { get; set; }
    public AddMarkFrm()
      {
      InitializeComponent();
      }

    static Regex reMark = new Regex("([A-Z][A-Z][a-z]?[1-9])");

    private void AddMarkFrm_Load( object sender, EventArgs e )
      {
      if( string.IsNullOrEmpty(NewMark.Key) ) return;

      TBCode.Text = NewMark.Key;
      TBDesc.Text = NewMark.Value.Desc;

      TBEs.Text = NewMark.Value.Es;
      TBEn.Text = NewMark.Value.En;
      TBIt.Text = NewMark.Value.It;
      TBFr.Text = NewMark.Value.Fr;
      }

    private void BtOk_Click( object sender, EventArgs e )
      {
      NewMark = new KeyValuePair<string, MarkInfo>();
      string es = TBEs.Text;
      string en = TBEn.Text;
      string it = TBIt.Text;
      string fr = TBFr.Text;
      if( es == "" || en == "" || it == "" || fr == "" )
        {
        MessageBox.Show( "Falta al menos una traducción en un idioma por poner" );
        return;
        }
      string code = TBCode.Text;
      if( !reMark.IsMatch( code ) )
        {
        MessageBox.Show( "Tiene que introducir un código válido" );
        return;
        }
      MarkInfo m = new MarkInfo(new string[] { code, TBDesc.Text, "{" + es + "}", "{" + en + "}", "{" + it + "}", "{" + fr + "}" });
      NewMark = new KeyValuePair<string, MarkInfo>( code, m );

      if( MarksMng.Current.AddMark( code, m ) )
        DialogResult = DialogResult.OK;
      }

    }
  }
